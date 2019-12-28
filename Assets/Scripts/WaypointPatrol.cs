using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour {
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int currentWaypointIndex = 0;

    void Start() {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update() {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance) {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

            var currentWaypoint = waypoints[currentWaypointIndex];
            navMeshAgent.SetDestination(currentWaypoint.position);
        }
    }
}
