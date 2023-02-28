using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // プレイヤーの移動速度
    public float moveSpeed = 5.0f;
    // ジャンプ力
    public float jumpForce = 800f;

    // プレイヤーのRigidbody2D
    private Rigidbody2D rb;

    // メインカメラ
    private GameObject mainCamera;

    // 落下中か
    private bool isFalling = false;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 落下中かのフラグを更新する。
        isFalling = rb.velocity.y <= 0;

        MovePlayer();

        // メインカメラを取得
        mainCamera = Camera.main.gameObject;

        // メインカメラの範囲外（下）に行った場合
        if (transform.position.y < mainCamera.transform.position.y - 5.5)
        {
            // リザルト画面に遷移
            SceneManager.LoadScene("ResultScene");
        }
    }

    // 当たった時に呼ばれる関数
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("1");
        // 接触したオブジェクトのタグが"JumpFloor"かつプレイヤーが落下中の場合
        if (collision.gameObject.CompareTag("JumpFloor") && isFalling)
        {
            Debug.Log("2");
            // 上方向に力を加える
            rb.AddForce(transform.up * this.jumpForce);
        }

        // 接触したオブジェクトのタグが"SuperJumpFloor"かつプレイヤーが落下中の場合
        if (collision.gameObject.CompareTag("SuperJumpFloor") && isFalling) 
        {
            // 上方向にジャンプ力の２倍の力を加える
            rb.AddForce(transform.up * this.jumpForce * 1.5f);
        }
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");  // 矢印キーの入力を取得
        float moveTilt = Input.acceleration.x;                // スマホの傾きを取得

        // 横方向の力を計算
        float moveForce = moveHorizontal + moveTilt;

        // Rigidbody2Dコンポーネントを取得して、プレイヤーに力を加える
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(moveForce * moveSpeed, 0f));
    }

}