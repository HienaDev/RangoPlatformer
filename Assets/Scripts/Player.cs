using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Transform playerTransform;
    private SpriteRenderer playerRenderer;

    //[SerializeField] private float cycleTime = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log($"Starting {name}");

        //playerTransform = GetComponent<Transform>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        Vector3 playerPosition = transform.position;
        Color playerColor = playerRenderer.color;

        //playerColor.r += Time.deltaTime / cycleTime;

        //if (playerColor.r > 1.0f)
        //    playerColor.r = 0.0f;

        //playerColor.b += Time.deltaTime / cycleTime;

        //if (playerColor.b > 1.0f)
        //    playerColor.b = 0.0f;

        //playerColor.g += Time.deltaTime / cycleTime;

        //if (playerColor.g > 1.0f)
        //    playerColor.g = 0.0f;

        //playerRenderer.color = new Color(playerColor.r, playerColor.b, playerColor.g, 1.0f);
        
        //Debug.Log($"Updating {name} => Position = {playerPosition} => Color = {playerColor}");
    }
}
