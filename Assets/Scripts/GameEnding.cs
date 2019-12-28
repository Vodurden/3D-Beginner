using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour {
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;

    bool isEndingGame = false;
    float fadeTimer = 0f;

    void Update() {
        if(isEndingGame) {
            fadeTimer += Time.deltaTime;
            exitBackgroundImageCanvasGroup.alpha = fadeTimer / fadeDuration;

            // Quit the game when we're done fading
            if(fadeTimer > fadeDuration + displayImageDuration) {
                Application.Quit();
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject == player) {
            isEndingGame = true;
        }
    }
}
