using UnityEngine;
using System.Collections;

public class ChildDoorOpener : InteractiveObject {
    public override bool OnAction() {
        GlobalConfig.Instance.ChildDoor.OpenChildDoor();
        return false;
    }
}
