using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public bool unlockAttack1 = false;
    public bool unlockAttack2 = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    void NapDan()
    {
        soDan = 0;
        isDangNapDan = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (AboutPlayer._Instance)
            if (AboutPlayer._Instance.intHealth <= 0) return;
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (unlockAttack1)
                Attack1();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (unlockAttack2)
                Attack2();
        }
    }
    void Attack()
    {
        anim.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            if (enemy.CompareTag("Boss"))
            {
                enemy.GetComponent<Boss>().health = enemy.GetComponent<Boss>().health - 10;
            }
            if (enemy.GetComponent<AboutEnemy>())
            {
                enemy.GetComponent<AboutEnemy>().health -= 5;
            }
        }
    }

    void Attack1()
    {
        anim.SetTrigger("Attack1");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            if (enemy.CompareTag("Boss"))
            {
                enemy.GetComponent<Boss>().health = enemy.GetComponent<Boss>().health - 20;
            }
            if (enemy.GetComponent<AboutEnemy>())
            {
                enemy.GetComponent<AboutEnemy>().health -= 8;
            }
        }
    }
    public GameObject objDan;
    public Transform posDan;
    int soDan = 0;
    bool isDangNapDan = false;
    void Attack2()
    {
        soDan++;
        if (soDan > 3)
        {
            if (!isDangNapDan)
            {
                isDangNapDan = true;
                Invoke("NapDan", 3.0f);
            }
            return;
        }
        anim.SetTrigger("Attack2");
        Instantiate(objDan, posDan.position, posDan.rotation);

    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
