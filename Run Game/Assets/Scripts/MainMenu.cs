using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Execute() {
        StartCoroutine(AsyncSceneLoader.instance.AsyncLoad(SceneID.GAME));
    }
}
