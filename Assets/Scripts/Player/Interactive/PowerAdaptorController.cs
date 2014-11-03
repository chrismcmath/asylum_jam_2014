using UnityEngine;
using System.Collections;

public class PowerAdaptorController : InteractiveObject {
    public override bool OnAction() {
        PlayerModel.Instance.HasPowerAdaptor = true;
        GlobalConfig.Instance.PowerAdaptorUI.SetActive(true);
        Destroy(gameObject);
        return false;
    }
}
