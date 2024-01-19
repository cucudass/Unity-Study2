using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Vehicle vehicle = other.GetComponent<Vehicle>();
        if(vehicle != null) {
            vehicle.gameObject.SetActive(false);
        }
    }
}
