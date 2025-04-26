using Unity.VisualScripting;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] private int maxHP;
    [SerializeField] private PlayerController player;
    [SerializeField] private HUDController hUD;
    int currentHP;
    private void Start()
    {
        currentHP = maxHP;
        hUD.SetHP(maxHP);
    }
    public void TakeDamage()
    {
        currentHP--;
        hUD.UpdateHP(currentHP);
        if (currentHP<=0)
        {
            player.Dead();
            GameManager.Instance.GameOver();
        }
    }

    public void AddHP()
    {
        if (currentHP >= maxHP) return;
        currentHP++;
        hUD.UpdateHP(currentHP);
    }
}
