using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Text bestScoreText;

    private void OnEnable() {
        bestScoreText.text = DataManager.instance.data.bestscore.ToString() + "m";
    }

    public void Resume() {
        StartCoroutine(AsyncSceneLoader.instance.AsyncLoad(SceneID.GAME));
    }
}
