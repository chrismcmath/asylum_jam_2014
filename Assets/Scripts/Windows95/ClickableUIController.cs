using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class ClickableUIController : MonoBehaviour {
    private RectTransform _Transform;

    public void Awake() {
        _Transform = transform as RectTransform;
    }

    public void MouseDown(Vector2 position) {
        float minX = _Transform.anchoredPosition.x - (_Transform.rect.width/2);
        float maxX = _Transform.anchoredPosition.x + (_Transform.rect.width/2);
        float minY = _Transform.anchoredPosition.y - (_Transform.rect.height/2);
        float maxY = _Transform.anchoredPosition.y + (_Transform.rect.height/2);

        Debug.Log(gameObject.name + " x: [" + minX + ", " + maxX + "], y: [" + minY + ", " + maxY + "], against " + position);

        if (position.x > minX &&
                position.x < maxX &&
                position.y > minY &&
                position.y < maxY) {
            OnClicked();
        } else {
            Debug.Log("no");
        }
    }

    public abstract void OnClicked();
}
