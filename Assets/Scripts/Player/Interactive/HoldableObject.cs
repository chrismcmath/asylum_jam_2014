using UnityEngine;
using System.Collections;
using TinyTween;

public abstract class HoldableObject : InteractiveObject {
    protected bool _IsHeld = false;
    protected TweenLocalTransform _Tweener = null;

    abstract public bool OnPickUp();
    abstract public bool OnPutDown();

    public override bool OnAction() {
        Debug.Log("HoldableObject onaction, isheld: " + _IsHeld);
		if (!_IsHeld) {
            if (OnPickUp()) {
                _IsHeld = true;
            }
        } else {
            if (OnPutDown()) {
                _IsHeld = false;
            }
        }
        return _IsHeld;
    }

    protected void TweenTransform(Transform from, Transform to, float duration) {
        if (_Tweener != null) Destroy(_Tweener);
        _Tweener = gameObject.AddComponent<TweenLocalTransform>();
        _Tweener.TweenPosition(from.position, to.position, duration);
        _Tweener.TweenRotation(from.rotation, to.rotation, duration);
    }

    protected void TweenToZero(float duration) {
        if (_Tweener != null) Destroy(_Tweener);
        _Tweener = gameObject.AddComponent<TweenLocalTransform>();
        _Tweener.TweenPosition(transform.localPosition, Vector3.zero, duration);
        _Tweener.TweenRotation(transform.localRotation, Quaternion.identity, duration);
    }
}
