using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour {
    public Transform player;
    public bool checkLineOfSight = false;

    GameEnding gameEnding;
    bool isPlayerInRange = false;

    void Start() {
        gameEnding = GetComponent<GameEnding>();
    }

    void OnTriggerEnter(Collider other) {
        if(other.transform == player) {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.transform == player) {
            isPlayerInRange = false;
        }
    }

    void Update() {
        bool playerInSight = isPlayerInRange;

        if(isPlayerInRange && checkLineOfSight) {
            Vector3 direction = player.position - transform.position + Vector3.up;

            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if(Physics.Raycast(ray, out raycastHit) && raycastHit.collider.transform == player) {
                playerInSight = true;
            } else {
                playerInSight = false;
            }
        }

        if(playerInSight) {
            gameEnding.EndGame();
        }
    }
}
