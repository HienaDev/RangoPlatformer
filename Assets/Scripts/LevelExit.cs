using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : Interactable
{

    [SerializeField] private string nextSceneName;

    protected override bool PickupObject(PlayerMove player)
    {

        SceneManager.LoadScene(nextSceneName);
        return false;
    }
}
