using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WhenCollide : MonoBehaviour {

    // public GameObject explodeEffect;
    int bump;
    public AudioSource explode;
    AudioSource laser;

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
        print(bump);
        bump++;
        if (bump > 2)
        {
            print(collide);
            transform.GetChild(0).gameObject.SetActive(true);
            laser.Stop();
            explode.Play();
            Invoke("LoadGameScene", 1f);

            
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
