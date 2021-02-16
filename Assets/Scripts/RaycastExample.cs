using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour {

    //public Transform origin;
    public float maxRange = 50f;

    void Update()
    {
        // RaycastHit is a struct used to get info back from a raycast
        RaycastHit hit;

        // This override method takes the following signature
        // Physics.Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance)
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRange))
        {
            Debug.Log("found a thing");
        }

        Debug.DrawRay(transform.position, transform.forward * maxRange, Color.green);

    }
}
