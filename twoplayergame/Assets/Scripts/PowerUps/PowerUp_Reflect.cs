using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PowerUp_Reflect : PowerUp
{
    [SerializeField] [Range(0.0f, 3.0f)] private float scalar = 1.5f;

    public override void CauseEffect(PlayerController player)
    {
        Rigidbody rb = player.GetRigidbody();
        rb.velocity = new Vector3(-rb.velocity.x * scalar, -rb.velocity.y * scalar, -rb.velocity.z * scalar);
        this.gameObject.SetActive(false);
    }
}
