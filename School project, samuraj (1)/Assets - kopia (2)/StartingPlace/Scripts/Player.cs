using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Transform GroundCheck;
    public LayerMask Ground;
    public LayerMask Enemies;
    public bool Bodyslamdmg;
    private bool Slam;
    public float speed = 3f;
    public GameObject Startmenu;
    public bool MovingInMenus;
    private bool Movement;
    public Transform ThrowingPos;
    public GameObject ThrowingStar;
    public int ThrowingStarAmount = 3;
    public bool CanThrow;
    public bool FacingRight;
    public float Health = 10;
    Menu menu;
    public GameObject DeathScreen;
    private float oldPosition;
    public bool MoveAnywhere = true;
    public bool OnlyCanMoveLeft;
    public bool OnlyCanMoveRight;
    public Rigidbody2D rb;
    public Transform playerpos;
    public LayerMask WorldBorder;
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(transform.gameObject);
        menu = GameObject.Find("menu").GetComponent<Menu>();
    }
    private void Start()
    {
        SceneManager.LoadScene("Birmingham");
        oldPosition = transform.position.x;
    }



    void Update()
    {
        bool IsTouchingGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Ground);
        bool WorldBorderClose = Physics2D.OverlapCircle(playerpos.position, 0.3f, WorldBorder);

        Debug.Log(MoveAnywhere);
        if (WorldBorderClose)
        {
            if (OnlyCanMoveLeft)
            {
                MoveAnywhere = false;
                if (Input.GetKey(KeyCode.A))
                {
                    rb.AddForce(Vector2.left * speed);
                }
            }
            if (OnlyCanMoveRight)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    rb.AddForce(Vector2.right * speed);
                }
                MoveAnywhere = false;

            }
        }
        else
        {
            MoveAnywhere = true;
        }
        if (MoveAnywhere)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * speed;
        }

        if (menu.Menus)
        {
            if (oldPosition > transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                FacingRight = false;
            }

            if (oldPosition < transform.position.x)
            {
                FacingRight = true;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            oldPosition = transform.position.x;
          

            if (Startmenu.activeSelf)
            {
                speed = 0;
            }
            if (MovingInMenus == true)
            {
                if (Input.GetButtonDown("Jump") && IsTouchingGround)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
                }
            }       
            

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 4;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 3;
            }
            if (Input.GetKey(KeyCode.S) && IsTouchingGround == false)
            {
                GetComponent<Rigidbody2D>().gravityScale = 7;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                GetComponent<Rigidbody2D>().gravityScale = 1;
            }

            IEnumerator Bodyslam()
            {

                Slam = true;
                yield return new WaitForSeconds(0.3f);
                Slam = false;
            }
            bool BodySlam = Physics2D.OverlapCircle(GroundCheck.position, 0.95f, Ground);
            if (Input.GetButtonDown("Jump"))
            {
                Bodyslam();
            }
            if (Slam == true)
            {
                if (Input.GetKeyDown(KeyCode.S) && BodySlam)
                {

                    Physics2D.OverlapCircle(GroundCheck.position, 1.5f, Enemies);
                }
            }
            IEnumerator ShootingColddown()
            {
                CanThrow = false;
                yield return new WaitForSeconds(0.5f);
                CanThrow = true;
            }
            void Throw()
            {
                Instantiate(ThrowingStar, ThrowingPos.position, Quaternion.identity);
            }
            if (CanThrow == true)
            {
                if (ThrowingStarAmount > 0)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        Throw();
                        StartCoroutine(ShootingColddown());
                        ThrowingStarAmount -= 1;
                    }
                }
            }

            if (Input.GetButtonDown("Fire1"))
            {


            }
        }

        if (Health <= 0)
        {
            gameObject.SetActive(false);
            DeathScreen.SetActive(true);
        }
    }
}


