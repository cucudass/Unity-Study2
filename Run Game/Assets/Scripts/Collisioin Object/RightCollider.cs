using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollider : MonoBehaviour
{
    bool detector = false;
    public bool Detector => detector;

    private void OnTriggerStay(Collider other) {
        Vehicle vehicle = other.GetComponent<Vehicle>();
        if (vehicle != null)
            detector = true;
    }

    private void OnTriggerExit(Collider other) {
        Vehicle vehicle = other.GetComponent<Vehicle>();
        if (vehicle != null)
            detector = false;
    }
}
