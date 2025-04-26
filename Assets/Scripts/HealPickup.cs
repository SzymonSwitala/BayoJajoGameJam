using UnityEngine;

public class HealPickup : MonoBehaviour
{
   public int value;

    public int  PickUP()
    {
        Destroy(gameObject);
        return value;
       
    }
  
}
