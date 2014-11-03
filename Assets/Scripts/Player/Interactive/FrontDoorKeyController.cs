using UnityEngine;
using System.Collections;

public class FrontDoorKeyController : InteractiveObject {
    public override bool OnAction() {
        PlayerModel.Instance.HasFrontDoorKey = true;
        GlobalConfig.Instance.KeyUI.SetActive(true);
        Destroy(gameObject);
        return false;
    }
}
