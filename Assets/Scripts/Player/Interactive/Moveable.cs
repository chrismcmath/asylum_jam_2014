using UnityEngine;
using System.Collections;

public class Moveable : HoldableObject {
    private Rigidbody _Rigidbody = null;

    public void Awake() {
        _Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public override void OnPickUp() {
        _Rigidbody.isKinematic = true;
        transform.parent = GlobalConfig.Instance.PlayerObjectRoot;
    }

    public override void OnPutDown() {
        _Rigidbody.isKinematic = false;
        transform.parent = GlobalConfig.Instance.SceneRoot;
    }
}
