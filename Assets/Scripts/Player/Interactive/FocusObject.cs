using UnityEngine;
using System.Collections;
using TinyTween;

public class FocusObject : HoldableObject {
    public Transform ViewAnchor;

    public override bool OnPickUp() {
        GlobalConfig.Instance.Player.GetComponent<PlayerController>().Focus(ViewAnchor);

        return true;
    }

    public override bool OnPutDown() {
        GlobalConfig.Instance.Player.GetComponent<PlayerController>().Defocus();

        return true;
    }

}
