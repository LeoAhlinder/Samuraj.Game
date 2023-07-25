using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShurikenTextAmount : MonoBehaviour
{
    TextMeshProUGUI TextMesh;
    float Shurikens;
    Menu menu;
    void Start()
    {
        TextMesh = gameObject.GetComponent<TextMeshProUGUI>();
        menu = GameObject.Find("menu").GetComponent<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (menu.Menus)
        {
            gameObject.SetActive(true);
            Shurikens = GameObject.Find("Player").GetComponent<Player>().ThrowingStarAmount;
            TextMesh.text = "Shurikens: " + Shurikens;
        }
    }
}
