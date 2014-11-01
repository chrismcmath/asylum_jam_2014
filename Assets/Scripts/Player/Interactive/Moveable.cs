using UnityEngine;
using System.Collections;

public class Moveable : InteractiveObject {
    private bool _IsHeld = false;
    private Rigidbody _Rigidbody = null;

    public void Awake() {
        _Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public override bool OnAction() {
		if (!_IsHeld) {
            _Rigidbody.isKinematic = true;
            transform.parent = GlobalConfig.Instance.PlayerObjectRoot;
            _IsHeld = true;
        } else {
            _Rigidbody.isKinematic = false;
            transform.parent = GlobalConfig.Instance.SceneRoot;
            _IsHeld = false;
        }
        return _IsHeld;
    }
}
