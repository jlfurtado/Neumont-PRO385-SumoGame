using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {
    [SerializeField] private string ScenetoLoad;
    public void Restart()
    {
        SceneManager.LoadScene(ScenetoLoad);
    }
}
