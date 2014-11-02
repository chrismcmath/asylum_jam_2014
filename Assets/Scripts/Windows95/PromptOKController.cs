using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PromptOKController : ClickableUIController{
    public InputField PasswordInput;
    public GameObject ErrorMsg;

    public override void OnClicked() {
        Debug.Log("got " + PasswordInput.value);

        if (!GlobalConfig.Instance.WindowsController.OnCheckPassword(PasswordInput.value)) {
            ErrorMsg.SetActive(true);
        } else {
            //Prompt.SetActive(false);
        }
    }
}
