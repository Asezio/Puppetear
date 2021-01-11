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
        UITimeBar.timeLeft = GameObject.Find("TimeLeft").GetComponent<UITimeBar>().timeMax;
        Destroy(gameObject,0.5f);
        Destroy(GetComponent<EnemyFOV>().fieldOfView.gameObject,0.5f);

    }


    IEnumerator TimeRefresh()
    {
        Debug.Log("1");
        UITimeBar.timeLeft = GameObject.Find("TimeLeft").GetComponent<UITimeBar>().timeMax;
        yield return new WaitForSeconds(waitTime);
        Debug.Log("2");
        

    }

}
