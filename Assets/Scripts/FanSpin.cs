using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpin : MonoBehaviour {

    public Animator anim;
    public AudioSource spinningSound;
    public GameObject trafficLight;

    public bool spinVar = false;
    private bool check = true;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!trafficLight.GetComponent<TrafficLight>().delay ? 
            (trafficLight.GetComponent<TrafficLight>().timer >= 5 || trafficLight.GetComponent<TrafficLight>().timer < 0 ) :
            (trafficLight.GetComponent<TrafficLight>().timer >= 1 && trafficLight.GetComponent<TrafficLight>().timer < 4))
        {
            spinVar = true;
        }
        else
        {
            spinVar = false;
        }

        if (spinVar && check)
        {
            spinningSound.Play();
            anim.SetTrigger("start");
            check = false;
        }
        else if (!spinVar && !check)
        {
            anim.SetTrigger("stop");
            check = true;
            spinningSound.Stop();
        }
    }
}
