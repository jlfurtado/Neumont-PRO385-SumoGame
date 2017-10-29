using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillFloor : MonoBehaviour {
    [SerializeField] private GameObject m_gameOverRef;
    [SerializeField] private float m_winCheckDelay;
    [SerializeField] CountDown m_countDown;
    [SerializeField] private float m_shakeStrength;
    [SerializeField] private float m_shakeLength;
    private FollowCenter m_mainCameraRef;
    private PowerUpManager m_powerUpManagerRef;

    private Text m_gameOverText;

    private bool m_p1Hit;
    private bool m_p2Hit;
    private bool m_checking = false;

	// Use this for initialization
	void Awake () {
        m_gameOverText = m_gameOverRef.GetComponentInChildren<Text>();
        m_mainCameraRef = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCenter>();
        m_powerUpManagerRef = GameObject.FindGameObjectWithTag("PowerUpManager").GetComponent<PowerUpManager>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player1"))
        {
            m_p1Hit = true;
            StartCoroutine(CheckWinCondition());
            m_mainCameraRef.BeginShake(m_shakeLength, m_shakeStrength);
        }
        else if (collision.collider.CompareTag("Player2"))
        {
            m_p2Hit = true;
            StartCoroutine(CheckWinCondition());
            m_mainCameraRef.BeginShake(m_shakeLength, m_shakeStrength);
        }
        else if (collision.collider.CompareTag("PowerUp"))
        {
            // SAD FACE TOO MUCH LAZINESS TO CACHE
            m_powerUpManagerRef.CollectAt(collision.gameObject.GetComponent<PowerUp>().GetIdx());
        }
    }

    private IEnumerator CheckWinCondition()
    {
        if (!m_checking)
        {
            m_checking = true;

            m_countDown.StartCountDown(m_winCheckDelay);
            yield return new WaitForSeconds(m_winCheckDelay);

            PauseManager.OnlyOne.Pause();
            m_gameOverRef.SetActive(true);
            m_gameOverText.text = (m_p1Hit) ? (m_p2Hit ? "Draw!" : "P1 Wins!") : (m_p2Hit ? "P2 Wins!" : "THIS IS A BUG!");

            m_checking = false;
        }
       
    }
}
