using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CountDown : MonoBehaviour {
    private Text myText;
    private float m_timer;
    private bool m_countingDown;

	// Use this for initialization
	void Awake () {
        myText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_countingDown)
        {
            m_timer -= Time.deltaTime;

            if (m_timer <= 0.0f)
            {
                m_timer = 0.0f;
                m_countingDown = false;
                gameObject.SetActive(false);
            }

            UpdateTimeText();
        }
    }

    public void StartCountDown(float time)
    {
        gameObject.SetActive(true);
        m_countingDown = true;
        m_timer = time;
        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        myText.text = m_timer.ToString("0.00");
    }
}
