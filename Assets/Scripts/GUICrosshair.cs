using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUICrosshair : MonoBehaviour {

    public bool showGUI = false;
    public Texture2D crosshairTexture;
    public float crosshairScale = 0.05f;

    void Start()
    {
        Cursor.visible = false;
    }


    void Update()
    {
        bool check = GetComponent<Movement>().checkPOV;

        showGUI = check ? true : false;
    }

    void OnGUI()
    {
        if (showGUI)
        {
            if (crosshairTexture != null)
            {
                GUI.DrawTexture(new Rect((Screen.width - crosshairTexture.width * crosshairScale) / 2, (Screen.height - crosshairTexture.height * crosshairScale) / 2, crosshairTexture.width * crosshairScale, crosshairTexture.height * crosshairScale), crosshairTexture);
            }
            else
                Debug.Log("No crosshair texture set in the Inspector");
        }
    }
}
