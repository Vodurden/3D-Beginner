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

    bool hasWonGame = false;
    bool hasLostGame = false;
    float fadeTimer = 0f;

    public void CaughtPlayer() {
        hasLostGame = true;
    }

    void Update() {
        if(hasWonGame) {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        } else if(hasLostGame) {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject == player) {
            hasWonGame = true;
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart) {
        fadeTimer += Time.deltaTime;
        imageCanvasGroup.alpha = fadeTimer / fadeDuration;

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
