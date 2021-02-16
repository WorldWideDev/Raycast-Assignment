using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {

    public delegate void DetectPlayerHandler(GameObject sender);
    public static event DetectPlayerHandler onDetectPlayer;
    public static event DetectPlayerHandler onReachedPlayer;
    public static event DetectPlayerHandler onSearchingForPlayer;

    public static bool reachedPlayer = false;

    public static void DetectPlayer(GameObject sender)
    {
        if(onDetectPlayer != null)
        {
            onDetectPlayer(sender);
        }
    }

    public static void ReachedPlayer(GameObject sender)
    {
        if(onReachedPlayer != null)
        {
            onReachedPlayer(sender);
            reachedPlayer = true;
        }
    }

    public static void ResumeSearch(GameObject sender)
    {
        if(onSearchingForPlayer != null)
        {
            onSearchingForPlayer(sender);
            reachedPlayer = false;
        }
    }
}
