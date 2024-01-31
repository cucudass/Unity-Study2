using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public void Resume() {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    public void Settings() {

    }

    public void Exit() {
        StartCoroutine(AsyncSceneLoader.instance.AsyncLoad(SceneID.TITLE));
    }
}
