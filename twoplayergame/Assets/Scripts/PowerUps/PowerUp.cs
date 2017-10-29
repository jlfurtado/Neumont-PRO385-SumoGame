using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    protected Rigidbody rigidbody_PlayerOne;
    protected Rigidbody rigidbody_PlayerTwo;
    protected PowerUpManager m_myManager;
    protected int m_myManagerIndex;

    private void Awake()
    {
        rigidbody_PlayerOne = GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody>();
        rigidbody_PlayerTwo = GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody>();
    }

    public void HookIntoManager(PowerUpManager myManagerRef, string name, int idx)
    {
        m_myManager = myManagerRef;
        this.name = name;
        m_myManagerIndex = idx;
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        // TODO:: make better
        if (collision.gameObject.CompareTag("Player1"))
        {
            CauseEffect(rigidbody_PlayerOne);
            m_myManager.CollectAt(m_myManagerIndex);
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            CauseEffect(rigidbody_PlayerTwo);
            m_myManager.CollectAt(m_myManagerIndex);
        }
    }

    public virtual void CauseEffect(Rigidbody otherRigidBody) { }
}
