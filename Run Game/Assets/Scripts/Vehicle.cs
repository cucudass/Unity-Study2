using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vehicle : CollisionObject {
    [SerializeField] float speed = 5.0f;
    Vector3 direction;

    private void OnEnable() {
        direction = Vector3.forward;
    }

    void Update()
    {
        Move();
    }

    void Move() {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public override void Activate(Runner runner) {
        Debug.Log("Game Over");
    }
}
