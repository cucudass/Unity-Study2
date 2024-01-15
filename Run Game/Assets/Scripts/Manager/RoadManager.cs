using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roadList;
    [SerializeField] float speed = 5.0f;
    GameObject newRoad;
    float newZ;
    void Start()
    {
        roadList.Capacity = 10;
    }
    
    void Update()
    {
        Move();
    }

    void Move() {
        for (int i = 0; i < roadList.Count; i++) {
            roadList[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    public void NewPosition() {
        newRoad = roadList[0];
        roadList.RemoveAt(0);
        newZ = roadList[2].transform.position.z;

        newRoad.transform.position = roadList[2].transform.position + Vector3.forward * newZ;
        roadList.Add(newRoad);
    }
}
