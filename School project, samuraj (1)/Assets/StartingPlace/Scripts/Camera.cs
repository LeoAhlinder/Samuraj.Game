using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform playerpos;

    ScenesScript scenesscript;
    Player player;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        player = GameObject.Find("Player").GetComponent<Player>();
        scenesscript = GameObject.Find("ForSceneScript").GetComponent<ScenesScript>();
    }
    void LateUpdate()
    {
            if (scenesscript.StartingScene)
            {
                transform.position = new Vector3(playerpos.position.x + 0.8f, playerpos.position.y + 1, -10);
            }
        if (scenesscript.BirminghamScene)
        {
            if (player.transform.position.x > -2.2)
            {
                transform.position = new Vector3(playerpos.position.x + 0.5f, playerpos.position.y + 4.5f, -10);
            }
            if (player.transform.position.x <= -2.2)
            {
                transform.position = new Vector3(-1.8f, 2.535374f, -10);
            }
            if (player.transform.position.x > 1.47783)
            {
                transform.position = new Vector3(1.982227f, 2.535374f, -10);
            }

        }
        
    }
}
