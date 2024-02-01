using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] Text scoreText;

    void Start()
    {
        StartCoroutine(IncreaseScore());
    }

    IEnumerator IncreaseScore() {
        while (GameManager.instance.state) {
            yield return CoroutineCache.waitForSeconds(0.25f);

            if (!GameManager.instance.state) {
                DataManager.instance.RenewalScore(score);
                yield break;
            }

            score += 10;
            scoreText.text = score.ToString() + "m";
        }
    }
}
