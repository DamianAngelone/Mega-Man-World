using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour {

    private Color baseColor;
    private float emission;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;


        if (gameObject.tag == "Green Light" && gameObject.transform.parent.GetComponent<TrafficLight>().greenLight)
        {
            baseColor = Color.green;
            emission = 1;
        }

        else if (gameObject.tag == "Green Light" && !gameObject.transform.parent.GetComponent<TrafficLight>().greenLight)
        {
            baseColor = Color.green;
            emission = 0;
        }

        if (gameObject.tag == "Yellow Light" && gameObject.transform.parent.GetComponent<TrafficLight>().yellowLight)
        {
            baseColor = Color.yellow;
            emission = 1;
        }

        if (gameObject.tag == "Yellow Light" && !gameObject.transform.parent.GetComponent<TrafficLight>().yellowLight)
        {
            baseColor = Color.yellow;
            emission = 0;
        }

        if (gameObject.tag == "Red Light" && gameObject.transform.parent.GetComponent<TrafficLight>().redLight)
        {
            baseColor = Color.red;
            emission = 1;
        }

        if (gameObject.tag == "Red Light" && !gameObject.transform.parent.GetComponent<TrafficLight>().redLight)
        {
            baseColor = Color.red;
            emission = 0;
        }

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        mat.SetColor("_EmissionColor", finalColor);
    }
}
