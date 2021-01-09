using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button startGameButton;
    public Button quitGameButton;
    // Start is called before the first frame update
    void Start()
    {
        startGameButton = transform.Find("StartGameButton").GetComponent<Button>();
        quitGameButton = transform.Find("QuitGameButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }
    

}
