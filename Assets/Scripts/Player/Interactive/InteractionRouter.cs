using UnityEngine;
using System.Collections;

public class InteractionRouter : MonoBehaviour {
    //public enum state {AVAILABLE, LOCKED}

    public InteractiveObject _HeldObject = null;

    public void OnAction() {
        if (_HeldObject != null) {
            _HeldObject.OnAction();
        }

        /*
        if (state == LOCKED) {
            return;
        }
        */
        InteractiveObject obj = GetInteractiveObject();

        if (obj != null && obj.OnAction()) {
            _HeldObject = obj;
        }
    }

    private InteractiveObject GetInteractiveObject() {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 10))
            Debug.Log("yes");
        else 
            Debug.Log("no");
        return null;
    }
}
