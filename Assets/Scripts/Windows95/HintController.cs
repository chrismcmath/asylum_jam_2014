using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HintController : ClickableUIController {
    public GameObject Hint;
    public override void OnClicked() {
        Hint.SetActive(true);
    }
}
