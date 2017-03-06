using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePOV : MonoBehaviour {

    public GameObject player;
    public GameObject ssCAM;
    public GameObject fpCAM;
    public bool check;

    // Use this for initialization
    void Start () {

        fpCAM.gameObject.active = false;
        ssCAM.gameObject.active = true;
        check = true;
  
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1) && !gameObject.GetComponent<Movement>().isMoving && !gameObject.GetComponent<Movement>().isJumping && GetComponent<Movement>().perspectiveSwitchValid && !GetComponent<TimerForPerspective>().gameOverState && !GetComponent<TimerForPerspective>().winState && !GetComponent<Movement>().inCutscene)
        {
            if (check)
            {
                ssCAM.gameObject.active = false;
                fpCAM.gameObject.active = true;
            }
            else
            {
                fpCAM.gameObject.active = false;
                ssCAM.gameObject.active = true;

            }

            check = !check;
        }
	}
}
