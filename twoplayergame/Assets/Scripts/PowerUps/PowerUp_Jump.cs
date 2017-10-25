using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PowerUp_Jump : PowerUp
{
    [SerializeField] [Range(0.0f, 1000.0f)] private float jumpForce = 500.0f;

    public override void CauseEffect(Rigidbody otherRigidBody)
    {
        otherRigidBody.AddForce(new Vector3(0.0f, jumpForce, 0.0f));
        this.gameObject.SetActive(false);
    }
}
