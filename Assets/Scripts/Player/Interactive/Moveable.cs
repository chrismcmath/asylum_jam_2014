using UnityEngine;
using System.Collections;

public class Moveable : HoldableObject {
    private Rigidbody _Rigidbody = null;

    public void Awake() {
        _Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public override bool OnPickUp() {
        Debug.Log("movable OnPickUp");
        GetComponent<Collider>().enabled = false;
        _Rigidbody.isKinematic = true;
        transform.parent = GlobalConfig.Instance.PlayerObjectRoot;
        TweenToZero(GlobalConfig.Instance.FocusObjectTweenTime);
        return true;
    }

    public override bool OnPutDown() {
        Debug.Log("movable OnPutDown");
        GetComponent<Collider>().enabled = true;
        _Rigidbody.isKinematic = false;
        _Rigidbody.useGravity = true;
        transform.parent = GlobalConfig.Instance.SceneRoot;

        if (_Tweener != null) {
            Destroy(_Tweener);
        }

        return true;
    }
}
