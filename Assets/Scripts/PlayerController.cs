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
        isFalling = rb.velocity.y < 0;

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

    // 衝突したとき
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 落下中でなければ
        if (!isFalling) return;

        // 接触したオブジェクトのタグが"JumpFloor"の場合
        if (collision.gameObject.CompareTag("JumpFloor"))
        {
            // 上方向に力を加える
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * this.jumpForce);
        }

        // 接触したオブジェクトのタグが"SuperJumpFloor"の場合
        if (collision.gameObject.CompareTag("SuperJumpFloor"))
        {
            // 上方向に力を加える
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * this.jumpForce * 1.45f);
        }
    }

    void MovePlayer()
    {
        // 矢印キーの入力を取得
        float moveHorizontal = Input.GetAxis("Horizontal");
        // スマホの傾きを取得
        float moveTilt = Input.acceleration.x;

        // 横方向の力を計算
        float moveForce = moveHorizontal + moveTilt;

        // Rigidbody2Dコンポーネントを取得して、プレイヤーに力を加える
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(moveForce * moveSpeed, 0f));
    }

}