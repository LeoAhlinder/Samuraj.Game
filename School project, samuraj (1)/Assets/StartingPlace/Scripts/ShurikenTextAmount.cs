using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShurikenTextAmount : MonoBehaviour
{
    TextMeshProUGUI TextMesh;
    float Shurikens;
    Menu menu;
    Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        TextMesh = gameObject.GetComponent<TextMeshProUGUI>();
        menu = GameObject.Find("menu").GetComponent<Menu>();
    }
    void Update()
    {
        if (menu.Menus)
        {
            StartCoroutine(CD());
            IEnumerator CD()
            {
                if (player.Health > 0)
                {
                    yield return new WaitForSeconds(3f);
                    gameObject.SetActive(true);
                    Shurikens = player.ThrowingStarAmount;
                    TextMesh.text = "Shurikens: " + Shurikens;
                }
                else
                {
                    TextMesh.text = "";
                }
            }
        }
    }
}
