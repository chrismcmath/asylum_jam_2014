using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ErrorController : ClickableUIController {
    public GameObject DLLMessage;

    public override void OnClicked() {
        Debug.Log("set dll to on");
        DLLMessage.SetActive(true);
    }
}
