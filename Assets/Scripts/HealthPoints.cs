using Unity.VisualScripting;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] private int maxHP;
    [SerializeField] private PlayerController player;
    [SerializeField] private HUDController hUD;
    int currentHP;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private int damageSoundVolume;
    private void Start()
    {
        currentHP = maxHP;
        hUD.SetHP(maxHP);
    }
    public void TakeDamage()
    {
        currentHP--;
        AudioManager.Instance.PlayOneShot(damageSound, damageSoundVolume);
        hUD.UpdateHP(currentHP);
        if (currentHP <= 0)
        {
            player.Dead();
            GameManager.Instance.GameOver();
        }
    }

    public void AddHP(int value)
    {
        if (currentHP >= maxHP) return;
        currentHP++;
        hUD.UpdateHP(currentHP);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("DamageZone"))
        {
            TakeDamage();
        }

        HealPickup healPickup = other.GetComponent<HealPickup>();
        if (healPickup != null)
        {
            AddHP(healPickup.PickUP());
        }

        

    }
}