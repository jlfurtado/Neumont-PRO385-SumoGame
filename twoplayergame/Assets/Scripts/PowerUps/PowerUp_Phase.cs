using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PowerUp_Phase : PowerUp {

    [SerializeField] [Range(0.0f, 5.0f)] private float m_maxLifeSpan = 2.5f; // how long the power up lasts for

    private int m_phaseLayer;

	protected override void Awake () {
        base.Awake();
        m_phaseLayer = LayerMask.NameToLayer("Phase");
	}

    public override void CauseEffect(PlayerController player)
    {
        player.gameObject.layer = m_phaseLayer;
        player.GhostMatIfy();
        player.ResetPhase(m_maxLifeSpan);
    }
}
