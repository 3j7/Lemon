using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    float tTimer;
    bool ifPlayerExit;
    bool ifPlayerCaught;
    bool ifPlayerBurned;
    bool hasAudioPlayed;

    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
 
    public GameObject player; 
    public AudioSource exitAudio; 
    public AudioSource caughtAudio; 
    public AudioSource burnedAudio; 
    public CanvasGroup exitImageBackCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public CanvasGroup emberBackgroundImageCanvasGroup;

    void Update()
    {
        if (ifPlayerExit)
        {
          GameEnding(exitImageBackCanvasGroup, false, exitAudio);
        }
        else if (ifPlayerCaught )
        {
            GameEnding(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
        else if (ifPlayerBurned)
        {
            GameEnding(emberBackgroundImageCanvasGroup, true, burnedAudio);
        }
    }
    public void BurnedPlayer()
    {
        ifPlayerBurned = true;
    }
    public void CaughtPlayer()
    {
        ifPlayerCaught = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {

          ifPlayerExit = true;
     
        }
    }

    void GameEnding (CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }
        tTimer += Time.deltaTime;
        imageCanvasGroup.alpha = tTimer / fadeDuration;
        if (tTimer > fadeDuration + displayImageDuration)
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
