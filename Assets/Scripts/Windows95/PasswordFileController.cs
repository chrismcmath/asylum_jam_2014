using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PasswordFileController : ClickableUIController {
    public override void OnClicked() {
        GlobalConfig.Instance.WindowsController.OnFileClicked();
    }
}
