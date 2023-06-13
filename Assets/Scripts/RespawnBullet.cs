using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(gameObject);
    }
}
