using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBuildings : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(player.GetComponent<TimerForPerspective>().gameOverState);
        if (!player.GetComponent<TimerForPerspective>().gameOverState)
        {
            
            if (transform.position.x < 60)
            {
                transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            }

            else
            {
                transform.position = new Vector3(-172, transform.position.y, transform.position.z);
            }
        }
    }
}
