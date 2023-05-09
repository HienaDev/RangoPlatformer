using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollision : MonoBehaviour
{
    [SerializeField] private LayerMask destroyableLayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        

        int x = 1 << collision.gameObject.layer;



        if (x == destroyableLayer.value)
            Destroy(collision.gameObject);  
    }
}
