using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLook : MonoBehaviour {

    public Transform origin;
    public float sightRange = 50f;
    public bool drawRay = false;

    public float searchDelay = 3f;

    bool lookingForPlayer = true;

    void Awake()
    {
        GameEvents.onDetectPlayer += FoundPlayer;
        GameEvents.onSearchingForPlayer += ResumeSearching;
    }
    
    void OnDestroy()
    {
        GameEvents.onDetectPlayer -= FoundPlayer;
        GameEvents.onSearchingForPlayer -= ResumeSearching;
    }

    void FoundPlayer(object sender)
    {
        lookingForPlayer = false;
    }

    void ResumeSearching(GameObject sender)
    {
        StartCoroutine(DelayCast());
    }

    IEnumerator DelayCast()
    {
        yield return new WaitForSeconds(searchDelay);
        lookingForPlayer = true;
    }

    void FixedUpdate () {
        
       

        if (lookingForPlayer)
        {
            RaycastHit hit;

            if (Physics.Raycast(origin.position, origin.forward, out hit, sightRange))
            {
                if (hit.collider.tag == "Player")
                {
                    print("SPOTTED");
                    GameEvents.DetectPlayer(gameObject);
                }
            }

            if (drawRay)
            {
                Debug.DrawRay(origin.position, origin.forward * sightRange, Color.green);
            }
        }
        

	}
}
