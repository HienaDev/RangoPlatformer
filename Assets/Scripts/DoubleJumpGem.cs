using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpGem : Interactable
{
    protected override bool PickupObject(PlayerMove player)
    {
        player.SetMaxJumps(2);

        return true;
    }
}
