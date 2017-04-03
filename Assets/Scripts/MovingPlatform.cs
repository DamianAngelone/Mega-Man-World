using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingPlatform : MonoBehaviour
{
    private float Xpos;
    private float Ypos;
    private bool max;
    private bool check = true;
    public bool Vert;
    public int maxAmount;
    public float step;

    void Start()
    {
        Xpos = transform.position.x;
        Ypos = transform.position.y;
    }
    void Update()
    {
        if (Vert)
        {
            if (Math.Round(transform.position.y, 1) == Math.Round(Ypos, 1))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if ((transform.position.y >= Ypos + maxAmount || transform.position.y <= Ypos + -maxAmount) && !check)
            {
                max = true;
                check = false;
            }
            else if ((transform.position.y >= Ypos) && check)
            {
                max = false;
            }
        }   
        else
        {

            if (Math.Round(transform.position.x, 2) == Math.Round(Xpos, 2))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            
            if ((transform.position.x >= Xpos + maxAmount || transform.position.x <= Xpos + -maxAmount) && !check)
            {
                max = true;
                check = false;
            }
            else if ((transform.position.x >= Xpos) && check)
            {
                max = false;
            }
        }
        
        if (Vert)
        {
            if (!max)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + step, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - step, transform.position.z);
            }
        }
        else
        {
            if (!max)
            {
                transform.position = new Vector3(transform.position.x + step, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - step, transform.position.y, transform.position.z);
            }
        }
    }

    float absValue(float number)
    {
        number = number < 0 ? number *= -1 : number;
        return number; 
    }

}
