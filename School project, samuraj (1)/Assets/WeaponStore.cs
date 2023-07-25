using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WeaponStore : MonoBehaviour
{
    [SerializeField] public GameObject MoneyText;
    [SerializeField] public GameObject ShurikenText;
    Money money;
    Player player;
    public AudioSource ac;
    ThrowingStar shuriken;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        money = GameObject.Find("Money").GetComponent<Money>();
    }
    private void Start()
    {
        player.InAStore = true;
    }
    void Update()
    {
        MoneyText.GetComponent<Text>().text = money.AmountMoney + " €";
        ShurikenText.GetComponent<Text>().text = player.ThrowingStarAmount + " shurikens left";
    }

    public void BuyShurikens()
    {
        if (money.AmountMoney > 0)
        {
            money.AmountMoney -= 1;
            player.ThrowingStarAmount += 3;
        }
        else
        {
            ac.Play();
        }
    }
    public void BuyDMG()
    {
        if (money.AmountMoney > 14)
        {
            player.ShurikenDMG += 1;
            money.AmountMoney -= 14;
        }
        else
        {
            ac.Play();
        }
    }
    public void Exit()
    {
        SceneManager.LoadScene("Birmingham");
        player.InAStore = false;
        transform.position = new Vector2(9.781f, -1.65f);
    }
}
