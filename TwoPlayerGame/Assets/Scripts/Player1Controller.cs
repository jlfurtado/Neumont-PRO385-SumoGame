using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player1Controller : MonoBehaviour {
    [SerializeField] [Range(0.0f, 1000.0f)] private float Speed = 10.0f;

    private Rigidbody myRigidBody;

	// Use this for initialization
	void Awake () {
        myRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (PauseManager.OnlyOne.Paused()) { StopMoving(); return; }
        float dx = (Input.GetKey(KeyCode.A) ? -1.0f : 0.0f) + (Input.GetKey(KeyCode.D) ? 1.0f : 0.0f);
        float dz = (Input.GetKey(KeyCode.W) ? 1.0f : 0.0f) + (Input.GetKey(KeyCode.S) ? -1.0f : 0.0f);

        myRigidBody.AddForce(new Vector3(dx, 0.0f, dz) * Speed);
    }

    private void StopMoving()
    {
        myRigidBody.velocity = Vector3.zero;
    }
}
