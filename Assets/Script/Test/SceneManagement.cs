using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private int count = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (UITimeBar.timeLeft<=0)
        {
            Restart();
        }
    }

    public void NextLevel()
    {
        count++;
        SceneManager.LoadScene(count);

    }

    public void Restart()
    {
        SceneManager.LoadScene(count);
    }
}
