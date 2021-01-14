using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public string itemName;
    public SpriteRenderer sr;
    protected Transform targetTrans;
    protected Transform playerTrans;
    private bool isStick;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        targetTrans = GameObject.Find("ItemPoint").GetComponent<Transform>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isStick = false;
    }
    protected void MoveTo()
    {
        if (GameObject.Find("Weapon2").GetComponent<Weapon2>().enabled == true)
        {
            bool isHaveThing = GameObject.Find("Weapon2").GetComponent<Weapon2>().isHaveThing;
            if (Input.GetMouseButtonDown(0))
            {

                if (isHaveThing == false)
                {
                    StartCoroutine(MoveTawords(transform, targetTrans.position, 0.5f));
                    GameObject.Find("Weapon2").GetComponent<Weapon2>().isHaveThing = true;
                }
                else
                {
                    StartCoroutine(Drop(transform, new Vector3(transform.position.x, playerTrans.position.y, transform.position.z), 0.5f));
                    GameObject.Find("Weapon2").GetComponent<Weapon2>().isHaveThing = false;
                    isStick = false;
                }
            }
        }
    }

    private IEnumerator MoveTawords(Transform tr, Vector3 pos, float time)
    {
        float t = 0;
        
        while (true)
        {
            t += Time.deltaTime;
            float a = t / time;
            tr.position = Vector3.Lerp(tr.position, pos, a);
            if (a >= 1.0f)
                break;
            yield return null;
        }
        isStick = true;


    }


    private IEnumerator Drop(Transform tr, Vector3 pos, float time)
    {
        float t = 0;

        while (true)
        {
            t += Time.deltaTime;
            float a = t / time;
            tr.position = Vector3.Lerp(tr.position, pos, a);
            if (a >= 1.0f)
                break;
            yield return null;
        }
        // Update is called once per frame

    }
    protected void Stick()
    {
        if (isStick == true)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            transform.position = targetTrans.position;
            if(GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipX==false)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }

        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }

}
