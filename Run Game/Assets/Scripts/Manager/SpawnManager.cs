using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPositions; //��ġ ���� �迭
    [SerializeField] GameObject[] vehicleObject; //���� ������Ʈ �迭
    [SerializeField] List<GameObject> Vehicles = new List<GameObject>();

    [SerializeField] int count;
    [SerializeField] int random;
    [SerializeField] int randomPosition;

    void Start()
    {
        Vehicles.Capacity = 20;
        Create();

        StartCoroutine(ActiveVehicle());
    }
    
    public void Create() {
        for (int i = 0; i < vehicleObject.Length; i++) {
            GameObject vehicle = Instantiate(vehicleObject[i]);
            vehicle.SetActive(false);
            Vehicles.Add(vehicle);
        }
    }

    IEnumerator ActiveVehicle() {
        while (true) {
            random = Random.Range(0, vehicleObject.Length);

            while (Vehicles[random].activeSelf) {
                count++;
                if (count >= vehicleObject.Length) yield break; //�ڷ�ƾ Ż��

                random = (random + 1) % vehicleObject.Length;
            }

            GameObject vehicle = Vehicles[random];
            vehicle.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
            vehicle.transform.Rotate(0, 180, 0);
            vehicle.SetActive(true);

            yield return new WaitForSeconds(5f);
        }
    }
}
