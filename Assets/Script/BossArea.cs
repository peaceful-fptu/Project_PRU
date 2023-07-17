using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArea : MonoBehaviour
{
    public GameObject objBoss;
    public Animator anim;
    public GameObject CanvasBoss;
    void Start()
    {

        CanvasBoss.SetActive(false);
        anim.SetBool("no", true);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (objBoss.GetComponent<Boss>().health <= 0) return;
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("no", false);
            print("Boss is coming!");
            CanvasBoss.SetActive(true);
        }
    }

    bool isBossPos = false;
  
    private void OnTriggerExit2D(Collider2D other)
    {
        if (objBoss.GetComponent<Boss>().health <= 0) return;
        if (other.CompareTag("Player"))
        {
            if(!isBossPos)
            {
                anim.SetBool("no", true);
                CanvasBoss.SetActive(false);
            }
            
            print("Boss");
        }
    }

}
