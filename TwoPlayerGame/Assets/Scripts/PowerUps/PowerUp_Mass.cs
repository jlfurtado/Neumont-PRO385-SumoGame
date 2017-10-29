using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Mass : PowerUp {
    [SerializeField] private float m_massMultiplier;
    [SerializeField] private float m_massTime;

    public override void CauseEffect(PlayerController player)
    {
        player.GetRigidbody().mass += m_massMultiplier;
        player.transform.localScale = Vector3.one * Mathf.Pow(player.GetRigidbody().mass, 1.0f / 3.0f); // only works for cubes
        player.ResetMass(m_massTime);
    }
}
