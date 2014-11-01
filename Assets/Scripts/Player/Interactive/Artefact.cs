using UnityEngine;
using System.Collections;

public class Artefact : HoldableObject {
    public string Key;

    public override void OnPickUp() {
        ArtefactCreator.Instance.Create(Key);
    }

    public override void OnPutDown() {
        ArtefactCreator.Instance.Destroy();
    }
}
