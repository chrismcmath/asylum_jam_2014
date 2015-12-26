using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PromptOKController : ClickableUIController{
    public InputField PasswordInput;
    public GameObject ErrorMsg;
    public GameObject TextHighlight;

    public override void OnClicked() {
        Debug.Log("got " + PasswordInput.text);

        GlobalConfig.Instance.IsTyping = false;
        TextHighlight.SetActive(false);

        if (!GlobalConfig.Instance.WindowsController.OnCheckPassword(PasswordInput.text)) {
            ErrorMsg.SetActive(true);
        } else {
            //Prompt.SetActive(false);
        }
    }
}
