using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float health = 5;
   
    public void Takedmg(int damage) 
    {
        health -= damage;

        if (health == 0) 
        {
            Destroy(gameObject);
        }
    
    
    }
}
