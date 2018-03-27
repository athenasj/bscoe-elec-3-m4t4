using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGameScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LoadGameScene", 22f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadGameScene()
    {
        SceneManager.LoadScene(2);
    }
}
