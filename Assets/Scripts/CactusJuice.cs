using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusJuice : Interactable
{
    protected override bool PickupObject(PlayerMove player)
    {
        player.SetCactusPower(true);

        return (true);
    }
}
