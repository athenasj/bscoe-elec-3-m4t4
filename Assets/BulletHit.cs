using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletHit : MonoBehaviour {

    public int EnemyLife;
    public GameObject explosive;
    public AudioSource explode;
    public Text enemyText;
    int ScoreVal;

    // Use this for initialization
    void Start () {
        if (gameObject.tag == "EnemyShipEasy")
        {
            EnemyLife = 3;
        }
        else if (gameObject.tag == "EnemyShipMedium")
        {
            EnemyLife = 5;
        }
        else if(gameObject.tag == "EnemyShipHard")
        {
            EnemyLife = 7;
        }
        ScoreVal = EnemyLife;
    }


    //when particle hits
    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player") //to make sure that only kalaban particles kill other kalaban
        {
            print("bomobomo");
            print("other:" + other.tag);
            EnemyLife--;
            enemyText.text = "Current Enemy Health: " + EnemyLife;

            if (EnemyLife == 0)
            //instantiate explosion
            {
                Instantiate(explosive, transform.position, transform.rotation);
                Destroy(gameObject);
                explode.Play();
                nomorecube.score += ScoreVal;
                //gameObject.BroadcastMessage("IncreaseScore", ScoreVal);
            }
        }
    }
    
}
