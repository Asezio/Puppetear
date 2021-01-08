using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{

    public float speed;
    ////private float raycastDistance = 0.1f;
    ////public float raycastOffsetX;
    //We create these variables up top, and assign them in Awake
    //This is a professional way of storing a reference to Components
    protected Rigidbody2D rb;
    ////Animator anim;
    protected SpriteRenderer sr;
    protected Animator anim;
    public Transform trans;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();

    }

    //make it protected so we can call it from playercontroller and AIcontroller

        //翻转
    protected void Flip(float DirectionX)
    {
        if (DirectionX < 0)
        {
            sr.flipX = false;
            GameObject.Find("ItemRoot").GetComponent<Transform>().localEulerAngles = new Vector3(0, 0, 0);
        }
        if (DirectionX > 0)
        {
            sr.flipX = true;
            GameObject.Find("ItemRoot").GetComponent<Transform>().localEulerAngles = new Vector3(0, 180, 0);
        }

    }

    protected void Move(float DirectionX, float DirectionY)

    {
        //flip the sprite based on the direction this unit is moving



        //setting the velocity to move our character
        //keep the y-velocity at it original value

        rb.velocity = new Vector2(DirectionX * speed, DirectionY * speed);
        anim.SetFloat("Speed", Mathf.Abs(DirectionX)+Mathf.Abs(DirectionY));
        //send current movement to the animator
        //this way,the animator can handle which animation to play 
        //send the absolute direction
        //because our animator needs positive numbers for the transition

        ////anim.SetFloat("Speed", Mathf.Abs(direction));
    }


    //选择武器，根据输入选择启用武器，并禁用其余武器，若不可用则无法选择
    protected void WeaponSwitch()
    {
        if (Input.GetButtonDown("Weapon1"))
        {
            GameObject.Find("Weapon1").GetComponent<Weapon1>().enabled = true;
            GameObject.Find("Weapon2").GetComponent<Weapon2>().enabled = false;
            GameObject.Find("Weapon3").GetComponent<Weapon3>().enabled = false;
            GameObject.Find("Weapon4").GetComponent<Weapon4>().enabled = false;
            anim.SetBool("Weapon1", true);
            anim.SetBool("Weapon2", false);
            anim.SetBool("Weapon3", false);
            anim.SetBool("Weapon4", false);
        }
        if (Input.GetButtonDown("Weapon2"))
        {
            if (GameObject.Find("Weapon2").GetComponent<Weapon2>().isAvailable==true)
            {
                GameObject.Find("Weapon1").GetComponent<Weapon1>().enabled = false;
                GameObject.Find("Weapon2").GetComponent<Weapon2>().enabled = true;
                GameObject.Find("Weapon3").GetComponent<Weapon3>().enabled = false;
                GameObject.Find("Weapon4").GetComponent<Weapon4>().enabled = false;
                anim.SetBool("Weapon1", false);
                anim.SetBool("Weapon2", true);
                anim.SetBool("Weapon3", false);
                anim.SetBool("Weapon4", false);
            }
        }
        if (Input.GetButtonDown("Weapon3"))
        {
            if (GameObject.Find("Weapon3").GetComponent<Weapon3>().isAvailable == true)
            {
                GameObject.Find("Weapon1").GetComponent<Weapon1>().enabled = false;
                GameObject.Find("Weapon2").GetComponent<Weapon2>().enabled = false;
                GameObject.Find("Weapon3").GetComponent<Weapon3>().enabled = true;
                GameObject.Find("Weapon4").GetComponent<Weapon4>().enabled = false;
                anim.SetBool("Weapon1", false);
                anim.SetBool("Weapon2", false);
                anim.SetBool("Weapon3", true);
                anim.SetBool("Weapon4", false);
            }
                
        }
        if (Input.GetButtonDown("Weapon4"))
        {
            if (GameObject.Find("Weapon3").GetComponent<Weapon3>().isAvailable == true)
            {
                GameObject.Find("Weapon1").GetComponent<Weapon1>().enabled = false;
                GameObject.Find("Weapon2").GetComponent<Weapon2>().enabled = false;
                GameObject.Find("Weapon3").GetComponent<Weapon3>().enabled = false;
                GameObject.Find("Weapon4").GetComponent<Weapon4>().enabled = true;
                anim.SetBool("Weapon1", false);
                anim.SetBool("Weapon2", false);
                anim.SetBool("Weapon3", false);
                anim.SetBool("Weapon4", true);
            }
                
        }

    }
}
