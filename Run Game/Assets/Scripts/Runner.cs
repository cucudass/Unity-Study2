using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine { LEFT = -1, MIDDLE, RIGHT }
public class Runner : MonoBehaviour
{
    public Animator animator;

    [SerializeField] RoadLine roadLine;
    [SerializeField] RoadLine preRoadLine;
    [SerializeField] float positionX = 2.25f;
    [SerializeField] float lerpSpeed = 25.0f;

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
        preRoadLine = RoadLine.MIDDLE;
        InputManager.instance.keyAction += Move;
    }

    void Update()
    {
        State();
    }

    public void Move() {
        if (!GameManager.instance.state) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (roadLine > RoadLine.LEFT) {
                preRoadLine = roadLine--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (roadLine < RoadLine.RIGHT) {
                preRoadLine = roadLine++;
            }
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

    public void RevertPosition() { //이전의 위치로 이동
        roadLine = preRoadLine;
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
