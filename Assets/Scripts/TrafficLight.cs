using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour {

    public bool greenLight;
    public bool redLight;
    public bool yellowLight;
    public int timer;
    public bool delay = false;

    private bool canIncr = true;

    // Use this for initialization
    void Start () {

        timer = 0;

	}
	
	// Update is called once per frame
	void Update () {

        if (canIncr)
        {
            if (timer == 8)
            {
                timer = 0;
                StartCoroutine(Waiting());
            }
            else
            {
                timer++;
                StartCoroutine(Waiting());
            }
        }
        //Debug.Log(timer);

        if(timer == (delay ? 1 : 5))
        {
            makeGreen();
        }

        else if (timer == (delay ? 3 : 7))
        {
            makeYellow(); 
        }

        else if (timer == (delay ? 4 : 0))
        {
            makeRed();
        }

    }

    void makeGreen()
    {
        greenLight = true;
        redLight = false;
        yellowLight = false;
    }

    void makeRed()
    {
        greenLight = false;
        redLight = true;
        yellowLight = false;
    }

    void makeYellow()
    {
        greenLight = false;
        redLight = false;
        yellowLight = true;
    }
   
    IEnumerator Waiting()
    {
        canIncr = false;
        yield return new WaitForSeconds(1);
        canIncr = true;
    }
}
