using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    [SerializeField]
    private int dmg = 25;

    [SerializeField]
    private float speed;

    private Rigidbody2D myBody;

    private Vector2 direction;

    private bool lookRight;

    private AwakeMonser Monster;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        Monster = GetComponent<AwakeMonser>();
    }

    // Use this for initialization
    void Start()
    {
    }

    public void Initialized(Vector2 direction)
    {
        this.direction = direction;
    }

    private void FixedUpdate()
    {
        Invoke("DestroyWeapon", 1.5f);
        myBody.velocity = direction * speed;
    }

    void DestroyWeapon()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            AboutPlayer._Instance.intHealth -= dmg;
        }
    }
}
