using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : BaseUnit

{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //控制水平移动方向 A:-1 D:-1 不按键：0
        float directionX = Input.GetAxisRaw("Horizontal");
        
        //控制垂直移动方向 S:-1 W:-1 不按键：0
        float directionY = Input.GetAxisRaw("Vertical");

        Move(directionX,directionY);
        Flip(directionX);
        //Vector2 position = transform.position;
        //position.x += moveX * Time.deltaTime;
        //position.y += moveY * Time.deltaTime;
        //transform.position = position;
    }




}
