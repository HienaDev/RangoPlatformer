using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotAvailableUI : MonoBehaviour
{
    private PlayerMove player;
    private UnityEngine.UI.Image oneShotcolor;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerMove>();

        oneShotcolor = gameObject.GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.GetOneShotPower())
            oneShotcolor.color = Color.white;
        else
            oneShotcolor.color = Color.grey;
    }
}
