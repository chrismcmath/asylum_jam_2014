using UnityEngine;
using System.Collections;

public abstract class HoldableObject : InteractiveObject {
    protected  bool _IsHeld = false;

    abstract public void OnPickUp();
    abstract public void OnPutDown();

    public override bool OnAction() {
		if (!_IsHeld) {
            OnPickUp();
            _IsHeld = true;
        } else {
            OnPutDown();
            _IsHeld = false;
        }
        return _IsHeld;
    }
}
