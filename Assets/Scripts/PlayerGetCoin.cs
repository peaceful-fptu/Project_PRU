﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            AboutPlayer._Instance.score += 20; // an xu + 20 score
        }
    }
}
