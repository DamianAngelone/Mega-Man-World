using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPersonBullet : MonoBehaviour {

    public float mouseSensitivity = 1.0f;
    public GameObject mainCam;
    public float upDownRange = 10.0f;
    public float verticalRot = 0.0f;
    bool canShoot = true;

    public GameObject FPbullet;
    public AudioSource gun;
    public GameObject buster;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<Movement>().checkPOV)
        {

            float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;

            verticalRot -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRot = Mathf.Clamp(verticalRot, -upDownRange, upDownRange);

            //GameObject theGun = Instantiate(buster, transform.position, Quaternion.Euler(0, 0, 0));

            if (!Input.GetKey(KeyCode.Q)) { 
                transform.Rotate(0, rotLeftRight, 0);
                mainCam.transform.localRotation = Quaternion.Euler(verticalRot, rotLeftRight + 90, 0);
            }
            

            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                gun.Play();

                GameObject gO = Instantiate(FPbullet, transform.position, Quaternion.Euler(0, 0, 0));
                    
                StartCoroutine(WaitToShoot());
            }
        }
    }

    IEnumerator WaitToShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}
