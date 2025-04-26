using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HUDController : MonoBehaviour
{
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] TextMeshProUGUI gameTimerText;
    [SerializeField] private GameObject heartIconPrefab;
    [SerializeField] Transform hpBar;
    private GameObject[] hearts;

    
    void Update()
    {

      gameTimerText.text =gameTimer.GetTime();
   
    }
     public void SetHP(int maxhp)
    {
        hearts = new GameObject[maxhp];

        for (int i=0;i<maxhp;i++)
        {
           GameObject go = Instantiate(heartIconPrefab, hpBar.position, Quaternion.identity);
            go.transform.SetParent(hpBar);
            hearts[i] = go;
        }
        
    }
    public void UpdateHP(int hp)
    {
        for (int i=0;i <hearts.Length;i++)
        {
            if (i<hp)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
           
        }
    }
}
