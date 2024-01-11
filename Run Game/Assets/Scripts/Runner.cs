using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine { LEFT = -1, MIDDLE, RIGHT }

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;
    [SerializeField] float positionX = 3.5f;

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    void Update()
    {
        Move();
        State();
    }

    public void Move() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if(roadLine > RoadLine.LEFT) roadLine--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if(roadLine < RoadLine.RIGHT) roadLine++;
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
        transform.position = new Vector3(positionX, 0, 0);
    }
}
