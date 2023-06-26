using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static HighCoreTable;

public class ThangThua : MonoBehaviour
{
    GameObject player;
    public GameObject objThatBai;
    // Start is called before the first frame update
    void Start()
    {
        objThatBai.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -2.5f)
        {

            if (AboutPlayer._Instance.intHealth != 0)
            {
                AboutPlayer._Instance.intHealth = 0;
                AddHighscore(AboutPlayer._Instance.score, AboutPlayer._Instance.txtTen);
            }

        }
        if (AboutPlayer._Instance.intHealth <= 0)
        {
            player.GetComponent<Rigidbody2D>().simulated = false;
            if (!objThatBai.activeInHierarchy)
            {
                objThatBai.SetActive(true);

            }
        }
    }
    public void OnClickButtonChoiLai()
    {

        SceneManager.LoadScene("Start");

    }
    public void OnClickButtonChienThang()
    {
        SceneManager.LoadScene("Start");
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
