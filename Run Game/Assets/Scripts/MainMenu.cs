using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void Execute() {
        animator.SetTrigger("Start");
        StartCoroutine(AsyncSceneLoader.instance.AsyncLoad(SceneID.GAME));
    }
}
