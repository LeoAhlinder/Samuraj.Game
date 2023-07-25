using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorder : MonoBehaviour
{
    Player player;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (player.transform.position.x > gameObject.transform.position.x + 0.3f)
            {
                GameObject.Find("Player").GetComponent<Player>().OnlyCanMoveRight = true;

            }
            if (player.transform.position.x < gameObject.transform.position.x - 0.3f)
            {
                GameObject.Find("Player").GetComponent<Player>().OnlyCanMoveLeft = true;
            }
        }
    }
}
