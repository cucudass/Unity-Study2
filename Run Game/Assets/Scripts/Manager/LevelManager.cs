using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static float spawnTime = 2.5f;
    [SerializeField] float decreaseTime = 0.075f;

    public void ControlLevel() {
        //0.075씩 감소 0.25가 되면 감소하지 않음
        if (spawnTime >= 0.25f)
            spawnTime -= decreaseTime;
    }


    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        spawnTime = 2.5f;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
