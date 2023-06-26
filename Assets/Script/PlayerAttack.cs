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
            if(AboutPlayer._Instance.intHealth <= 0) return;  // neu mau player < = 0 thi k cho dung skill nua
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.J))
        {
            // chém
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.K))
        {
            // chém 1
            if(unlockAttack1) // neu ky nang nay duoc mo khoa
            Attack1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.L))
        {
            // chém 1
            if (unlockAttack2) // neu ky nang nay duoc mo khoa
                Attack2();
        }
    }
    void Attack()
    {
        // play attack animation
        anim.SetTrigger("Attack");
       Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            if(enemy.CompareTag("Boss")) // neu tan cong vao boss
            {
                enemy.GetComponent<Boss>().health = enemy.GetComponent<Boss>().health - 10;
            }
            if(enemy.GetComponent<AboutEnemy>())
            {
                enemy.GetComponent<AboutEnemy>().health-= 5;
            }
        }
    }

    void Attack1()
    {
        // play attack animation
        anim.SetTrigger("Attack1");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            if (enemy.CompareTag("Boss")) // neu tan cong vao boss
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
    public Transform posDan;//vi tri dan xuat hien
    int soDan = 0;
    bool isDangNapDan = false;
    void Attack2()
    {

        // tao ra dan
        soDan++;
        // ban nhieu nhat 1 luc 3 vien dan
        // play attack animation
        if (soDan > 3)
        {
            if(!isDangNapDan)
            {
                isDangNapDan = true;
                Invoke("NapDan", 3.0f);// nap lai dan sau 3s
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
