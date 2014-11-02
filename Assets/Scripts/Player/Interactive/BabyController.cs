using UnityEngine;
using System.Collections;

public class BabyController : HoldableObject {
    private Transform _BabyDockAnchor;

    public void Awake() {
        BabyModel.Instance.AddStateChangeListener(OnStateChange);
    }

    public override bool OnPickUp() {
        transform.parent = GlobalConfig.Instance.PlayerBabyRoot;
        TweenToZero(GlobalConfig.Instance.FocusObjectTweenTime);

        BabyModel.Instance.State = BabyModel.BabyState.HELD;
        return true;
    }

    public override bool OnPutDown() {
        BabyDockController babyDock = GetBabyDock();
        if (babyDock == null) {
            Debug.Log("No babyDock found");
            return false;
        }

        _BabyDockAnchor = babyDock.Anchor;
        BabyModel.Instance.State = BabyModel.BabyState.DOWN;

        return true;
    }

    public void OnStateChange(BabyModel.BabyState state) {
        switch (state) {
            case BabyModel.BabyState.HELD:
                OnBabyHeld();
                break;
            case BabyModel.BabyState.DOWN:
                OnBabyDown();
                break;
            case BabyModel.BabyState.CRY:
                OnBabyCry();
                break;
        }
    }

    private void OnBabyHeld() {
        Debug.Log("OnBabyHeld");
    }
    private void OnBabyDown() {
        Debug.Log("OnBabyDown");
        if (_BabyDockAnchor == null) {
            Debug.Log("ERROR No _BabyDockAnchor set");
        }
        transform.parent = _BabyDockAnchor;
        TweenToZero(GlobalConfig.Instance.FocusObjectTweenTime);
    }
    private void OnBabyCry() {
        Debug.Log("OnBabyCry");
    }

    private BabyDockController GetBabyDock() {
        Transform sourceTransform = GlobalConfig.Instance.PlayerCamera.transform;
        Vector3 forward = sourceTransform.TransformDirection(Vector3.forward) * 100f;

        RaycastHit[] hits;
        hits = Physics.RaycastAll(sourceTransform.position, forward, 100.0F);
        Debug.DrawRay(GlobalConfig.Instance.Player.transform.position, forward, Color.green);
        int i = 0;
        while (i < hits.Length) {
            RaycastHit hit = hits[i];

            BabyDockController babyDock = hit.collider.gameObject.GetComponent<BabyDockController>();
            if (babyDock != null) {
                return babyDock;
            }
            i++;
        }
        return null;
    }
}
