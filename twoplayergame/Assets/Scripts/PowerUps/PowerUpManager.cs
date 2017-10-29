using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    public GameObject[] powerUpPrefabList;
    public const int MAX_POWERUPS = 10;

    private GameObject[] powerUps = new GameObject[MAX_POWERUPS];
    private int powerUpTracker = 0;

	// Use this for initialization
	void Start () {
		for(int j = 0; j < MAX_POWERUPS;) {
            powerUps[j] = Instantiate(GetRandomPrefab(), this.transform);
            powerUps[j].SetActive(false);
        }
	}

    GameObject GetRandomPrefab() {
        return powerUpPrefabList[Random.Range(0, powerUpPrefabList.Length)];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
