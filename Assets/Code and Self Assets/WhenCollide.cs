using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class WhenCollide : MonoBehaviour {

    // public GameObject explodeEffect;
    int bump, healthval=3;
    public AudioSource explode;
    AudioSource laser;
    public Text health;

    // Use this for initialization
    void Start () {

        laser = GetComponent<AudioSource>();
        transform.GetChild(0).gameObject.SetActive(false);
        print("col test");
        bump = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void OnTriggerEnter(Collider collide)
    {
        health.text = "Health: " + healthval;
        print(bump);
        bump++;
        if (bump > 3)
        {
            print(collide);
            transform.GetChild(0).gameObject.SetActive(true);
            laser.Stop();
            explode.Play();
            Invoke("LoadGameScene", 1f);

            
        }
        switch (bump)
        {
            case 0:
                healthval = 3;
                break;
            case 1:
                healthval = 2;
                break;
            case 2:
                healthval = 1;
                break;
            case 3:
                healthval = 0;
                break;
        }

        //Instantiate(explodeEffect, transform.position, transform.rotation);
        //print("word");
        //Destroy(other.gameObject);
    }


    void LoadGameScene()
    {
        SceneManager.LoadScene("Level 0");
    }
}
