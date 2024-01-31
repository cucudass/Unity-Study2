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
        
    }

    IEnumerator IncreaseScore() {
        yield return CoroutineCache.waitForSeconds(0.25f);
    }
}
