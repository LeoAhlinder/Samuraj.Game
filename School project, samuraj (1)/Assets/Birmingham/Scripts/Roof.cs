using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour
{
    public BoxCollider2D box;
    [SerializeField] public GameObject Pos;
    Player player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > Pos.transform.position.y)
        {
            box.enabled = true;
        }
        else
        {
            box.enabled = false;
        }
    }
}
