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
        /*
        mousePos = Input.mousePosition;
        //mousePos.x -= Screen.width/2;
        //mousePos.y -= Screen.height / 2;
        mousePos.x /= 2;
        mousePos.y /= 2;

        mousePos.x -= 320;
        mousePos.y -= 180;

        gameObject.transform.position = mousePos;*/

        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos;

        //Debug.Log(mousePos);
        // y = 15 : -160
        // x = 150 : -180
        //if ((mousePos.x < 15 && mousePos.x > -160) 
        //                        && 
        //    ((mousePos.y < 150) && (mousePos.y > -180)))
        //{
        //    gameObject.transform.position = mousePos;
        //}
    }
}
