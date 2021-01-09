using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIweapon : MonoBehaviour
{
    public Text coolDownText;
    private float coolDownTime;
    private float timer;

    //public bool isActive;

    public Image WeaponImage;
    public Image WeaponImageGrey;

    // Start is called before the first frame update
    void Awake()
    {
        coolDownText.enabled = false;
        if(gameObject.name==("UI_Weapon1"))
        {
            WeaponImageGrey.enabled = false;
        }
    }

    // Update is called once per frame

    public void Cooldown1()
    {
        if(BaseUnit.isWeapon1Active==false)
        {
            if (coolDownText.enabled == false || WeaponImageGrey.enabled == false)
            {
                coolDownText.enabled = true;
                WeaponImageGrey.enabled = true;
                coolDownTime = GameObject.Find("Weapon1").GetComponent<WeaponBase>().cooldown;
                timer = coolDownTime;
            }


            timer -= Time.deltaTime;
            WeaponImageGrey.fillAmount = timer / coolDownTime;
            coolDownText.text = timer.ToString();
            //Debug.Log("233");
            if (timer <= 0f)
            {
                timer = 0f;
                coolDownText.enabled = false;
                WeaponImageGrey.enabled = false;
                BaseUnit.isWeapon1Active = true;
            }
        }
    }

   
}
