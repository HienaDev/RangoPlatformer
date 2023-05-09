using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusAvailableUI : MonoBehaviour
{

    private PlayerMove player;
    private UnityEngine.UI.Image cactusColor;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerMove>();

        cactusColor = gameObject.GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.GetCactusPower())
            cactusColor.color = Color.white;
        else
            cactusColor.color = Color.grey;
    }
}
