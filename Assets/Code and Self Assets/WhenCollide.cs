﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WhenCollide : MonoBehaviour {

    // public GameObject explodeEffect;
    int bump;

	// Use this for initialization
	void Start () {
        transform.GetChild(0).gameObject.SetActive(false);
        print("col test");
        bump = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void OnTriggerEnter(Collider collide)
    {
        print(bump);
        bump++;
        if (bump > 3)
        {
            print(collide);
            transform.GetChild(0).gameObject.SetActive(true);
            SceneManager.LoadScene("Level 0");
        }
        //Instantiate(explodeEffect, transform.position, transform.rotation);
        //print("word");
        //Destroy(other.gameObject);
    }

}
