using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindParticles : MonoBehaviour {

    private ParticleSystem part;
    private bool yes;
    private bool start;

    // Use this for initialization
    void Start ()
    {
        yes = true;
        start = false;
        part = gameObject.GetComponent<ParticleSystem>();
        part.Stop();
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log("yes: " + yes + " spinVar " + gameObject.transform.parent.GetComponentInChildren<FanSpin>().spinVar);
        if (gameObject.transform.parent.GetComponentInChildren<FanSpin>().spinVar && yes)
        {
            StartCoroutine(delay());
        }

        else if (gameObject.transform.parent.GetComponentInChildren<FanSpin>().spinVar && start)
        {
            
            part.Play();
        }
        else
        {
            part.Stop();
            start = false;
        }

        
	}

    IEnumerator delay()
    {
        //Debug.Log("hey d'ere");
        yes = false;
        yield return new WaitForSeconds(1.5f);
        start = true;
        yes = true;
    }

}
