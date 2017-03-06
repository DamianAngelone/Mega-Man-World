using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class bulletMovement : MonoBehaviour
{

    float speed;			//Making things public makes them accessible in the editor
    float bulletSpeed;
    public GameObject bullet;
    Rigidbody rb2;

    public AudioSource gun;

    public Animator anim;
    bool canShoot = true;

    //GameObject bullet;	//Assign the bullet prefab in the editor
    int count = 0;

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Movement>().checkPOV && !GetComponent<TimerForPerspective>().gameOverState && !GetComponent<TimerForPerspective>().winState && !GetComponent<Movement>().inCutscene)
        {
            bulletSpeed = Input.GetAxis("Horizontal") * -0.5f;
            bulletSpeed = 1;

            if (Input.GetMouseButtonDown(0) && canShoot)
            {

                gun.Play();

                int right = GetComponent<Movement>().getRight() ? 1 : -1;

                GameObject gO = Instantiate(bullet, transform.position, Quaternion.Euler(0, right == 1 ? 180 : 1, 0)) as GameObject;

                gO.GetComponent<Rigidbody>().AddForce(new Vector3(200 * right, 0, 0));
                StartCoroutine(WaitToShoot());
                //anim.SetTrigger("run gun");
            }
        }
    }

    IEnumerator WaitToShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.3f);
        canShoot = true;
    }
}