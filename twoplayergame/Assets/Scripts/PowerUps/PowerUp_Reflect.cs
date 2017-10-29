using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PowerUp_Reflect : PowerUp
{
    
    [SerializeField] [Range(0.0f, 3.0f)] private float scalar = 1.5f;

    public override void CauseEffect(Rigidbody otherRigidBody)
    {
        otherRigidBody.velocity = new Vector3(-otherRigidBody.velocity.x * scalar, -otherRigidBody.velocity.y * scalar, -otherRigidBody.velocity.z * scalar);
        this.gameObject.SetActive(false);
    }
}
