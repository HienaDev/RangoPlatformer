using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public abstract class Interactable : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerMove player = collision.GetComponent<PlayerMove>();
        if (player != null)
        {
            if (PickupObject(player))
            {
                Destroy(gameObject);
            }
            Debug.Log("Collided with gem");
        }

        
    }

    abstract protected bool PickupObject(PlayerMove player);
}
