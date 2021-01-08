using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : WeaponBase
{
    public bool isHaveThing;
    // Start is called before the first frame update
    void Start()
    {
        isHaveThing = false;
    }

    // Update is called once per frame
    void Update()
    {
        DetectItem();
    }
}
