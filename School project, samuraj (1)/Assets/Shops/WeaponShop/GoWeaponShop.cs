using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoWeaponShop : MonoBehaviour
{
    [SerializeField] public Transform WeaponShopPos;
    [SerializeField] public LayerMask Player;
    public GameObject OpenText;

    void Update()
    {
        bool PlayerCloseToHeadShop = Physics2D.OverlapCircle(WeaponShopPos.position, 0.4f, Player);
        if (PlayerCloseToHeadShop)
        {
            OpenText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenText.SetActive(false);
                SceneManager.LoadScene("WeaponShop");
                GameObject.Find("Player").GetComponent<Player>().transform.position = new Vector2(-100, -100);
                GameObject.Find("Player").GetComponent<Player>().InAStore = true;
            }
        }
        else
        {
            OpenText.SetActive(false);
        }
    }
}
