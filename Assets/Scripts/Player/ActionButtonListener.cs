using UnityEngine;
using System.Collections;

public class ActionButtonListener : MonoBehaviour {
    public const string ACTIVATE_ACTION = "OnAction";

	public void Update () {
        if (Input.GetButtonUp("Action")) {
            gameObject.SendMessage(ACTIVATE_ACTION);
        }
	}
}
