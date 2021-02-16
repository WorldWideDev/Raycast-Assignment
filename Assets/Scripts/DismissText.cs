using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DismissText : MonoBehaviour {

    Text dismissText;

	void Awake()
    {
        GameEvents.onReachedPlayer += DisplayDismissText;
        GameEvents.onSearchingForPlayer += HideDismissText;

        dismissText = transform.GetComponentInChildren<Text>();
        dismissText.text = "Press (X) to dismiss Robot";

        dismissText.enabled = false;
    }

    void DisplayDismissText(GameObject sender)
    {
        dismissText.enabled = true;
    }

    void HideDismissText(GameObject sender)
    {
        dismissText.enabled = false;
    }

    void OnDestroy()
    {
        GameEvents.onReachedPlayer -= DisplayDismissText;
        GameEvents.onSearchingForPlayer -= HideDismissText;
    }
}
