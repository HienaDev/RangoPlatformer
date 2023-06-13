using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollision : MonoBehaviour
{
    [SerializeField] private LayerMask destroyableLayer;
    [SerializeField] private LayerMask bouncyLayer;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        

        int x = 1 << collision.gameObject.layer;



        if (x == destroyableLayer.value)
            Destroy(collision.gameObject);

        if (!(x == bouncyLayer.value))
            Destroy(gameObject);
        else
            audioSource.Play();
            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        int x = 1 << collision.gameObject.layer;



        if (x == destroyableLayer.value)
            Destroy(collision.gameObject);
    }
}
