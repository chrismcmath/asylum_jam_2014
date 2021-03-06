﻿using UnityEngine;
using System.Collections;

public class ArtefactCreator : Singleton<ArtefactCreator> {
    public readonly static string PATH_ARTEFACTS = "Artefacts/{0}";

    public void Create(string key) {
        GlobalConfig.Instance.ArtefactRoot.SetActive(true);

        Sprite s = Resources.Load(string.Format(PATH_ARTEFACTS, key), typeof(Sprite)) as Sprite;
        if (s != null) {
            GlobalConfig.Instance.ArtefactImage.sprite = s;
        } else {
            Debug.Log("Could not find artefact with key " + key);
        }

        GlobalConfig.Instance.Player.GetComponent<MovementActivator>().Deactivate();
    }

    public void Destroy() {
        GlobalConfig.Instance.ArtefactRoot.SetActive(false);
        GlobalConfig.Instance.Player.GetComponent<MovementActivator>().Activate();
    }
}
