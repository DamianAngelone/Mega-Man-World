using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine;
using System.Collections;

public class TranslatingPlatform : MonoBehaviour
{
    private float Zpos;
    private bool max;
    private bool check = true;
    public int maxAmount;
    public float step;

    // Use this for initialization
    void Start()
    {
        Zpos = transform.position.z;
    }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Round(transform.position.z, 2) == Math.Round(Zpos, 2))
        {
            check = true;
        }
        else
        {
            check = false;
        }

        if ((transform.position.z >= Zpos + maxAmount || transform.position.z <= Zpos + -maxAmount) && !check)
        {
            max = true;
            check = false;
        }
        else if ((transform.position.z >= Zpos) && check)
        {
            max = false;
        }

        if (!max)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + step);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - step);
        }
    }
}