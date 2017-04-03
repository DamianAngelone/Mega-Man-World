using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    private float Ypos;
    public AudioSource propSpin;
    public GameObject EleSwitch;

	// Use this for initialization
	void Start () {

        Ypos = 20.55f;
        propSpin.Play();
    }
	
	// Update is called once per frame
	void Update () {

        if (EleSwitch.GetComponent<ShootEleButton>().on && transform.position.y < Ypos && EleSwitch.GetComponent<ShootEleButton>().firstShot)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.025f, transform.position.z);
        }
        else if(!EleSwitch.GetComponent<ShootEleButton>().on && transform.position.y > 2.55 && EleSwitch.GetComponent<ShootEleButton>().firstShot)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.025f, transform.position.z);
        }

        if (!propSpin.isPlaying)
        {
            propSpin.Play();
        }
    }
}
