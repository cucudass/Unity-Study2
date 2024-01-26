using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPositions; //��ġ ���� �迭
    [SerializeField] GameObject[] vehicleObject; //���� ������Ʈ �迭
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
        while (GameManager.instance.state) {
            for (int i = 0; i < Random.Range(1, spawnPositions.Length); i++) {
                random = Random.Range(0, Vehicles.Count);

                while (Vehicles[random].activeSelf) {
                    if (FullVehicle()) { //���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ �ߴ��� Ȯ��
                        //��� ������Ʈ�� Ȱ��ȭ �Ǿ��ٸ�, ���� ������Ʈ�� �����Ѵ�.
                        GameObject vehicle = Instantiate(vehicleObject[Random.Range(0, vehicleObject.Length)]);
                        vehicle.SetActive(false);

                        Vehicles.Add(vehicle);
                    }
                    random = (random + 1) % Vehicles.Count;
                }

                //�������� ��ġ�� �����ϴ� ������ �����Ѵ�.
                randomPosition = Random.Range(0, spawnPositions.Length);
                //������ ����Ǿ� �ִ� ������ ������������ ���� ���� ��� �ߺ��� ���� �ȵ��� ���.
                if(compare == randomPosition) {
                    randomPosition = (randomPosition + 1) % spawnPositions.Length;
                }
                //compare ������ �������� ������ ������ ���� �־��ش�.
                compare = randomPosition;
                //vehicle ������Ʈ�� Ȱ��ȭ�Ǵ� ��ġ�� �������� �����մϴ�.
                Vehicles[random].transform.position = spawnPositions[randomPosition].position;

                //�������� ������ vehicle ������Ʈ�� Ȱ��ȭ�Ѵ�.
                Vehicles[random].SetActive(true);
            }

            yield return CoroutineCache.waitForSeconds(LevelManager.spawnTime);
        }
    }

    public bool FullVehicle() {
        for (int i = 0; i < Vehicles.Count; i++) {
            if (!Vehicles[i].activeSelf) {
                return false;
            }
        }
        return true;
    }
}
