using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HeadText : MonoBehaviour
{
    TextMeshProUGUI TextMesh;
    [SerializeField] public GameObject Text; //Goblin Head Text
    [SerializeField] public GameObject FlyingText;
    [SerializeField] public GameObject SkeletonText;
    [SerializeField] public GameObject RedText;
    [SerializeField] public GameObject MoneyText;
    EnemyHeads enemyHeads;
    Money money;
    public float GoblinHeads;
    public float FlyingHeads;
    public float SkeletonHeads;
    public float RedHead;
    private void Awake()
    {
        enemyHeads = GameObject.Find("EnemyHeads").GetComponent<EnemyHeads>();
        money = GameObject.Find("Money").GetComponent<Money>();
    }
    void Update()
    {

        GoblinHeads = enemyHeads.GoblinHeads; FlyingHeads = enemyHeads.FlyingHeads; SkeletonHeads = enemyHeads.SkeletonHeads; RedHead = enemyHeads.RedHeads;
       
        MoneyText.GetComponent<Text>().text = money.AmountMoney + " €";
        Text.GetComponent<Text>().text = GoblinHeads + " Goblin Heads";
        FlyingText.GetComponent<Text>().text = FlyingHeads + " Flying Heads";
        SkeletonText.GetComponent<Text>().text = SkeletonHeads + " Skeleton Heads";
        RedText.GetComponent<Text>().text = RedHead + " Red Heads";
    }
}
