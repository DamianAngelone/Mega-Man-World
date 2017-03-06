using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPmovement : MonoBehaviour {

    public float speed;
    Vector3 direction;

    // Use this for initialization
    void Start () {

        direction = Camera.main.transform.forward;
    }
	
	// Update is called once per frame
	void Update () {
        
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        transform.Translate(direction * Time.deltaTime * speed);
        Destroy(gameObject, 3);
        
    }
}
