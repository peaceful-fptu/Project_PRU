using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutPlayer : MonoBehaviour
{
    public static AboutPlayer _Instance;
    public int intHealth = 100;
    public string txtTen;
    public int score = 0;
    public int intEnemyKilled = 0; // so quai giet duoc
    // Start is called before the first frame update
    void Awake()
    {

        if (_Instance == null)
        {

            _Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    public void KhoiTao()
    {
        intHealth = 100;
        score = 0;
        intEnemyKilled = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (intHealth <= 0)
        {
            intHealth = 0;
        }
    }
}
