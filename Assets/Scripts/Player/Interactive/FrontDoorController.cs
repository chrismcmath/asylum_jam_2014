using UnityEngine;
using System.Collections;

public class FrontDoorController : DoorObject {
    public override bool OnAction() {
        if (PlayerModel.Instance.HasFrontDoorKey) {
            GlobalConfig.Instance.KeyUI.SetActive(false);
            OpenDoor = true;
        }
        return false;
    }
}
