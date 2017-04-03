using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBehaviour : MonoBehaviour {

    private bool activeWind;
    private bool canIncr = true;
    private bool start = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        activeWind = gameObject.transform.parent.GetComponentInChildren<FanSpin>().spinVar;

    }

    void OnTriggerStay(Collider other)
    {

        if(activeWind && canIncr)
        {
            StartCoroutine(Waiting());
        }

        if (activeWind && start)
        {     
            other.GetComponent<Rigidbody>().AddForce(transform.up * 0.75f, ForceMode.Impulse);
        }
        else
        {
            start = false;
        }
        //Debug.Log(activeWind);
    }

    IEnumerator Waiting()
    {
        canIncr = false;
        start = true;
        yield return new WaitForSeconds(1.5f);
        
        canIncr = true;
    }
}
