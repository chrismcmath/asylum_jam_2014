using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PromptInputController : ClickableUIController{
    public InputField PasswordInput;
    public GameObject TextHighlight;

    public override void OnClicked() {
        EventSystem.current.SetSelectedGameObject(PasswordInput.gameObject, null);
        PasswordInput.OnPointerClick(new PointerEventData(EventSystem.current));
        GlobalConfig.Instance.IsTyping = true;
        TextHighlight.SetActive(true);
    }
}
