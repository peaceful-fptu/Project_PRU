using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayerShow : MonoBehaviour
{
    public Slider healthBar;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (AboutPlayer._Instance)
        {
            healthBar.value = AboutPlayer._Instance.intHealth;
            // chet
            if (AboutPlayer._Instance.intHealth == 0)
            {
                GetComponent<PlayerMovement>().enabled = false;
                anim.SetBool("IsDie", true);
            }
        }
    }
}
