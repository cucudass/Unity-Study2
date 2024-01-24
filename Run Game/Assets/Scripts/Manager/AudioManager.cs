using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SoundScene { Title, Game }
public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] SoundScene soundScene;
    [SerializeField] AudioSource scenerySource;
    [SerializeField] AudioSource effectSource;
    
    public void EffectSound(AudioClip audioClip) {
        effectSource.PlayOneShot(audioClip);
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        soundScene = (SoundScene)scene.buildIndex;

        scenerySource.clip = Resources.Load<AudioClip>(soundScene.ToString() + " Sound");
        scenerySource.loop = true;
        scenerySource.Play();
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
