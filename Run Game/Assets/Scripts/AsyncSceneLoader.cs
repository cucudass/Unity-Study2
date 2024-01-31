using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SceneID { TITLE, GAME }
public class AsyncSceneLoader : Singleton<AsyncSceneLoader>
{
    [SerializeField] float time;
    [SerializeField] Image fadeImage;

    public IEnumerator FadeIn() {
        Color color = fadeImage.color;
        color.a = 1.0f;

        fadeImage.gameObject.SetActive(true);

        while(color.a > 0f) {
            color.a -= Time.unscaledDeltaTime;
            fadeImage.color = color;

            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
    }

    public IEnumerator AsyncLoad(SceneID sceneID) {
        fadeImage.gameObject.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)sceneID);
        /* bool allowSceneActivation: ����� �غ�Ǵ� ��� ����� Ȱ��ȭ��ų ������ ����ϴ� ���
         * bool isDone: �ش� ������ �غ�Ǿ��� �� �Ǵ��ϴ� ���
         * float progress: �۾��� ���� ������ 0 ~ 1 ������ ������ Ȯ���ϴ� ���
         */
        asyncOperation.allowSceneActivation = false;
        Color color = fadeImage.color;
        color.a = 0f;

        while (!asyncOperation.isDone) {
            color.a += Time.unscaledDeltaTime;
            fadeImage.color = color;

            if(asyncOperation.progress >= 0.9f) {
                // color�� alpha ���� 1.0�� Lerp �Լ��� ���� �÷��ش�.
                color.a = Mathf.Lerp(color.a, 1f, Time.unscaledDeltaTime);
                // alpha ���� 1.0���� ũ�ų� ���ٸ�
                if(color.a >= 1.0f) {
                    //allowSceneActivation�� Ȱ��ȭ
                    asyncOperation.allowSceneActivation = true;
                    yield break;
                }
            }
            yield return null;
        }
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        StartCoroutine(FadeIn());
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
