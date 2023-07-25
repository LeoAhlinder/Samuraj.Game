using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadShopText : MonoBehaviour
{
    [SerializeField] public Transform HeadShopPos;
    [SerializeField] public LayerMask Player;
    public GameObject OpenText;
    private bool CloseToHeadShop;
    
    void Update()
    {
        bool PlayerCloseToHeadShop = Physics2D.OverlapCircle(HeadShopPos.position, 0.4f, Player);
        
        if (PlayerCloseToHeadShop)
        {
            OpenText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenText.SetActive(false);
                SceneManager.LoadScene("HeadShop");
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
