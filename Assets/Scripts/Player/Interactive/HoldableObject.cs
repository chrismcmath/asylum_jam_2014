using UnityEngine;
using System.Collections;

public abstract class HoldableObject : InteractiveObject {
    protected  bool _IsHeld = false;

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
}
