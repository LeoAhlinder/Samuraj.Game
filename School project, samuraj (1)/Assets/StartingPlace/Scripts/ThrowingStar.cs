using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingStar : MonoBehaviour
{
    public float bulletspeed = 15f;
    public Rigidbody2D rb;
    Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Start()
    {
        
        StartCoroutine(Timer()); 
        
        if (player.FacingRight)
        {
            rb.velocity = transform.right * bulletspeed;
        }
        else
        {
            rb.velocity = transform.right *  -bulletspeed;
        }
    }                 
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D hitinfo)
    {
        FlyingEyeMonster enemy = hitinfo.GetComponent<FlyingEyeMonster>();
        if (enemy != null) 
        {
            enemy.Takedmg(player.ShurikenDMG);
        }
        Destroy(gameObject);

        Goblin enemy1 = hitinfo.GetComponent<Goblin>();
        if (enemy1 != null)
        {
            enemy1.Takedmg(player.ShurikenDMG);
        }
        Destroy(gameObject);

    }

  



}


