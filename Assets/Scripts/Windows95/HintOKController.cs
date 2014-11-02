using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HintOKController : ClickableUIController {
    public GameObject Hint;
    public override void OnClicked() {
        Hint.SetActive(false);
    }
}
