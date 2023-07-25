using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateForRoof : MonoBehaviour
{
    public BoxCollider2D box;
    Player player;
    public Transform boxpos;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Update()
    {
        if (player.transform.position.y > boxpos.position.y)
        {
            box.enabled = true;
        }
        else
        {
            box.enabled = false;
        }
    }
}
