using UnityEngine;
using System.Collections;
using TinyTween;

public class FocusObject : HoldableObject {
    private Vector3Tween _PositionTween = new Vector3Tween();
    private QuaternionTween _RotationTween = new QuaternionTween();
    private Vector3 _OriginalPosition = new Vector3();
    private Quaternion _OriginalRotation = new Quaternion();

    public Transform ViewAnchor;

    public void Awake() {
    }

    public override void OnPickUp() {
        GlobalConfig.Instance.Player.GetComponent<MovementActivator>().Deactivate();
        //GlobalConfig.Instance.Player.GetComponent<Rigidbody>().isKinematic = false;

        _PositionTween.Start(GlobalConfig.Instance.Player.transform.position, ViewAnchor.position, GlobalConfig.Instance.FocusObjectTweenTime, ScaleFuncs.CubicEaseOut);
        _RotationTween.Start(GlobalConfig.Instance.Player.transform.rotation, ViewAnchor.rotation, GlobalConfig.Instance.FocusObjectTweenTime, ScaleFuncs.CubicEaseOut);
    }

    public override void OnPutDown() {
    }

    public void Update() {
        //Debug.Log("current value: " + _Tween.CurrentValue + " current time: " + _Tween.CurrentTime);
        _PositionTween.Update(Time.deltaTime);
        _RotationTween.Update(Time.deltaTime);
        if (_PositionTween.State == TweenState.Running) {
            GlobalConfig.Instance.Player.transform.position = _PositionTween.CurrentValue;
        }

        if (_RotationTween.State == TweenState.Running) {
            GlobalConfig.Instance.Player.transform.rotation = _RotationTween.CurrentValue;
        }
    }
}
