using UnityEngine;
using System.Collections;
using TinyTween;

public abstract class HoldableObject : InteractiveObject {
    protected bool _IsHeld = false;
    protected TweenLocalTransform _Tweener = null;

    /*
    protected Vector3 _FormerFromPosition;
    protected Vector3 _FormerToPosition;
    protected Transform _FormerFromTransform;
    protected Transform _FormerToTransform;
    */

    abstract public bool OnPickUp();
    abstract public bool OnPutDown();

    public override bool OnAction() {
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
        _Tweener = gameObject.AddComponent<TweenLocalTransform>();
        _Tweener.TweenPosition(from.position, to.position, duration);
        _Tweener.TweenRotation(from.rotation, to.rotation, duration);
    }

    protected void TweenToZero(float duration) {
        _Tweener = gameObject.AddComponent<TweenLocalTransform>();
        _Tweener.TweenPosition(transform.localPosition, Vector3.zero, duration);
        _Tweener.TweenRotation(transform.localRotation, Quaternion.identity, duration);
    }

    /*
    protected void TweenTransformBack(float duration) {
        TweenTransform tween = gameObject.AddComponent<TweenTransform>();
        tween.Tween(_FormerToTransform, _FormerFromTransform, duration);
    }
    */
}
