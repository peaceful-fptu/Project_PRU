using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManChoi1 : MonoBehaviour
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
        }
        objDoor.SetActive(false);
        obj.SetActive(true);
        txtHuongDan.text = "";
        story = "Hello! " + AboutPlayer._Instance.txtTen + "" + System.Environment.NewLine + "  " + System.Environment.NewLine + "I need to rescue Princess Isabella immediately" + System.Environment.NewLine + "Is this the only way to get there?" + System.Environment.NewLine + "You can do it...";
        StartCoroutine("PlayText");
        Invoke("SetNotActive", 20f);
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
            if (AboutPlayer._Instance.intEnemyKilled >= intSoEnemyKill) // neu so quai giet lon hon hoac bang so quai de qua man da thiet lap
            {
                if (!objDoor.activeInHierarchy) // neu chua hien thi qua man
                {
                    objDoor.SetActive(true);
                }
            }
        }
    }
}
