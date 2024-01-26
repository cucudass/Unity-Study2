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
        string json = JsonUtility.ToJson(data); //data 객체를 JSON 문자열로 직렬화
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json); //JSON 문자열을 UTF-8 형식의 바이트 배열로 인코딩
        string code = System.Convert.ToBase64String(bytes); //바이트 배열을 Base64 문자열로 변환

        File.WriteAllText(Application.persistentDataPath + "/GameData.json", code);
    }

    public void Load() {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/GameData.json");
        byte[] bytes = System.Convert.FromBase64String(jsonData); //Base64로 인코딩된 문자열을 바이트 배열로 디코딩
        string code = System.Text.Encoding.UTF8.GetString(bytes); //바이트 배열을 UTF-8 문자열로 디코딩

        data = JsonUtility.FromJson<Data>(code); //JSON 문자열을 역직렬화하여 Data 객체로 변환
    }
}
