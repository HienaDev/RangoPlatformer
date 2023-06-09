using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextLevel : Interactable
{

    [SerializeField] private Scene scene;

    [SerializeField] private string sceneName;



    protected override bool PickupObject(PlayerMove player)
    {
        SceneManager.LoadScene(sceneName);

        return true;
    }
}
