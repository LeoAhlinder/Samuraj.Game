using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public float AmountMoney = 0;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        
    }
}
