using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    protected PlayerController p1;
    protected PlayerController p2;
    protected PowerUpManager m_myManager;
    protected int m_myManagerIndex;
    protected Rigidbody m_myRigidBody;

    protected virtual void Awake()
    {
        m_myRigidBody = GetComponent<Rigidbody>();
        p1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerController>();
        p2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();
    }

    public int GetIdx()
    {
        return m_myManagerIndex;
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
            CauseEffect(p1);
            m_myManager.CollectAt(m_myManagerIndex);
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            CauseEffect(p2);
            m_myManager.CollectAt(m_myManagerIndex);
        }
    }

    public void StopMoving()
    {
        MyHelperFuncs.StopRigid(m_myRigidBody);
        MyHelperFuncs.StartRigid(m_myRigidBody);
    }

    public void MoveABit()
    {
        m_myRigidBody.AddForce(Random.onUnitSphere);
    }

    public virtual void CauseEffect(PlayerController player) { }
}
