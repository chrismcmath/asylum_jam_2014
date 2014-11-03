using UnityEngine;
using System.Collections;

public class FrontDoorController : DoorObject {
    public override bool OnAction() {
        if (PlayerModel.Instance.HasFrontDoorKey) {
            GlobalConfig.Instance.KeyUI.SetActive(true);
            OpenDoor = true;
        }
        return false;
    }
}
