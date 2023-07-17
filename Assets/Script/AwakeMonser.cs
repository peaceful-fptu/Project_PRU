using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeMonser : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform bulletPos;
    private MonserLV1 Monster;

    [SerializeField]
    private bool IsRight;

    // Use this for initialization
    [System.Obsolete]
    void Start()
    {
        Monster = FindObjectOfType<MonserLV1>();

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void HandleWeapon()
    {
        if (Monster.IsLookRight)
        {
            GameObject temp = (GameObject)Instantiate(bullet, bulletPos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp.GetComponent<Bullet>().Initialized(Vector2.right);

        }
        else
        {
            GameObject temp = (GameObject)Instantiate(bullet, bulletPos.position, Quaternion.Euler(new Vector3(0, 0, -180)));
            temp.GetComponent<Bullet>().Initialized(Vector2.left);
        }
    }
}
