using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player2Controller : MonoBehaviour {
    [SerializeField] [Range(0.0f, 1000.0f)] private float Speed = 10.0f;

    private Rigidbody myRigidBody;

    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseManager.OnlyOne.Paused()) { StopMoving(); return; }
        float dx = (Input.GetKey(KeyCode.LeftArrow) ? -1.0f : 0.0f) + (Input.GetKey(KeyCode.RightArrow) ? 1.0f : 0.0f);
        float dz = (Input.GetKey(KeyCode.UpArrow) ? 1.0f : 0.0f) + (Input.GetKey(KeyCode.DownArrow) ? -1.0f : 0.0f);

        myRigidBody.AddForce(new Vector3(dx, 0.0f, dz) * Speed);
    }

    private void StopMoving()
    {
        myRigidBody.velocity = Vector3.zero;
    }
}
