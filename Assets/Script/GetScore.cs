using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    // Lay score hien tai va hien thi len man hinh
    public Text txtScore;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (AboutPlayer._Instance)
            txtScore.text = "" + AboutPlayer._Instance.score;
    }
}
