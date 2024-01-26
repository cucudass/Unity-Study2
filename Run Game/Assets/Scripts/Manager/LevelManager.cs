using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static float spawnTime = 2.5f;
    [SerializeField] float decreaseTime = 0.075f;

    public void ControlLevel() {
        //0.075�� ���� 0.25�� �Ǹ� �������� ����
        if (spawnTime >= 0.25f)
            spawnTime -= decreaseTime;
    }
}
