using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public float speed = 20;
    [SerializeField] public bool state = true;
    [SerializeField] float limit = 50;
    public float Limit => limit;

    public void GameOver() {
        state = false;
    }

    public void IncreaseSpeed() {
        if (speed < limit) {
            speed += 1;
        }
    }
}
