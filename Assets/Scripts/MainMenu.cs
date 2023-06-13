using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Scene scene;

    [SerializeField] private string sceneName;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (sceneName != "Exit")
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (sceneName == "Options")
        {
            
        }
        else
            Application.Quit();
    }
}
