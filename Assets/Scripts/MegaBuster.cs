using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaBuster : MonoBehaviour {

    public GameObject megaBuster;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<TimerForPerspective>().winState || GetComponent<TimerForPerspective>().gameOverState || GetComponent<Movement>().inCutscene || !GetComponent<Movement>().checkPOV) {
            megaBuster.SetActive(false);
        }
        else
        {
            megaBuster.SetActive(true);
        }
	}
}
