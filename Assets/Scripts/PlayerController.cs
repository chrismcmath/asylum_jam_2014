using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private MovementActivator _MovementActivator;

    private Vector3 _FormerPosition;
    private Quaternion _FormerRotation;
    
    public void Awake() {
        _MovementActivator = gameObject.GetComponent<MovementActivator>();
        if (_MovementActivator == null) {
            Debug.Log("ERROR Could not get _MovementActivator on PlayerController");
        }
    }

    public void Focus(Transform focus) {
        _MovementActivator.Deactivate();

        _FormerPosition = transform.position;
        _FormerRotation = transform.rotation;
        TweenTransform tween = gameObject.AddComponent<TweenTransform>();
        tween.TweenPosition(_FormerPosition, focus.position, GlobalConfig.Instance.FocusObjectTweenTime);
        tween.TweenRotation(_FormerRotation, focus.rotation, GlobalConfig.Instance.FocusObjectTweenTime);
    }
    public void Defocus() {
        StartCoroutine(ReactivatePlayerMovement());

        TweenTransform tween = gameObject.AddComponent<TweenTransform>();
        tween.TweenPosition(transform.position, _FormerPosition, GlobalConfig.Instance.FocusObjectTweenTime);
        tween.TweenRotation(transform.rotation, _FormerRotation, GlobalConfig.Instance.FocusObjectTweenTime);
    }

    private IEnumerator ReactivatePlayerMovement() {
        yield return new WaitForSeconds(GlobalConfig.Instance.FocusObjectTweenTime);

        _MovementActivator.Activate();
    }
}
