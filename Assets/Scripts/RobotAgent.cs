using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotAgent : MonoBehaviour {

    public Transform player;
    public Transform[] waypoints;

    public float stoppingDistanceFromPlayer = 5f;

    NavMeshAgent agent;
    Vector3 playerPos;
    bool lookingForPlayer = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(NextWayPoint());
        playerPos = player.position;
    }

    void Update()
    {
        if (lookingForPlayer)
        {
            RobotPathing();
        } else
        {
            // found player... updating player position until spotting distance reached
            playerPos = player.position;
        }
    }

    Vector3 NextWayPoint()
    {
        return waypoints[Random.Range(0, waypoints.Length)].position;
    }

    void RobotPathing()
    {
        // check if destination is reached
        if (!agent.pathPending)
        {
            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    print("has reached");
                    agent.SetDestination(NextWayPoint());
                }
            }
        }
    }

    void GoToPlayer(GameObject sender)
    {
        lookingForPlayer = false;
        agent.stoppingDistance = stoppingDistanceFromPlayer;
        playerPos = player.position;
        StartCoroutine(PathToPlayer());
    }

    //WaitUntil TravledToPlayer = new WaitUntil(() => agent.remainingDistance <= agent.stoppingDistance);
    IEnumerator PathToPlayer()
    {
        while(agent.remainingDistance >= agent.stoppingDistance)
        {
            agent.SetDestination(playerPos);
            yield return null;
        }
        print("Reached Player");
        GameEvents.ReachedPlayer(gameObject);
    }

    void ResumeSearching(GameObject sender)
    {
        lookingForPlayer = true;
        agent.stoppingDistance = 0;
        agent.SetDestination(NextWayPoint());
    }

    void Awake()
    {
        GameEvents.onDetectPlayer += GoToPlayer;
        GameEvents.onSearchingForPlayer += ResumeSearching;
    }

    void OnDestroy()
    {
        GameEvents.onDetectPlayer -= GoToPlayer;
        GameEvents.onSearchingForPlayer -= ResumeSearching;
    }

}