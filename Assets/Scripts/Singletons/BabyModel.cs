using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BabyModel : Singleton<BabyModel> {
    public enum BabyState {HELD=0, DOWN, CRY};

    public float CryDelay = 5.0f;

    public delegate void OnBabyStateChange(BabyState state);
    public OnBabyStateChange BabyStateChangeListeners;
    private BabyState _State = BabyState.DOWN;
    public BabyState State {
        get { return _State; }
        set {
            if (value != _State) {
                _State = value;
                if (BabyStateChangeListeners != null) {
                    BabyStateChangeListeners(_State);
                }
            }
        }
    }

    public void AddStateChangeListener(OnBabyStateChange callback) {
        BabyStateChangeListeners += callback;
    }
}
