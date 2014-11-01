using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MovementActivator : MonoBehaviour {
    private List<MonoBehaviour> _MovementComponents = new List<MonoBehaviour>();

	public void Awake () {
        _MovementComponents.Add(transform.GetComponent<CharacterMotor>());
        _MovementComponents.AddRange(transform.GetComponentsInChildren<MouseLook>());

        //Debug.Log("Found " + _MovementComponents.Count + " movement components");
	}

    public void Activate() {
        SetActive(true);
    }

    public void Deactivate() {
        SetActive(false);
    }

    public void SetActive(bool active) {
        _MovementComponents.ForEach(c => c.enabled = active);
    }
}
