using UnityEngine;
using System.Collections;

public class Moveable : HoldableObject {
    private Rigidbody _Rigidbody = null;

    public void Awake() {
        _Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public override bool OnPickUp() {
        _Rigidbody.isKinematic = true;
        Transform objRoot = GlobalConfig.Instance.PlayerObjectRoot;
        transform.parent = objRoot;

        TweenToZero(GlobalConfig.Instance.FocusObjectTweenTime);
        return true;
    }

    public override bool OnPutDown() {
        _Rigidbody.isKinematic = false;
        transform.parent = GlobalConfig.Instance.SceneRoot;

        if (_Tweener != null) {
            Destroy(_Tweener);
        }

        return true;
    }
}
