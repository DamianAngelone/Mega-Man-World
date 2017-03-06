using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerForPerspective : MonoBehaviour {

    public float timer = 10.0f;
    public float health = 10.0f;
    bool canDecr = true;

    public bool gameOverState;
    public bool winState;

    public GameObject gameOver;
    public GameObject VictoryText;
    public Animator anim;
    public AudioSource gameOverMusic;
    public AudioSource BGmusic;
    public AudioSource Victory;

    public AudioSource fastHeart;
    public AudioSource slowHeart;

    // Use this for initialization
    void Start () {

        gameOverState = false;
        gameOver.SetActive(false);
        VictoryText.SetActive(false);
        BGmusic.Play();
    }
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<Movement>().checkPOV && canDecr)
        {
            if(timer != 0)
            {
                timer--;
                //Debug.Log("Timer: " + timer);
                StartCoroutine(SecondDelay());
            }

            else
            {

                if (health <= 0)
                {
                    gameOverState = true;
                }                

                else
                {
                    health--;
                    //Debug.Log("Health: " + health);
                    StartCoroutine(SecondDelay());
                }
            }
        }

        if (gameOverState)
        {
            gameOver.SetActive(true);

            BGmusic.Pause();

            if (!gameOverMusic.isPlaying)
            {
                gameOverMusic.Play();
            }

            GetComponent<Movement>().checkPOV = false;
            GetComponent<ChangePOV>().fpCAM.gameObject.active = false;
            GetComponent<ChangePOV>().ssCAM.gameObject.active = true;

            
            anim.SetTrigger("dead");
            
        }

        if (winState)
        {
            VictoryText.SetActive(true);

            BGmusic.Pause();
            
            GetComponent<Movement>().checkPOV = false;
            GetComponent<ChangePOV>().fpCAM.gameObject.active = false;
            GetComponent<ChangePOV>().ssCAM.gameObject.active = true;
          
            if (!Victory.isPlaying)
            {
                Victory.Play();
            }

            anim.SetTrigger("win");
            
        }

        if (!GetComponent<Movement>().checkPOV && !gameOverState && canDecr && timer <= 10)
        {
            timer += 2;
            //Debug.Log("Timer: " + timer);
            StartCoroutine(SecondDelay());
        }

        if (GetComponent<Movement>().checkPOV)
        {
            if (timer >= 4)
            {
                if (!slowHeart.isPlaying && !fastHeart.isPlaying)
                {
                    slowHeart.Play();
                    BGmusic.volume = 0.075f;
                }
            }

            else if (timer < 4)
            {
                if (!fastHeart.isPlaying && !slowHeart.isPlaying)
                {
                    fastHeart.Play();
                    BGmusic.volume = 0.075f;
                }
            }
        }
        else{

            BGmusic.volume = 1.0f;
        }

    }

    IEnumerator SecondDelay()
    {
        canDecr = false;
        yield return new WaitForSeconds(1);
        canDecr = true;
    }
}
