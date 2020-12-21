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
    SpriteRenderer sr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ////anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    //make it protected so we can call it from playercontroller and AIcontroller


    protected void Flip(float DirectionX)
    {
        if (DirectionX < 0)
        {
            sr.flipX = false;
        }
        if (DirectionX > 0)
        {
            sr.flipX = true;
        }

    }

    protected void Move(float DirectionX, float DirectionY)

    {
        //flip the sprite based on the direction this unit is moving



        //setting the velocity to move our character
        //keep the y-velocity at it original value

        rb.velocity = new Vector2(DirectionX * speed, DirectionY * speed);

        //send current movement to the animator
        //this way,the animator can handle which animation to play 
        //send the absolute direction
        //because our animator needs positive numbers for the transition

        ////anim.SetFloat("Speed", Mathf.Abs(direction));
    }
}
