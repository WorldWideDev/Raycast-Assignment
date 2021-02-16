using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDismiss : MonoBehaviour {

    public float searchDelay = 3f;

	void Update()
    {
        if (GameEvents.reachedPlayer)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                GameEvents.ResumeSearch(gameObject);
            }
        }
    }
}
