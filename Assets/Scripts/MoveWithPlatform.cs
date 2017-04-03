using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {

        other.transform.parent = gameObject.transform;
    }

    void OnTriggerExit(Collider other)
    {

        other.transform.parent = null;
    }
}
