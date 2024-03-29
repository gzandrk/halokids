﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private static BGM bgm;

    void Awake()
    {
        if (bgm == null)
        {
            bgm = this;
            DontDestroyOnLoad(bgm);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
