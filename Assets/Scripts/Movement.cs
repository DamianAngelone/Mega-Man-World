using System;
using UnityEngine;

public class Movement : MonoBehaviour {

    public bool checkPOV;
    public bool isGrounded;
    public bool isJumping;
    public bool isMoving;
    public bool activeDJ;
    public bool isDJumping = false;
    public Animator anim;
    bool stop = true;

    public Rigidbody rb;

    public float sideSpd;
    public float moveSpd;
    public float depthSpd;
    public float jumpForce;
    public float doubleJumpForce;
    public bool isRight;

    public bool inCutscene;

    public bool perspectiveSwitchValid;

    // Use this for initialization
    void Start () {

        inCutscene = true;
        checkPOV = false;
        rb = GetComponent<Rigidbody>();
        anim.SetTrigger("idle");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 thePos = transform.localPosition;
        Vector3 theScale = transform.localScale;
        Quaternion theRotation = transform.localRotation;

        if (!GetComponent<TimerForPerspective>().gameOverState && !GetComponent<TimerForPerspective>().winState && !GetComponent<Movement>().inCutscene)
        {

            sideSpd = Input.GetAxis("Horizontal") * -0.3f;



            //Side-Scroller MODE **************************************************
            if (!checkPOV)
            {

                if ((Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D)) && (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A)))
                {
                    isMoving = true;
                }

                // Jump and Run
                if (Input.GetKeyDown(KeyCode.Space) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !isJumping)
                {
                    anim.SetTrigger("jump");
                    isJumping = true;

                    isMoving = true;
                    jumpForce = 3;
                }

                // Jump
                else if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isMoving)
                {
                    anim.SetTrigger("jump");
                    isJumping = true;
                    jumpForce = 3;
                }

                // X-Y Walking
                else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
                {
                    isMoving = true;
                    if (!isJumping)
                    {
                        anim.SetTrigger("run");
                    }

                    theScale.x = (Input.GetKey(KeyCode.D))
                        ? -(float)Math.Ceiling(Input.GetAxis("Horizontal"))
                        : (float)Math.Ceiling(-Input.GetAxis("Horizontal"));
                    isRight = theScale.x == 1 ? true : false;
                    transform.localScale = theScale;

                    thePos.x += -0.03f * Input.GetAxis("Horizontal");
                    transform.localPosition = thePos;
                }

                //Shooting
                else if (Input.GetMouseButtonDown(0) && isJumping)
                {

                    if (isMoving && isJumping)
                    {
                        anim.SetTrigger("jump gun");
                        anim.SetTrigger("end shoot");
                    }

                    else if (isJumping)
                    {
                        anim.SetTrigger("jump gun");
                        anim.SetTrigger("end shoot");
                    }

                    else if (isMoving)
                    {
                        anim.SetTrigger("run gun");
                        anim.SetTrigger("end shoot");
                    }

                    else
                    {
                        anim.SetTrigger("shoot");
                    }
                }

                // Idle
                else
                {
                    anim.SetTrigger("idle");
                    isMoving = false;
                }

                // Double Jump
                if (Input.GetKeyDown(KeyCode.LeftShift) && isJumping && !isDJumping)
                {
                    //Debug.Log("Hey, ya'll");
                    doubleJump();
                }

                //Drop Attack
                if (Input.GetKeyDown(KeyCode.E) && isJumping)
                {
                    jumpForce = -10;
                }
            }

            //FIRST-PERSON MODE **************************************************
            else if (checkPOV)
            {
                depthSpd = Input.GetAxis("Vertical") * -0.2f;

                // Jump
                if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isMoving)
                {
                    isJumping = true;
                    jumpForce = 3;
                }

                // X-Y Walking
                else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    //isMoving = false;

                    if (Input.GetKey(KeyCode.A))
                    {
                        //Debug.Log("Pressing A");
                        transform.Translate(0, 0, -Time.deltaTime * -transform.localScale.x);
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        //Debug.Log("Pressing D");
                        transform.Translate(0, 0, Time.deltaTime * -transform.localScale.x);
                    }
                    if (Input.GetKey(KeyCode.W))
                    {
                        //Debug.Log("Pressing W");
                        transform.Translate(-Time.deltaTime * -transform.localScale.x, 0, 0);
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        //Debug.Log("Pressing S");
                        transform.Translate(Time.deltaTime * -transform.localScale.x, 0, 0);
                    }
                }

                // Idle
                else
                {
                    isMoving = false;
                }

            }
        }

        if (Input.GetMouseButtonDown(1) && !isMoving && !isJumping)
        {
            //Debug.Log(perspectiveSwitchValid);

            if (perspectiveSwitchValid)
            {
                checkPOV = !checkPOV;

                if (!checkPOV)
                {
                    theRotation.y = 0;
                    transform.localRotation = theRotation;
                }
            }
        }
    }

    void FixedUpdate() {

        
        if(!checkPOV)
        {
            if (rb.velocity.sqrMagnitude < 1)
                rb.AddForce(new Vector3(sideSpd, jumpForce + (activeDJ ? doubleJumpForce : 0), 0), ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(new Vector3(0, jumpForce + (activeDJ ? doubleJumpForce : 0), 0), ForceMode.Impulse);
        }

        activeDJ = false;
    }

    void OnCollisionEnter(Collision col){

        //Debug.Log("You hit something: " + col.collider.tag);

        if (col.collider.tag != "fpFloor")
            perspectiveSwitchValid = true;

        else
            perspectiveSwitchValid = false;

        if (col.collider.tag == "Ground" && inCutscene)
        {
            anim.SetTrigger("start");
            inCutscene = false;
        }

        if (col.collider.tag == "Lava" && stop)
        {
            sideSpd = 0;
            jumpForce = 0;
            GetComponent<TimerForPerspective>().health = 0;
            GetComponent<TimerForPerspective>().gameOverState = true;

            stop = false;
        }

        if (col.collider.tag == "Victory" && stop)
        {
            sideSpd = 0;
            jumpForce = 0;
            GetComponent<TimerForPerspective>().winState = true;

            stop = false;
        }

            if (col.collider.tag == "Ground" || col.collider.tag == "fpFloor")
        {
            isGrounded = true;
            isJumping = false;
            isDJumping = false;
        }
    }

    void OnCollisionExit(Collision col)
    {

        //Debug.Log("You left something: " + col.collider.tag);
        if (col.collider.tag == "Ground" || col.collider.tag == "fpFloor")
        {
            isGrounded = false;
            jumpForce = 0;
            doubleJumpForce = 0;
        }
    }

    public bool getRight()
    {
        return isRight;
    }

    void doubleJump()
    {
        activeDJ = true;
        //jumpForce = 0;
        rb.AddForce(new Vector2(0, 150));
        isDJumping = true;
    }
}
