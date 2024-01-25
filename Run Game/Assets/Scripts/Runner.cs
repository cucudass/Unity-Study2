using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine { LEFT = -1, MIDDLE, RIGHT }

public class Runner : MonoBehaviour
{
    public Animator animator;

    [SerializeField] RoadLine roadLine;
    [SerializeField] float positionX = 2.25f;
    [SerializeField] float lerpSpeed = 25.0f;
    [SerializeField] LeftCollider leftCollider;
    [SerializeField] RightCollider rightCollider;

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
        InputManager.instance.keyAction += Move;
    }

    void Update()
    {
        State();
    }

    public void Move() {
        if (!GameManager.instance.state) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (leftCollider.Detector) return;
            if (roadLine > RoadLine.LEFT) roadLine--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (leftCollider.Detector) return;
            if (roadLine < RoadLine.RIGHT) roadLine++;
        }
    }

    public void State() {
        switch (roadLine) {
            case RoadLine.LEFT:
                Movement(-positionX);
                break;
            case RoadLine.MIDDLE:
                Movement(0);
                break;
            case RoadLine.RIGHT:
                Movement(positionX);
                break;
        }
    }

    public void Movement(float positionX) {
        transform.position = Vector3.Lerp(transform.position, new Vector3(positionX, 0, 0), Time.deltaTime * lerpSpeed);
    }

    private void OnTriggerEnter(Collider other) {
        CollisionObject collisionObject = other.GetComponent<CollisionObject>();
        if(collisionObject != null) {
            collisionObject.Activate(this);
        }
    }

    private void OnDisable() {
        InputManager.instance.keyAction -= Move;
    }
}
