using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin: MonoBehaviour
{
    public float health = 5;
    Menu menu;
    public Transform Goblinpos;
    public LayerMask Player;
    public Animator animator;
    private bool PlayerClose;
    private bool GoblinAttack;
    public float playerhealth;
    private bool GoblinCanAttack;
    public Transform PlayerPos;
    public float GoblinSpeed = 2.5f;
    SpriteRenderer myspriterenderer;
    private bool FacingRight;
    public bool GoblinBackToSpawn;
    public bool GoblinHit;
    public void Awake()
    {
        myspriterenderer = GetComponent<SpriteRenderer>();
        GoblinCanAttack = true;
        menu = GameObject.Find("menu").GetComponent<Menu>();
        playerhealth = GameObject.Find("Player").GetComponent<Player>().Health;
    }
    public void Takedmg(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(Dying());
        }
        IEnumerator Dying()
        {
            yield return new WaitForSeconds(35f);
            gameObject.SetActive(false);
        }
    }
    public void Update()
    {
        bool GoblinRunToPlayer = Physics2D.OverlapCircle(Goblinpos.position, 10f, Player);  
        bool GoblinAttack = Physics2D.OverlapCircle(Goblinpos.position, 1f, Player);
        
        animator.SetBool("GoblinHit", GoblinHit);
        animator.SetBool("PlayerClose", GoblinAttack);
        animator.SetFloat("GoblinRunning", GoblinSpeed);
        animator.SetFloat("GoblinDead", health);
        animator.SetFloat("PlayerHealth", playerhealth);
        animator.SetBool("PlayerCloseToGoblin", GoblinRunToPlayer);
        animator.SetBool("Paused", menu);

        if (GoblinRunToPlayer)
        {
            if(health >= 1) {
                if (menu.Menus)
                {
                    if (GoblinCanAttack)
                    {
                        if (GoblinAttack)
                        {
                            StartCoroutine(GoblinAttacking());
                        }
                    }

                    IEnumerator GoblinAttacking()
                    {
                        GoblinCanAttack = false;
                        yield return new WaitForSeconds(0.73f);
                        if (GoblinAttack)
                        {
                            GameObject.Find("Player").GetComponent<Player>().Health -= 3;
                        }
                        GoblinCanAttack = true;
                    }

                    if (GameObject.Find("Player").GetComponent<Player>().Health >= 0)
                    {


                        if (PlayerPos.position.x <= gameObject.transform.position.x - 1f)
                        {
                            FacingRight = true;
                            transform.Translate(Vector3.left * Time.deltaTime * GoblinSpeed);
                        }
                        if (PlayerPos.position.x >= gameObject.transform.position.x + 1f)
                        {
                            FacingRight = false;
                            transform.Translate(Vector3.right * Time.deltaTime * GoblinSpeed);
                        }

                        myspriterenderer.flipX = FacingRight;
                    }                
                }   
            }
        }
        if (GoblinBackToSpawn)
        {
            GoblinSpeed = 4f;
            health = 5;
            gameObject.SetActive(true);
            gameObject.transform.position = new Vector3(15.1f, 2.4f, -6f);
            GoblinBackToSpawn = false;
        }
    }
}