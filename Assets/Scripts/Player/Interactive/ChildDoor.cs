using UnityEngine;
using System.Collections;

public class ChildDoor : DoorObject {
    public AudioSource OpenNoise;

    public override bool OnAction() {
        return false;
    }

    public void OpenChildDoor() {
        OpenNoise.Play();
        OpenDoor = true;
    }
}
