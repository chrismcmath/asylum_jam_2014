using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CursorController : MonoBehaviour {
    private RectTransform _Transform;

    public float xMin = -120f;
    public float xMax = 120f;
    public float yMin = -120f;
    public float yMax = 120f;

    public void Awake() {
        _Transform = transform as RectTransform;
    }
    public void Update() {
        float targetX = _Transform.anchoredPosition.x + Input.GetAxis("Mouse X");
        float targetY = _Transform.anchoredPosition.y + Input.GetAxis("Mouse Y");
        _Transform.anchoredPosition = new Vector2(
                Mathf.Max(xMin, Mathf.Min(xMax, targetX)),
                Mathf.Max(yMin, Mathf.Min(yMax, targetY)));

        if (Input.GetButtonUp("Action")) {
            OnAction();
        }
    }

    public void OnAction() {
        Debug.Log("Mouse action");
        transform.parent.BroadcastMessage("MouseDown", _Transform.anchoredPosition);
    }
}
