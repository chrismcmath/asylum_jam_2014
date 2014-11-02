using UnityEngine;
using System.Collections;
using TinyTween;

//TODO: (CM) remove dupe
public class TweenLocalTransform : MonoBehaviour {
    protected Vector3Tween _PositionTween = new Vector3Tween();
    protected QuaternionTween _RotationTween = new QuaternionTween();

    public void Update() {
        //Debug.Log("current value: " + _Tween.CurrentValue + " current time: " + _Tween.CurrentTime);
        _PositionTween.Update(Time.deltaTime);
        _RotationTween.Update(Time.deltaTime);
        if (_PositionTween.State == TweenState.Running) {
            transform.localPosition = _PositionTween.CurrentValue;
        }

        if (_RotationTween.State == TweenState.Running) {
            transform.localRotation = _RotationTween.CurrentValue;
        }

        if (_PositionTween.State != TweenState.Running  && 
                _RotationTween.State != TweenState.Running) {
            Destroy(this);
        }
    }

    public void Tween(Transform from, Transform to, float duration) {
        TweenPosition(from.position, to.position, duration);
        TweenRotation(from.rotation, to.rotation, duration);
    }

    public void TweenPosition(Vector3 from, Vector3 to, float duration) {
        _PositionTween.Start(from, to, duration, ScaleFuncs.CubicEaseOut);
    }

    public void TweenRotation(Quaternion from, Quaternion to, float duration) {
        _RotationTween.Start(from, to, duration, ScaleFuncs.CubicEaseOut);
    }

}
