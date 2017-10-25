using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    protected Rigidbody rigidbody_PlayerOne;
    protected Rigidbody rigidbody_PlayerTwo;

    private void Awake()
    {
        rigidbody_PlayerOne = GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody>();
        rigidbody_PlayerTwo = GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        // TODO:: make better
        if (collision.gameObject.CompareTag("Player1"))
        {
            CauseEffect(rigidbody_PlayerOne);
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            CauseEffect(rigidbody_PlayerTwo);
        }
    }

    public virtual void CauseEffect(Rigidbody otherRigidBody) { }
}
