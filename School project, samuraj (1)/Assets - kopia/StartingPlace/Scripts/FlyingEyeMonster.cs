using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeMonster : MonoBehaviour
{
    public float FlyingEyeSpeed = 2.25f;
    public Transform FlyingEyePos;
    private bool FacingRight;
    public float FlyingEyeHealth = 3;
    private bool FlyingEyeCanAttack = false;
    private bool FlyingEyeDoDamage = true;

    [SerializeField] bool FlyingEyeToPlayer;
    [SerializeField] public bool FlyingEyeAttack;

    public LayerMask Player;
    public Transform PlayerPos;

    [SerializeField] Rigidbody2D rigidbody1;
    [SerializeField] Rigidbody2D playersrb;
    public Animator animator;
    Menu menu;
    SpriteRenderer myspriterenderer;
    void Awake()
    {
        myspriterenderer = GetComponent<SpriteRenderer>();
        menu = GameObject.Find("menu").GetComponent<Menu>();
    }

    public void Takedmg(int damage)
    {
        FlyingEyeHealth -= damage;
        if (FlyingEyeHealth <= 0)
        {
            StartCoroutine(Dying());
        }
        IEnumerator Dying()
        {
            yield return new WaitForSeconds(3.5f);
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        bool FlyingEyeToClose = Vector2.Distance(transform.position, PlayerPos.position) < 0.85f;
        bool FlyingEyeToPlayer = Physics2D.OverlapCircle(FlyingEyePos.position, 13f, Player);    
        if (FlyingEyeAttack = Physics2D.OverlapCircle(FlyingEyePos.position, 3f, Player))
        {
            FlyingEyeCanAttack = true;
        }
        
        animator.SetBool("FlyingEyeCloseToPlayer", FlyingEyeToPlayer);
        animator.SetBool("FlyingEyeAttackPlayer", FlyingEyeAttack);
        animator.SetBool("Paused", menu);
        animator.SetFloat("Health", FlyingEyeHealth);
        animator.SetFloat("PlayerHealth", GameObject.Find("Player").GetComponent<Player>().Health);
  
        if (FlyingEyeHealth >= 0)
        {
            if (menu.Menus)
            {
                if (FlyingEyeToPlayer)
                {
                    if (FlyingEyePos.position.x < PlayerPos.position.x - 0.15f)
                    {
                        FacingRight = false;
                        transform.Translate(Vector2.right * Time.deltaTime * FlyingEyeSpeed);
                    }

                    if (FlyingEyePos.position.x > PlayerPos.position.x + 0.15f)
                    {
                        FacingRight = true;
                        transform.Translate(Vector2.left * Time.deltaTime * FlyingEyeSpeed);
                    }
                }
                myspriterenderer.flipX = FacingRight;
                    
                }
                if (FlyingEyeCanAttack) {
                    if (FlyingEyeAttack)
                    {
                        if (FlyingEyeDoDamage)
                        {
                            if (FlyingEyeToClose == false)
                            {
                                if (FacingRight == false)
                                {
                                    transform.Translate((PlayerPos.position - transform.position) * 50 * Time.deltaTime);
                                    StartCoroutine(FlyingEyeAttackingCD());
                                }
                                if (FacingRight)
                                {
                                    transform.Translate((PlayerPos.position - transform.position) * 50 * Time.deltaTime);
                                    StartCoroutine(FlyingEyeAttackingCD());
                                }

                                IEnumerator FlyingEyeAttackingCD()
                                {
                                    FlyingEyeDoDamage = false;
                                    yield return new WaitForSeconds(0.5f);
                                    if (FlyingEyeCanAttack)
                                    {
                                    GameObject.Find("Player").GetComponent<Player>().Health -= 2;
                                    }
                                    FlyingEyeDoDamage = true;
                                }
                            }
                        }
                    }
                }
            
        }
    }
}


