using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonDataManager : MonoBehaviour
{
    [Tooltip("저장하길 원하는 파일 이름 (.json제외)")]
    public string fileName = "JspnSample";

    [System.Serializable]

    public class Data
    {
        public int No;
        public string User;
        public int Score;
    }

    public Data data;

    void Start()
    {
        //data.No = 1;
        //data.User = "test2";
        //data.Score = 1250;

        //SaveDataToJson();

        LoadDataFromeJson();
        Debug.Log(data.No);
        Debug.Log(data.User);
        Debug.Log(data.Score);
        
    }

    void SaveDataToJson()
    {
        string jsonData = "";

        jsonData = JsonUtility.ToJson(data, true);

        File.WriteAllText(Application.dataPath + @"\" + fileName, jsonData);


    }

    void LoadDataFromeJson()
    {
        string jsonData = "";
        jsonData = File.ReadAllText(Application.dataPath + @"\" + fileName);

        data = JsonUtility.FromJson<Data>(jsonData);
    }
}
