using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance;

    public string CurrentName;
    public string BestName;
    public int BestScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        loadDataAndScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string BestName;
        public int BestScore;
    }

    public void SaveDataAndScore()
    {
        SaveData data = new SaveData();
        data.BestName = BestName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadDataAndScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestName = data.BestName;
            BestScore = data.BestScore;
        }
    }


}
