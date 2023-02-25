using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 600.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    // 当たった時に呼ばれる関数
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PanelPrefab")
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        if (collision.gameObject.name == "JumpPanelPrefab")
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce * 2);
        }
    }
}
