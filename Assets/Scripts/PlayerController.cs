using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // プレイヤーの移動速度
    public float moveSpeed = 5.0f;
    // ジャンプ力
    public float jumpForce = 800f;

    // プレイヤーのRigidbody2D
    private Rigidbody2D rb;

    // 落下中か
    private bool isFalling = false;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 落下中かのフラグを更新する。
        isFalling = rb.velocity.y < 0;

        MovePlayer();

        UpdatePlayerScale();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 落下中でなければ何もしない
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
        rb.AddForce(new Vector2(moveForce * moveSpeed, 0f));
    }

    void UpdatePlayerScale()
    {
        // スケールを取得
        Vector3 scale = transform.localScale;

        // 右方向に移動中
        if (rb.velocity.x > 0)
        {
            scale.x = 0.2f; // そのまま（右向き）

        }

        // 左方向に移動中
        if (rb.velocity.x < 0)
        {
            scale.x = -0.2f; // 反転する（左向き）
        }
        // 代入する
        transform.localScale = scale;
    }
}
