using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEleButton : MonoBehaviour
{

    public Material matRed;
    public Material matGreen;
    public bool on = true;
    public bool firstShot;

    // Use this for initialization
    void Start()
    {
        firstShot = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "fpBullet")
        {
            if (!firstShot)
                firstShot = !firstShot;

            if (!on)
            {
                GetComponent<Renderer>().material = matGreen;
                on = true;
            }

            else
            {
                GetComponent<Renderer>().material = matRed;
                on = false;
            }
        }
    }
}
