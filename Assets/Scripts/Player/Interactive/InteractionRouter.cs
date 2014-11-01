using UnityEngine;
using System.Collections;

public class InteractionRouter : MonoBehaviour {
    //public enum state {AVAILABLE, LOCKED}

    public InteractiveObject _HeldObject = null;

    public void OnAction() {
        if (_HeldObject != null) {
            _HeldObject.OnAction();
            return;
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 8f, GlobalConfig.Instance.InteractionLayerMask)) {
            Debug.DrawLine(ray.origin, hit.point);
            InteractiveObject obj = hit.collider.gameObject.GetComponent<InteractiveObject>();
            Debug.Log("SUCCESS got obj {0}", obj);
            return obj;
        }
        return null;
    }
}
