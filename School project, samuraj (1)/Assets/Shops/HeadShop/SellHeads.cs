using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SellHeads : MonoBehaviour
{
    Money money;
    EnemyHeads head;
    public AudioSource ac;
    Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        head = GameObject.Find("EnemyHeads").GetComponent<EnemyHeads>();
        money = GameObject.Find("Money").GetComponent<Money>();
    }
    // Update is called once per frame
    public void SellGoblinHead()
    {
        if (head.GoblinHeads > 0)
        {
            money.AmountMoney += 5;
            head.GoblinHeads -= 1;
        }
        else
        {
            ac.Play();
        }
    }
    public void SellFlyingHead()
    {
        if (head.FlyingHeads > 0)
        {
            money.AmountMoney += 14;
            head.FlyingHeads -= 1;
        }
        else
        {
            ac.Play();
        }
    }
    public void SellSkeletonHead()
    {
        if (head.SkeletonHeads > 0)
        {
            money.AmountMoney += 18;
            head.SkeletonHeads -= 1;
        }
        else
        {
            ac.Play();
        }
    }
    public void SellRedHead()
    {
        Debug.Log("321");
        if (head.RedHeads > 0)
        {
            money.AmountMoney += 35;
            head.RedHeads -= 1;
        }
        else
        {
            ac.Play();
        }
    }
    public void BuyGoblinHead()
    {
        if (money.AmountMoney >= 6)
        {
            money.AmountMoney -= 6;
            head.GoblinHeads += 1;
        }
        else
        {
            ac.Play();
        }
    }
    public void BuyFlyingHead()
    {
        if (money.AmountMoney >= 18)
        {
            money.AmountMoney -= 18;
            head.FlyingHeads += 1;
        }
        else
        {
            ac.Play();
        }
    }
    public void BuySkeletonHead()
    {
        if (money.AmountMoney >= 21)
        {
            money.AmountMoney -= 21;
            head.SkeletonHeads += 1;
        }
        else
        {
            ac.Play();
        }
    }
    public void BuyRedHead()
    {
        if (money.AmountMoney >= 43)
        {
            money.AmountMoney -= 43;
            head.RedHeads += 1;
        }
        else
        {
            ac.Play();
        }
    }
    public void ExitShop()
    {
        GameObject.Find("Player").GetComponent<Player>().InAStore = false;
        SceneManager.LoadScene("Birmingham");
        player.transform.position = new Vector3(0.5575581f, -1.704626f, 0);
    }

}

