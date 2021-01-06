using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead_Zone : MonoBehaviour
{

    int m_test = 1;
    private void OnTriggerEnter2D(Collider2D oogaboogaboo)
    {
        //Debug.LogError("player colliding here OnTrigger Enter2D");
        if (oogaboogaboo.GetComponent<PlayerController>() != null)
        {
            //Debug.LogError("player colliding here, value pf int mt_test is:"+m_test);
            //SceneManager.LoadScence();
            SceneManager.LoadScene("SampleScene_02");
        }
        else
        {
            //do nothing
        }
    }
    //what do  i want to happen when sth is inside my trigger
    private void OnTriggerStay2D(Collider2D other)
    {

    }
    //what do  i want to happen when sth exit my trigger
    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

}
