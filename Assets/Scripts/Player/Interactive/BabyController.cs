using UnityEngine;
using System.Collections;

public class BabyController : HoldableObject {
    private Rigidbody _Rigidbody = null;

    public void Awake() {
        _Rigidbody = gameObject.GetComponent<Rigidbody>();

        BabyModel.Instance.AddStateChangeListener(OnStateChange);
    }

    public override bool OnPickUp() {
        _Rigidbody.isKinematic = true;
        transform.parent = GlobalConfig.Instance.PlayerObjectRoot;

        BabyModel.Instance.State = BabyModel.BabyState.HELD;
        
        return true;
    }

    public override bool OnPutDown() {
        _Rigidbody.isKinematic = false;
        transform.parent = GlobalConfig.Instance.SceneRoot;
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
    }
    private void OnBabyCry() {
        Debug.Log("OnBabyCry");
    }

}
