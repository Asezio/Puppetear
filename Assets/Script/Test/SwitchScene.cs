using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collObject )
    {
        if (collObject.GetComponent<Player_Controller>() != null)
        {
            SceneManager.LoadScene(2);
        }
        else { }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
