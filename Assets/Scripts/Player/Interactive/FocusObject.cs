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

    public override bool OnPickUp() {
        GlobalConfig.Instance.Player.GetComponent<MovementActivator>().Deactivate();
        //GlobalConfig.Instance.Player.GetComponent<Rigidbody>().isKinematic = false;

        _OriginalPosition = GlobalConfig.Instance.Player.transform.position;
        _OriginalRotation = GlobalConfig.Instance.Player.transform.rotation;

        _PositionTween.Start(_OriginalPosition, ViewAnchor.position, GlobalConfig.Instance.FocusObjectTweenTime, ScaleFuncs.CubicEaseOut);
        _RotationTween.Start(_OriginalRotation, ViewAnchor.rotation, GlobalConfig.Instance.FocusObjectTweenTime, ScaleFuncs.CubicEaseOut);
        return true;
    }

    public override bool OnPutDown() {
        _PositionTween.Start(GlobalConfig.Instance.Player.transform.position, _OriginalPosition, GlobalConfig.Instance.FocusObjectTweenTime, ScaleFuncs.CubicEaseOut);
        _RotationTween.Start(GlobalConfig.Instance.Player.transform.rotation, _OriginalRotation, GlobalConfig.Instance.FocusObjectTweenTime, ScaleFuncs.CubicEaseOut);

        StartCoroutine(ReactivatePlayerMovement());
        return true;
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

    private IEnumerator ReactivatePlayerMovement() {
        yield return new WaitForSeconds(GlobalConfig.Instance.FocusObjectTweenTime);

        GlobalConfig.Instance.Player.GetComponent<MovementActivator>().Activate();
    }
}
