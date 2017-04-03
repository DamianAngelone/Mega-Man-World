using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerForPerspective : MonoBehaviour {

    public int currLevel = 1;

    public float timer = 10.0f;
    public float health = 10.0f;
    bool canDecr = true;

    public bool gameOverState;
    public bool winState;

    public Text gameOver;
    public Text VictoryText;
    public Image highlight;
    public Image highlight2;
    public Animator anim;
    public AudioSource gameOverMusic;
    public AudioSource BGmusic;
    public AudioSource BGmusic2;
    public AudioSource Menu1;
    public AudioSource Menu2;
    public AudioSource Victory;
    public AudioSource fan;
    public AudioSource fan2;
    public AudioSource healing;

    private AudioSource currSong;

    public AudioSource fastHeart;
    public AudioSource slowHeart;

    // Use this for initialization
    void Start () {

        if (currLevel == 1)
        {
            currSong = BGmusic;
        }

        else if (currLevel == 2)
        {
            currSong = BGmusic2;
        }

        gameOverState = false;
        gameOver.enabled = false;
        VictoryText.enabled = false;
        highlight.enabled = false;
        highlight2.enabled = false;
        currSong.Play();
    }
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<Movement>().isHealing)
        {
            if(timer < 10) 
                timer++;

            if(!healing.isPlaying)
                healing.Play();
        }
        else
        {
            healing.Stop();
        }

        if (GetComponent<Movement>().checkPOV && canDecr && !GetComponent<Movement>().isHealing)
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
            gameOver.enabled = true;
            highlight.enabled = true;
            highlight2.enabled = true;

            currSong.Pause();

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
            VictoryText.enabled = true;
            highlight.enabled = true;
            highlight2.enabled = true;

            currSong.Pause();
            
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
                    currSong.volume = 0.075f;
                    fan.volume = 0.010f;
                    fan2.volume = 0.010f;
                }
            }

            else if (timer < 4)
            {
                if (!fastHeart.isPlaying && !slowHeart.isPlaying)
                {
                    fastHeart.Play();
                    currSong.volume = 0.075f;
                    fan.volume = 0.010f;
                    fan2.volume = 0.010f;
                }
            }
        }
        else{
            fan.volume = 0.3f;
            fan2.volume = 0.3f;
            currSong.volume = 0.5f;
        }

    }

    IEnumerator SecondDelay()
    {
        canDecr = false;
        yield return new WaitForSeconds(1);
        canDecr = true;
    }
}
