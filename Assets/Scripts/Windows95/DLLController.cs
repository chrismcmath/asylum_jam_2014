using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DLLController : ClickableUIController {
    public override void OnClicked() {
        Debug.Log("DLLController clicked");

        gameObject.SetActive(false);
    }
}
