using UnityEngine;
using System.Collections;

public class Artefact : InteractiveObject {
    public override bool OnAction() {
        Debug.Log("artefact on action");
        return true;
    }
}
