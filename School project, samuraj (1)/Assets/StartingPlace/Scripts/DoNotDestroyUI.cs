﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyUI : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
