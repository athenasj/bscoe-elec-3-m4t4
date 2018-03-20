using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nomorecube : MonoBehaviour {

    public GameObject explosive;
    public GameObject prevGameO;
    public Text scoreText;
    public AudioSource explode;
    int showEnHealth = 3;
    

    public static int score = 0;
    
	void Update () {
        scoreText.text = "Score: " + score.ToString();
    }
}
