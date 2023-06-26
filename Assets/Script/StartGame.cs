using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public bool nhapTen = false;
    public GameObject obj1, obj2;
    public InputField inputTen;
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
    }
    // Start is called before the first frame update
    void Start()
    {
        nhapTen = false;
        obj1.SetActive(true); obj2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!nhapTen)
            {
                obj1.SetActive(false); obj2.SetActive(true);
            }
        }
    }
    public void LoadScene()
    {
        if (string.IsNullOrEmpty(inputTen.text)) return;
        AboutPlayer._Instance.txtTen = inputTen.text;
        SceneManager.LoadScene("game");
    }
}
