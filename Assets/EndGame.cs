using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        print(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnEnable()
    {
        SceneManager.LoadScene(3);
        print("gameend");
    }
}
