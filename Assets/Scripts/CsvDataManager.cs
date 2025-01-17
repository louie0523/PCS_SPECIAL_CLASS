using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public enum GameScore
{
    No,
    User,
    Score
}
public class CsvDataManager : MonoBehaviour
{
    [SerializeField]
    public TextAsset csvFile;

    char lineSeperator = '\n';

    public class CsvData
    {
        public int No;
        public string User;
        public int Score;
    }

    public Dictionary<string, CsvData> dataDicionary = new Dictionary<string, CsvData>();

    private void Start()
    {
        //#region csv에 자료 추가
        //CsvData test = new CsvData();
        //test.No = 1;
        //test.User = "louie";
        //test.Score = 1250;

        //CsvData test2 = new CsvData();
        //test2.No = 2;
        //test2.User = "test2";
        //test2.Score = 1460;

        //CsvData test3 = new CsvData();
        //test3.No = 3;
        //test3.User = "test3";
        //test3.Score = 1564;

        //dataDicionary.Add("1", test);
        //dataDicionary.Add("2", test2);
        //dataDicionary.Add("3", test3);
        //CreatCSV();
        //#endregion

        CsvToDicionary();

        for(int i = 1; i <= dataDicionary.Count; i++)
        {
            Debug.Log(dataDicionary["" + i + ""].No + "" + dataDicionary["" + i + ""].User + " " + dataDicionary["" + i + ""].Score);
        }








    }

    void CsvToDicionary()
    {
        string[] records = csvFile.text.Split(lineSeperator);

        int lineCount = 0;

        foreach(string record in records)
        {
            lineCount++;

            string[] fields = record.Split(',');

            if (string.IsNullOrEmpty(fields[0]))
            {
                break;
            }

            CsvData objData = new CsvData
            {
                No = int.Parse(fields[0]),   //Parse = 자기형에 따라서 인수를 자기형으로 바꾸겠다. 물론 인수가 자기형으로 바뀔 수 있어야한다. Try를 붙이면 에러를 잡아준다.(뽑아낸다)
                User = fields[1],
                Score = int.Parse(fields[2])
            };

            if(!dataDicionary.ContainsKey(fields[0]))
            {
                dataDicionary.Add(fields[0], objData);
                Debug.Log("Added: " + objData.No);
            } else
            {
                Debug.Log("duplicated object name exists");
            }
        }
    }

    public string GetObjData(string objName, GameScore dataName)
    {
        string data = "";

        if(!dataDicionary.ContainsKey(objName))
        {
            data = "None";
            return data;
        }

        switch(dataName)
        {
            case GameScore.No:
                data = dataDicionary[objName].No.ToString();
                break;
            case GameScore.User:
                data = dataDicionary[objName].User;
                break;
            case GameScore.Score:
                data = dataDicionary[objName].Score.ToString();
                break;
        }

        return data;        
    }

    public void CreatCSV()
    {

        //Debug.Log(Application.dataPath + @"\my.csv");
        //Debug.Log(Application.dataPath + "\\my.csv");
        using (StreamWriter writer = new StreamWriter(Application.dataPath + @"\my.csv"))
        {
            foreach(var data in dataDicionary)
            {
                writer.WriteLine("{0}, {1}, {2}", data.Value.No, data.Value.User, data.Value.Score);
            }
        }
    }
}
