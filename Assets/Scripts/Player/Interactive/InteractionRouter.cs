using UnityEngine;
using System.Collections;

public class InteractionRouter : MonoBehaviour {
    public InteractiveObject _HeldObject = null;

    public void OnAction() {
        Debug.Log("on action, held: " + _HeldObject);
        if (_HeldObject != null) {
            if (!_HeldObject.OnAction()) {
                _HeldObject = null;
            }
            return;
        }

        InteractiveObject obj = GetInteractiveObject();

        if (obj != null && obj.OnAction()) {
            _HeldObject = obj;
        }
    }

    public void ForceDrop() {
        Debug.Log("forcing drop, _HeldObject");
        _HeldObject = null;
    }
    
    private void AttemptDrop() {
        Debug.Log("AttemptDrop");
        if (_HeldObject != null) {
            if (!_HeldObject.OnAction()) {
                _HeldObject = null;
            }
            return;
        }
    }

    private InteractiveObject GetInteractiveObject() {
        Debug.Log("get");
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(transform.position, forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, forward * 100f, Color.green);

        if (Physics.Raycast(ray, out hit, 2f, GlobalConfig.Instance.InteractionLayerMask)) {
            Debug.DrawLine(ray.origin, hit.point);
            InteractiveObject obj = hit.collider.gameObject.GetComponent<InteractiveObject>();
            Debug.Log("SUCCESS got obj "+ hit.collider.gameObject.name);
            return obj;
        }
        Debug.Log("found nothing");
        return null;
    }
}
