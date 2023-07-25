using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Player : MonoBehaviour
{   public Transform GroundCheck;
    public LayerMask Ground;
    public LayerMask Enemies;
    public bool Bodyslamdmg;
    private bool Slam;
   [SerializeField] float speed = 5f;

    void Update()
    {

        bool IsTouchingGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Ground);

        if (Input.GetButtonDown("Jump") && IsTouchingGround)
        {  
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 7;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            speed = 5;
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
            Debug.Log("mums");
            Slam = true;
            yield return new WaitForSeconds(0.3f);
            Slam = false;        
        }
        bool BodySlam = Physics2D.OverlapCircle(GroundCheck.position, 0.95f, Ground);
        if (Input.GetButtonDown("Space")) 
        {
            StartCoroutine("Bodyslam");
        }
        if (Slam == true)
        {
            if (Input.GetKeyDown(KeyCode.S) && BodySlam)
            {
                Debug.Log("321");
                Physics2D.OverlapCircle(GroundCheck.position, 1.5f, Enemies);
            }
        }       
    }        
}
