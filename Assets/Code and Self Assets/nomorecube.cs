using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nomorecube : MonoBehaviour {

    public GameObject explosive;
    public GameObject prevGameO;
    public Text scoreText;
    public AudioSource explode;
    

    int score = 0;
    int sameShip = 0;
    // Use this for initialization
    void Start () {
        scoreText.text = "Score: " + score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnParticleCollision(GameObject other)
    {
        
       
        if (other.gameObject.tag == "EnemyShip")
        {   
            if (prevGameO == other)
            {
                sameShip++;
            }
            else
            {
                sameShip = 0;
            }
            //debug
            print("boomboom");
            print(other);
            print (sameShip);

            if (sameShip > 2)
            //instantiate explosion
            {
                score++;
                scoreText.text = "Score: " + score;
                Instantiate(explosive, other.transform.position, other.transform.rotation);
                Destroy(other);
                Destroy(other.transform.parent.gameObject);
                explode.Play();
            }
            
            prevGameO = other;
        }
    }

    

}
