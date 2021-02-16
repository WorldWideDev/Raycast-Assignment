using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimController : MonoBehaviour {

    Animator robotAnim;

    void Awake()
    {
        robotAnim = GetComponent<Animator>();
        GameEvents.onDetectPlayer += SpottedPlayer;
        GameEvents.onSearchingForPlayer += Searching;
    }

    void SpottedPlayer(GameObject sender)
    {
        robotAnim.SetBool("lookingForPlayer", false);
    }

    void Searching(GameObject sender)
    {
        robotAnim.SetBool("lookingForPlayer", true);
    }

    void OnDestroy()
    {
        GameEvents.onDetectPlayer -= SpottedPlayer;
    }
}
