using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LayTenPlayer : MonoBehaviour
{
    public Text txtName;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        if (AboutPlayer._Instance)
            txtName.text = AboutPlayer._Instance.txtTen; // gan ten cho nhan vat
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.position; // gan vi cho bang vi tri cua target
    }
}
