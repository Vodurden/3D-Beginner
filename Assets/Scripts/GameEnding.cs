using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour {
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    bool hasWonGame = false;
    bool hasLostGame = false;
    float fadeTimer = 0f;
    bool hasAudioPlayed = false;

    public void CaughtPlayer() {
        hasLostGame = true;
    }

    void Update() {
        if(hasWonGame) {
            EndLevel(exitBackgroundImageCanvasGroup, exitAudio, false);
        } else if(hasLostGame) {
            EndLevel(caughtBackgroundImageCanvasGroup, caughtAudio, true);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject == player) {
            hasWonGame = true;
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, AudioSource audioSource, bool doRestart) {
        fadeTimer += Time.deltaTime;
        imageCanvasGroup.alpha = fadeTimer / fadeDuration;

        if(!hasAudioPlayed) {
            audioSource.Play();
            hasAudioPlayed = true;
        }

        // Quit the game when we're done fading
        if(fadeTimer > fadeDuration + displayImageDuration) {
            if(doRestart) {
                SceneManager.LoadScene(0);
            } else {
                Application.Quit();
            }
        }
    }
}
