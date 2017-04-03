using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeImageToggle : MonoBehaviour {

    public Texture Image1;
    public Texture Image2;
    public RawImage canvasImage;

    void Start()
    {
        canvasImage.texture = Image1;
    }

    void Update()
    {
        if (GetComponent<Movement>().checkFpFloor())
            canvasImage.texture = Image1;

        else
            canvasImage.texture = Image2;
    }
}
