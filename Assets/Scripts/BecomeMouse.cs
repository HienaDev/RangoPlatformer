using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BecomeMouse : MonoBehaviour
{

    private Vector2 mousePos;
    [SerializeField] private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos;

    }
}
