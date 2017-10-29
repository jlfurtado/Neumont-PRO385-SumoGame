using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PowerUp_Phase : PowerUp {

    [SerializeField] [Range(0.0f, 5.0f)] private float m_maxLifeSpan = 2.5f; // how long the power up lasts for

    private bool m_isActive = false;
    private float m_currentLifeSpan = 0.0f;

    private Rigidbody playerToAffect = null;

	void Start () {
		
	}
	
	void Update () {
        // if the player to affect exists
        if (playerToAffect != null)
        {
            // while the power up is active
            if (m_isActive)
            {
                // if the current life span has not exceeded the max lifespan
                if (m_currentLifeSpan < m_maxLifeSpan)
                {
                    // Add to current lifespan
                    m_currentLifeSpan += (1.0f / 60.0f);
                }
                else
                {
                    // Reenable collisions
                    playerToAffect.detectCollisions = true;
                }
            }
        }
	}

    public override void CauseEffect(Rigidbody otherRigidBody)
    {
        // mark object as being affected
        m_isActive = true;
        // disable collisions for the player
        otherRigidBody.detectCollisions = false;
        // disable powerup
        this.gameObject.SetActive(false);
    }
}
