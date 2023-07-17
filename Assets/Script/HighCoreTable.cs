using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighCoreTable : MonoBehaviour
{
    public Transform entryContainer,entryTemplate;
    List<HighscoreEntry> highscoreList;
    List<Transform> highscoreEntryTransformList;
    private void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

       
        highscoreEntryTransformList = new List<Transform>();
        //highscoreList = new List<HighscoreEntry>()
        //{
        //    new HighscoreEntry{ score = 1234, name ="AA1"},
        //    new HighscoreEntry{ score = 2234, name ="AA2"},
        //    new HighscoreEntry{ score = 3234, name ="AA3"},
        //    new HighscoreEntry{ score = 5234, name ="AA4"},
        //    new HighscoreEntry{ score = 4234, name ="AA5"},
        //    new HighscoreEntry{ score = 6234, name ="AA6"},

        //};
        
        //Highscores highscores = new Highscores { highscoreList=highscoreList };
        //string json = JsonUtility.ToJson(highscores);
        //PlayerPrefs.SetString("highscoretable", json);
        //PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("highscoretable"));
    }
    private void Start()
    {

        string jsonString = PlayerPrefs.GetString("highscoretable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        if (string.IsNullOrEmpty(jsonString)) return;
        for (int i = 0; i < highscores.highscoreList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreList.Count; j++)
            {
                if (highscores.highscoreList[j].score > highscores.highscoreList[i].score)
                {
                    // timf diem cao nhat va doi vi tri
                    HighscoreEntry tmp = highscores.highscoreList[i];
                    highscores.highscoreList[i] = highscores.highscoreList[j];
                    highscores.highscoreList[j] = tmp;
                }
            }
        }
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreList)
        {
            createHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
    void createHighScoreEntryTransform(HighscoreEntry highscoreEntry,Transform container, List<Transform> transformslist )
    {
        float templateHeight = 20f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformslist.Count);
        entryTransform.gameObject.SetActive(true);
        int rank = transformslist.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank +""; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2"; break;
            case 3: rankString = "3"; break;
        }
        entryTransform.Find("TextPos").GetComponent<Text>().text = rankString;
        int score = highscoreEntry.score;

        entryTransform.Find("TextScore").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("TextName").GetComponent<Text>().text = name;


        transformslist.Add(entryTransform);
    }
    public void AddHighscore(int score, string name)
    {
        HighscoreEntry hi = new HighscoreEntry {score=score,name=name };
        string jsonString = PlayerPrefs.GetString("highscoretable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreList.Add(hi);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoretable", json);
        PlayerPrefs.Save();
    }
   public class Highscores
    {
        public List<HighscoreEntry> highscoreList;
    }
    [System.Serializable]
    public class HighscoreEntry
        {
        public int score;
        public string name;
        }
}
