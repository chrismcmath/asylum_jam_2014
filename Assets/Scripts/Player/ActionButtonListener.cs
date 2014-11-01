using UnityEngine;
using System.Collections;

public class ActionButtonListener : MonoBehaviour {
	public void Update () {
        if (Input.GetButtonUp("Action")) {
            Debug.Log("ACtion button pressed");
        }
	}
}
