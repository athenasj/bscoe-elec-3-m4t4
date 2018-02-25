using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {

        print("col test");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void OnTriggerEnter(Collider collide)
    {
        print(collide);
        //print("word");
        //Destroy(other.gameObject);
    }    
   
}
