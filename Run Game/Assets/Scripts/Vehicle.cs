using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vehicle : CollisionObject {
    [SerializeField] float speed;
    Vector3 direction;

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    private void OnEnable() {
        speed = GameManager.instance.speed + Random.Range(5, 15);
        direction = Vector3.forward;
    }

    void Update()
    {
        Move();
    }

    void Move() {
        if (!GameManager.instance.state) return;

        transform.Translate(direction * speed * Time.deltaTime);
    }

    public override void Activate(Runner runner) {
        runner.animator.Play("Die");
        GameManager.instance.GameOver();
    }
}
