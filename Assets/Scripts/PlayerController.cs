using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // ジャンプ力
    [SerializeField] private float jumpForce = 1f;

    // プレイヤーのRigidbody2D
    private Rigidbody2D rigid2D;

    // メインカメラ
    private GameObject mainCamera;

    // 落下中か
    private bool isFalling = false;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 落下中かのフラグを更新する。
        isFalling = rigid2D.velocity.y < 0;

        // メインカメラを取得
        mainCamera = Camera.main.gameObject;

        // メインカメラの範囲外に
        if (transform.position.y < mainCamera.transform.position.y - 6)
        {
            SceneManager.LoadScene("ResuleScene");
        }
    }

    // 当たった時に呼ばれる関数
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 接触したオブジェクトのタグが"JumpFloor"かつプレイヤーが落下中の場合
        if (collision.gameObject.CompareTag("JumpFloor") && isFalling)
        {
            // 上方向に力を加える
            rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // 接触したオブジェクトのタグが"SuperJumpFloor"かつプレイヤーが落下中の場合
        if (collision.gameObject.CompareTag("SuperJumpFloor") && isFalling) 
        {
            // 上方向にジャンプ力の２倍の力を加える
            rigid2D.AddForce(transform.up * this.jumpForce * 1.5f);
        }
    }
}