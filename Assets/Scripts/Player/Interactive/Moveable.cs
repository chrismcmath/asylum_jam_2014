using UnityEngine;
using System.Collections;

public class Moveable : HoldableObject {
    private Rigidbody _Rigidbody = null;

    public void Awake() {
        _Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public override bool OnPickUp() {
        _Rigidbody.isKinematic = true;
        transform.parent = GlobalConfig.Instance.PlayerObjectRoot;
        return true;
    }

    public override bool OnPutDown() {
        _Rigidbody.isKinematic = false;
        transform.parent = GlobalConfig.Instance.SceneRoot;
        return true;
    }
}
