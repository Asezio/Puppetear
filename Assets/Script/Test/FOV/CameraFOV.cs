using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFOV : EnemyFOV
{
    public float rotateSpeed;
    protected override void HandleMovement()
    {
        switch (state)
        {
            case State.Waiting:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0f)
                {
                    state = State.Moving;
                }
                break;

            case State.Moving:
               
                
                    float angle = 0;
                    Quaternion target = Quaternion.AngleAxis(angle, Vector3.forward);

                    state = State.Waiting; 
                
                break;
        }
    }
}
