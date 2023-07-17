using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Map1 : MonoBehaviour
{
    public GameObject obj;
    public Text txtHuongDan;
    string story;
    public int intSoEnemyKill = 8;
    public GameObject objDoor;

    // Start is called before the first frame update
    void Start()
    {
        if (AboutPlayer._Instance)
        {
            AboutPlayer._Instance.KhoiTao();
            GetComponent<PlayerMovement>().enabled = false;
        }
        objDoor.SetActive(false);
        obj.SetActive(true);
        txtHuongDan.text = "";
        story = "Hello " + AboutPlayer._Instance.txtTen + System.Environment.NewLine + "Princess Isabella is missing, you must prove yourself a strong and brave hero to confront the monsters." + System.Environment.NewLine + "Use the A, W, D, S keys to move left, jump, right and sit and the J key to attack." + System.Environment.NewLine + "Let's rescue the princess!";
        StartCoroutine("PlayText");
        Invoke("SetNotActive", 30f);
    }
    void SetNotActive()
    {
        obj.SetActive(false);
        GetComponent<PlayerMovement>().enabled = true;
    }
    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txtHuongDan.text += c;
            yield return new WaitForSeconds(0.1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (AboutPlayer._Instance)
        {
            if (AboutPlayer._Instance.intEnemyKilled >= intSoEnemyKill)
            {
                if (!objDoor.activeInHierarchy)
                {
                    objDoor.SetActive(true);
                }
            }
        }
    }
}
