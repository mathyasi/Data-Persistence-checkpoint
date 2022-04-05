using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string PlayerName { get; set; }
    public string Score { get; set; }

    public string HighScoreName { get; private set; }
    public int HighScore { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    [System.Serializable]
    private class SaveData
    {
        public string HighScoreName = "";
        public int HighScore = 0;
    }

    
    public void SaveHighScore(string PlayerNameNow,int ScoreNow)
    {
        SaveData data = new SaveData();
        if (HighScore < ScoreNow)
        {
            HighScoreName = PlayerNameNow;
            HighScore = ScoreNow;
        }
        data.HighScoreName = HighScoreName;
        data.HighScore = HighScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            HighScoreName = data.HighScoreName;
            HighScore = data.HighScore;
        }
    }
}
