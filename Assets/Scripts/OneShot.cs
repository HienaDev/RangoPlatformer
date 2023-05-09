using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShot : Interactable
{
    protected override bool PickupObject(PlayerMove player)
    {
        player.SetOneShotPower(true);

        return (true);
    }


}
