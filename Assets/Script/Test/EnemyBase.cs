using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float speed;
    protected SpriteRenderer sr;
    public float waitTime;


    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    public void Die()
    {
        Destroy(gameObject,0.5f);
    }



}
