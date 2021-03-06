﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PowerUp_Jump : PowerUp
{
    [SerializeField] [Range(0.0f, 1000.0f)] private float jumpForce = 500.0f;

    public override void CauseEffect(PlayerController player)
    {
        player.GetRigidbody().AddForce(new Vector3(0.0f, jumpForce * player.GetRigidbody().mass, 0.0f));
    }
}
