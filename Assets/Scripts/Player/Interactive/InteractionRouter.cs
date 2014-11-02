using UnityEngine;
using System.Collections;

public class InteractionRouter : MonoBehaviour {
    public InteractiveObject _HeldObject = null;

    public void OnAction() {
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

    private InteractiveObject GetInteractiveObject() {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(transform.position, forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(ray, out hit, 2f, GlobalConfig.Instance.InteractionLayerMask)) {
            Debug.DrawLine(ray.origin, hit.point);
            InteractiveObject obj = hit.collider.gameObject.GetComponent<InteractiveObject>();
            //Debug.Log("SUCCESS got obj "+ hit.collider.gameObject.name);
            return obj;
        }
        return null;
    }
}
