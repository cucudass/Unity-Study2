using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine { LEFT = -1, MIDDLE, RIGHT }

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    void Update()
    {
        Move();
    }

    public void Move() {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && roadLine >= 0) {
            roadLine--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && roadLine <= 0) {
            roadLine++;
        }
    }
}
