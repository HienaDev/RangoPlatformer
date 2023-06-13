using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreMNG : MonoBehaviour
{


    static private ScoreMNG instance; //Singleton Implementation 

    // Start is called before the first frame update
    private void Start()
    {

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;


        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //if(SceneManager.GetActiveScene().name == "Main Menu")
            //{
            //    SaveObject temp = GameObject.FindObjectOfType<SaveObject>();
            //    Destroy(temp);
            //}
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
