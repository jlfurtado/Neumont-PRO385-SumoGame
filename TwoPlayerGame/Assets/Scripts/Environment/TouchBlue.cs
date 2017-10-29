using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBlue : MonoBehaviour {
    [SerializeField] private SpringMech m_myParent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            m_myParent.Toggle();
        }
    }
}
