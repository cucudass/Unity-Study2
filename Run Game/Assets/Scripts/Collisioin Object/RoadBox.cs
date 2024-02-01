using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadBox : CollisionObject {
    [SerializeField] float initSpeed;
    [SerializeField] UnityEvent callback;

    private void Start() {
        initSpeed = GameManager.instance.speed;
    }

    public override void Activate(Runner runner) {
        runner.animator.speed = GameManager.instance.speed / initSpeed;

        callback.Invoke();
        GameManager.instance.IncreaseSpeed();
    }
}
