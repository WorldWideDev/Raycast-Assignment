using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {

    public Transform origin;
    public float sightRange = 50f;
    public bool drawRay = true;

    public delegate void DetectPlayerHandler();
    public static event DetectPlayerHandler onDetectPlayer;
    public static event DetectPlayerHandler onResumeLooking;

    bool resumedLooking = false;

    public static void DetectedPlayer()
    {
        if(onDetectPlayer != null)
        {
            onDetectPlayer();
        }
    }

    public static void ResumeLooking()
    {
        if(onResumeLooking != null)
        {
            onResumeLooking();
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(origin.position, origin.forward, out hit, sightRange))
        {
            if(hit.collider.tag == "Player")
            {
                DetectedPlayer();
                resumedLooking = true;
            }
            else
            {
                resumedLooking = false;
            }

        }
        

        else if (resumedLooking)
        {
            ResumeLooking();
            resumedLooking = false;
        }


        if (drawRay)
        {
            Debug.DrawRay(origin.position, origin.forward * sightRange, Color.green);
        }
    }

    

}
