using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static HighCoreTable;

public class Map3 : MonoBehaviour
{
    public GameObject obj;
    public Text txtHuongDan;
    string story;
    public GameObject objChienThang;
    public GameObject objBoss;
    // Start is called before the first frame update
    void Start()
    {
        AboutPlayer._Instance.intEnemyKilled = 0;
        objChienThang.SetActive(false);
        obj.SetActive(true);
        txtHuongDan.text = "";
        story = "Cẩn thận! " + AboutPlayer._Instance.txtTen + "" + System.Environment.NewLine + "Thắng hay bại chính là ở lần này";
        StartCoroutine("PlayText");
        Invoke("SetNotActive", 10f);
    }
    void SetNotActive()
    {
        obj.SetActive(false);
    }
    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txtHuongDan.text += c;
            yield return new WaitForSeconds(0.125f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (AboutPlayer._Instance)
        {
            if (objBoss.GetComponent<Boss>().health <= 0)
            {
                if (!objChienThang.activeInHierarchy)
                {
                    objChienThang.SetActive(true);
                    AddHighscore(AboutPlayer._Instance.score, AboutPlayer._Instance.txtTen);

                }
            }
        }
    }
    public void AddHighscore(int score, string name)
    {
        HighscoreEntry hi = new HighscoreEntry { score = score, name = name };
        string jsonString = PlayerPrefs.GetString("highscoretable");
        Highscores highscores;
        if (string.IsNullOrEmpty(jsonString))
        {
            highscores = new Highscores();
            highscores.highscoreList = new List<HighscoreEntry>();
        }
        else
            highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreList.Add(hi);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoretable", json);
        PlayerPrefs.Save();
    }
}
