using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnLand : MonoBehaviour {
    private FollowCenter m_mainCameraRef;
    [SerializeField] private float m_shakeStrength;
    [SerializeField] private float m_shakeLength;

    private void Awake()
    {
        m_mainCameraRef = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCenter>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            m_mainCameraRef.BeginShake(m_shakeLength, m_shakeStrength);
        }
    }
}
