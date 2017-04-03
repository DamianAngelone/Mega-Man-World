using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public AudioSource activationSound;
    public Material activated;
    bool active = true;

	// Use this for initialization
	void Start () {
        //Debug.Log(gameObject.tag);
    }
	
	// Update is called once per frame
	void Update () {
		
        
	}

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if(col.gameObject.tag == "fpBullet")
        {

            if (gameObject.tag == "Blue Switch") {
                foreach (GameObject gO in GameObject.FindGameObjectsWithTag("Blue Door"))
                {
                    Destroy(gO.transform.parent.gameObject);
                    //Debug.Log("Hit Blue!");
                    Destroy(gO);
                }
            }
            else if (gameObject.tag == "Red Switch")
            {
                foreach (GameObject gO in GameObject.FindGameObjectsWithTag("Red Door"))
                {
                    //Debug.Log("Hit Red!");
                    Destroy(gO);
                }
            }

            else if (gameObject.tag == "Yellow Switch")
            {
                foreach (GameObject gO in GameObject.FindGameObjectsWithTag("Yello Door"))
                {
                    //Debug.Log("Hit Yellow!");
                    Destroy(gO);
                }
            }

            if (active)
            {
                activationSound.Play();
                GetComponent<Renderer>().material = activated;
                active = false;
            }
                
        }

    }
}
