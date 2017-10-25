using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (PauseManager.OnlyOne.Paused()) { PauseManager.OnlyOne.UnPause(); }
            else { PauseManager.OnlyOne.Pause(); }
        }
	}
}
