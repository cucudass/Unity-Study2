using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPositions; //위치 저장 배열
    [SerializeField] GameObject[] vehicleObject; //차량 오브젝트 배열
    [SerializeField] List<GameObject> Vehicles = new List<GameObject>();
    
    [SerializeField] int random;
    [SerializeField] int randomPosition;
    [SerializeField] int compare = -1;

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
            for (int i = 0; i < Random.Range(1, spawnPositions.Length); i++) {
                random = Random.Range(0, Vehicles.Count);

                while (Vehicles[random].activeSelf) {
                    random = (random + 1) % Vehicles.Count;
                }

                //랜덤으로 위치를 설정하는 변수를 선언한다.
                randomPosition = Random.Range(0, spawnPositions.Length);
                //이전에 저장되어 있던 변수와 랜덤포지션의 값이 같을 경우 중복이 되지 안도록 계산.
                if(compare == randomPosition) {
                    randomPosition = (randomPosition + 1) % spawnPositions.Length;
                }
                //compare 변수에 랜덤으로 생성된 변수의 값을 넣어준다.
                compare = randomPosition;
                //vehicle 오브젝트가 활성화되는 위치를 랜덤으로 설정합니다.
                Vehicles[random].transform.position = spawnPositions[randomPosition].position;

                //랜덤으로 설정된 vehicle 오브젝트를 활성화한다.
                Vehicles[random].SetActive(true);
            }

            if (VehicleActiveSelf()) Create();
            yield return new WaitForSeconds(5f);
        }
    }

    public bool VehicleActiveSelf() {
        int count = 0;
        for (int i = 0; i < Vehicles.Count; i++) {
            if (Vehicles[i].activeSelf) {
                count++;
            }
        }
        if (count == Vehicles.Count) return true;
        else return false;
    }
}
