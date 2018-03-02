using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
        Invoke("LoadGameScene", 22f);
	}
	
	void LoadGameScene()
    {
        SceneManager.LoadScene(2);
    }
}
