using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SaveObject : MonoBehaviour
{
    static private SaveObject instance; //Singleton Implementation 

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
}
