using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Data {
    public int score;
}

public class DataManager : Singleton<DataManager>
{
    public Data data = new Data();

    private void Start() {
        Load();
    }

    public void Save() {
        string json = JsonUtility.ToJson(data); //data ��ü�� JSON ���ڿ��� ����ȭ
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json); //JSON ���ڿ��� UTF-8 ������ ����Ʈ �迭�� ���ڵ�
        string code = System.Convert.ToBase64String(bytes); //����Ʈ �迭�� Base64 ���ڿ��� ��ȯ

        File.WriteAllText(Application.persistentDataPath + "/GameData.json", code);
    }

    public void Load() {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/GameData.json");
        byte[] bytes = System.Convert.FromBase64String(jsonData); //Base64�� ���ڵ��� ���ڿ��� ����Ʈ �迭�� ���ڵ�
        string code = System.Text.Encoding.UTF8.GetString(bytes); //����Ʈ �迭�� UTF-8 ���ڿ��� ���ڵ�

        data = JsonUtility.FromJson<Data>(code); //JSON ���ڿ��� ������ȭ�Ͽ� Data ��ü�� ��ȯ
    }
}
