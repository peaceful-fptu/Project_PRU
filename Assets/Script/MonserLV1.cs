using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonserLV1 : MonoBehaviour
{

    public float forceX = 2f;
    public bool IsLookRight;
    private Animator anim;
    private Rigidbody2D myBody;
    private bool collision;
    [SerializeField]
    private CircleCollider2D circleCollider;
    [SerializeField]
    private Transform startPos, endPos;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        IsLookRight = true;
        StartCoroutine(autoAttack());

    }

    // Update is called once per frame
    void Update()
    {
        if (myBody.velocity.x > 0 && transform.localScale.x == 1)
        {
            IsLookRight = true;
        }

        if (myBody.velocity.x < 0 && transform.localScale.x == -1)
        {
            IsLookRight = false;
        }
        if (GetComponent<AboutEnemy>().health <= 0)
        {
            Destroy(gameObject);
            if (AboutPlayer._Instance) AboutPlayer._Instance.intEnemyKilled++;
        }
    }

    void FixedUpdate()
    {

        Move();
        ChangeDirection();
    }
    void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * forceX;
        anim.SetBool("Walk", true);
    }
    void ChangeDirection()
    {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));

        if (!collision)
        {
            Vector3 temp = transform.localScale;
            if (temp.x == 1f)
            {
                temp.x = -1f;
            }
            else if (temp.x == -1f)
            {
                temp.x = 1f;
            }

            transform.localScale = temp;

        }
        Debug.DrawLine(startPos.position, endPos.position, Color.cyan);
    }

    IEnumerator autoAttack()
    {

        yield return new WaitForSeconds(Random.Range(2, 4));

        anim.SetTrigger("Attack");
        if (isHitPlayer) AboutPlayer._Instance.intHealth -= 5;
        StartCoroutine(autoAttack());
    }
    bool isHitPlayer = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                AboutPlayer._Instance.intHealth -= 5;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHitPlayer = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHitPlayer = false;
        }
    }
}
