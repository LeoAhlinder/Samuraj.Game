using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleOfBirmingham : MonoBehaviour
{
    private float Speed = 1.1f;
    private bool Direction = true;
    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Direction)
        {
            if (transform.position.x < 10.5f)
            {
                transform.Translate(Vector3.right * Speed * Time.deltaTime);
                if (sr != null)
                {
                    sr.flipX = false;
                }
            }
            else
            {
                Direction = false;
            }
        }
        if (!Direction) {
            if (transform.position.x > -10.5)
            {
                transform.Translate(Vector3.left * Speed * Time.deltaTime);
                if (sr != null)
                {
                    sr.flipX = true;
                }
            }
            else
            {
                Direction = true;
            }
        }     
    }
}
