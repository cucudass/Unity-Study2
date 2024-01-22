using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadBox : CollisionObject {
    [SerializeField] UnityEvent callback;

    public override void Activate(Runner runner) {
        callback.Invoke();
    }
}
