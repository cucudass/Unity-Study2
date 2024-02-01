using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vehicle : MonoBehaviour {
    [SerializeField] float speed;
    Vector3 direction;

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    private void OnEnable() {
        direction = Vector3.forward;

        GameManager.instance.ControlRandomSpeed();
        speed = GameManager.instance.speed + Random.Range(GameManager.instance.minRandomSpeed, GameManager.instance.maxRandomSpeed);
    }

    void Update()
    {
        Move();
    }

    void Move() {
        if (!GameManager.instance.state) return;

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
