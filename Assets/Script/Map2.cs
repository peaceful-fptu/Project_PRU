using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Map2 : MonoBehaviour
{
    public GameObject obj;
    public Text txtHuongDan;
    string story;
    public int intSoEnemyKill = 8;
    public GameObject objDoor;

    // Start is called before the first frame update
    void Start()
    {
        AboutPlayer._Instance.intEnemyKilled = 0;
        objDoor.SetActive(false);
        /*    obj.SetActive(true); // hien thi huong dan*/
        //     txtHuongDan.text = "";
        /*        story = "Chúc mừng ! " + AboutPlayer._Instance.txtTen + "" + System.Environment.NewLine + "Kỹ năng tấn công nhanh và tung trưởng đã được học " + System.Environment.NewLine + "Hãy tiêu diệt chúng!" + System.Environment.NewLine + "Nhiệm vụ tiêu diệt tất cả quái";
        */
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
