﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : WeaponBase
{
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        isAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        DetectEnemy();
    }


}