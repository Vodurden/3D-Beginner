using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Triggers the end of game cutscene on demand, used for victory and failure.
 */
public class GameEnding : MonoBehaviour {
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    [Serializable]
    public enum GameEndOptions { Restart, Quit }
    public GameEndOptions gameEndOption = GameEndOptions.Restart;

    public CanvasGroup endBackgroundImageCanvasGroup;
    public AudioSource endAudio;

    bool endTriggered = false;
    bool hasAudioPlayed = false;
    float fadeTimer = 0f;

    void Update() {
        if(endTriggered) {
            fadeTimer += Time.deltaTime;
            endBackgroundImageCanvasGroup.alpha = fadeTimer / fadeDuration;

            if(!hasAudioPlayed) {
                endAudio.Play();
                hasAudioPlayed = true;
            }

            if(fadeTimer > fadeDuration + displayImageDuration) {
                if(gameEndOption == GameEndOptions.Restart) {
                    SceneManager.LoadScene(0);
                } else if (gameEndOption == GameEndOptions.Quit) {
                    Application.Quit();
                }
            }
        }
    }

    public void EndGame() {
        endTriggered = true;
    }
}
