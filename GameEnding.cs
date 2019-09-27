using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{

    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup BackImgCanvas;
    public CanvasGroup caughtBackImg;
    public AudioSource exitAuido;
    public AudioSource caughtAudio;
    bool mHasAudioPlayed;

    float timer;
    bool PlayerExit;
    bool PlayerCaught;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            PlayerExit = true;
        }

    }
    
    void Update()
    {
               
        if (PlayerExit)
        {
            EndLevel(BackImgCanvas, false, exitAuido);
        }
        else if(PlayerCaught)
        {
            EndLevel(caughtBackImg, true, caughtAudio);
        }

    }

    public void CaughtPlayer()
    {
        PlayerCaught = true;
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {

        if(!mHasAudioPlayed)
        {
            audioSource.Play();
            mHasAudioPlayed = true;
        }

        timer += Time.deltaTime;
        imageCanvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);

            }
            else
            {
                Application.Quit();
            }
            
        }
    }
}
