using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpin : MonoBehaviour {

    public float spinSpeed = 90f;

    bool spottedPlayer = false;
    
	void Awake () {
        DetectPlayer.onDetectPlayer += PlayerSpotted;
        DetectPlayer.onResumeLooking += Resume;
	}

    void PlayerSpotted()
    {
        spottedPlayer = true;
    }

    void Resume()
    {
        spottedPlayer = false;
    }
	
	void Update () {
        if (!spottedPlayer)
        {
            transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
        }
	}

    void OnDestroy()
    {
        DetectPlayer.onDetectPlayer -= PlayerSpotted;
        DetectPlayer.onResumeLooking -= Resume;
    }
}
