using UnityEngine;
using System.Collections;
using TinyTween;

public class ComputerController : FocusObject {
    public override bool OnPickUp() {
        GlobalConfig.Instance.WindowsController.OnFocus();
        return base.OnPickUp();
    }

    public override bool OnPutDown() {
        return false;
        //return base.OnPutDown();
    }

    public void ForceDrop() {
        GlobalConfig.Instance.Player.GetComponent<PlayerController>().Defocus();
        GetComponent<Collider>().enabled = true;
        _IsHeld = false;
    }
}
