using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateVector : MonoBehaviour
{
    [SerializeField] Vector3 aimDirection;
    [SerializeField] float rotateSpeed;
    Quaternion dirRot;
    Quaternion target;
    protected Vector3 lastMoveDir;
    Vector3 toMoveDir;
    [SerializeField] float angle = 90;

    // Start is called before the first frame update
    void Start()
    {
        dirRot = Quaternion.identity;
        lastMoveDir = aimDirection;
        StartCoroutine(rotate());

    }

    // Update is called once per frame
    void Update()
    {
        //lastMoveDir = Quaternion.AngleAxis(90, Vector3.forward) * lastMoveDir;


        Debug.DrawLine(transform.position, transform.position + GetAimDir() * 10f);



    }

    IEnumerator rotateCamara()
    {
        while(true)
        {
            lastMoveDir = Quaternion.AngleAxis(-90*Time.deltaTime, Vector3.forward) * lastMoveDir;
            yield return StartCoroutine(rotate());
        }
    }

    IEnumerator rotate()
    {
       
            lastMoveDir = Quaternion.AngleAxis(90*Time.deltaTime, Vector3.forward) * lastMoveDir;
            yield return null;
        
    }
    public Vector3 GetAimDir()
    {
        return lastMoveDir;
    }

    public float GetSide()
    {
        return Mathf.Sign(transform.localScale.x);
    }
}
