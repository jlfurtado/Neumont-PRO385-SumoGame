using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {
    // MUST BE SAME LENGTH
    [SerializeField] private PowerUp[] m_powerUpPrefabList;
    [SerializeField] private float[] m_powerWeights;

    [SerializeField] private int m_maxPowerUps = 100;
    [SerializeField] private int m_maxFieldPowerUps = 5;
    [SerializeField] private Vector3[] m_spawnPositions;
    [SerializeField] private float m_spawnDelay = 1.0f;

    private PowerUp[] m_powerUps;
    private bool[] m_spawnPositionsOpen;
    private float m_timer;
    private int m_powerUpCount = 0;
    private float[] m_powerThresholds;

    void Awake () {
        if (m_powerWeights.Length != m_powerUpPrefabList.Length) { Debug.Log("ERROR POWERUP AND WEIGHTS MUST HAVE SAME LENGTH!!!"); }

        m_powerThresholds = new float[m_powerWeights.Length];

        float total = m_powerWeights[0];
        for (int i = 1; i < m_powerWeights.Length; ++i) { total += m_powerWeights[i]; }

        m_powerThresholds[0] = m_powerWeights[0] / total;
        for (int i = 1; i < m_powerThresholds.Length; ++i)
        {
            m_powerThresholds[i] = m_powerThresholds[i - 1] + (m_powerWeights[i] / total);
        }

        m_powerUps = new PowerUp[m_maxPowerUps];
        m_spawnPositionsOpen = new bool[m_maxPowerUps];

        for (int j = 0; j < m_maxPowerUps; ++j) {
            m_powerUps[j] = Instantiate(GetRandomPrefab(), this.transform).GetComponent<PowerUp>();
            m_powerUps[j].HookIntoManager(this, "powerup|" + j, j);
            m_powerUps[j].transform.parent = transform;
            m_powerUps[j].transform.localPosition = Vector3.zero;
            m_powerUps[j].gameObject.SetActive(false);
            m_spawnPositionsOpen[j] = true;
        }

        m_timer = m_spawnDelay;
	}

    private GameObject GetRandomPrefab()
    {
        float roll = Random.Range(0.0f, 1.0f);
        for (int i = 0; i < m_powerUpPrefabList.Length; ++i)
        {
            if (roll <= m_powerThresholds[i]) { return m_powerUpPrefabList[i].gameObject; }
        }

        return m_powerUpPrefabList[m_powerUpPrefabList.Length - 1].gameObject; // did i goof?
    }

    private Vector3 GetRandomSpawnPos()
    {
        return m_spawnPositions[Random.Range(0, m_spawnPositions.Length)];
    }
    
    public void CollectAt(int idx)
    {
        --m_powerUpCount;
        m_powerUps[idx].transform.position = Vector3.zero;
        m_powerUps[idx].gameObject.SetActive(false);
        m_powerUps[idx].StopMoving();
        m_spawnPositionsOpen[idx] = true;
    }

    private void Update () {
        if (PauseManager.OnlyOne.Paused()) { return; }

        m_timer -= Time.deltaTime;

        if (m_timer <= 0.0f)
        {
            m_timer += m_spawnDelay;
            SpawnPowerUp();
        }
	}

    private void SpawnPowerUp()
    {
        if (m_powerUpCount < m_maxFieldPowerUps)
        {
            ++m_powerUpCount;

            int firstSlot = 0;
            for (int i = 0; i < m_maxPowerUps; ++i)
            {
                if (m_spawnPositionsOpen[i]) { firstSlot = i; break; }
            }

            m_spawnPositionsOpen[firstSlot] = false;
            PowerUp toAdd = m_powerUps[firstSlot];
            toAdd.gameObject.SetActive(true);
            toAdd.gameObject.transform.position = GetRandomSpawnPos();
            toAdd.MoveABit();
        }
    }
}
