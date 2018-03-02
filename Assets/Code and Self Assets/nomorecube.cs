using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nomorecube : MonoBehaviour {

    public GameObject explosive;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnParticleCollision(GameObject other)
    {
        
       
        if (other.gameObject.tag == "EnemyShip")
        {
            //debug
            print("boomboom");
            print(other);

            //instantiate explosion
            Instantiate(explosive, other.transform.position, other.transform.rotation);
            Destroy(other);
            Destroy(other.transform.parent.gameObject);
        }
    }

    

}
