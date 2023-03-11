using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 通常時のSprite
    [SerializeField] private Sprite normalSprite;
    // ジャンプ時のSprite
    [SerializeField] private Sprite jumpSprite;

    // ジャンプ時の効果音
    public AudioClip se1;
    // スーパージャンプ時の効果音
    public AudioClip se2;

    // プレイヤーの移動速度
    public float moveSpeed = 5.0f;
    // ジャンプ力
    public float jumpForce = 800f;

    // プレイヤーのRigidbody2D
    private Rigidbody2D rb;
    // プレイヤーのSpriteRenderer
    private SpriteRenderer sr;

    // プレイヤーのAudioSource
    private AudioSource audioSource;

    // 落下中か
    private bool isFalling = false;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.sr = GetComponent<SpriteRenderer>();
        this.audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 落下中かのフラグを更新する。
        isFalling = rb.velocity.y < 0;

        MovePlayer();

        UpdatePlayerScale();

        UpdatePlayerImage();
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

            // ジャンプ時の効果音を鳴らす
            audioSource.PlayOneShot(se1);
        }

        // 接触したオブジェクトのタグが"SuperJumpFloor"の場合
        if (collision.gameObject.CompareTag("SuperJumpFloor"))
        {
            // 上方向に力を加える
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * this.jumpForce * 1.45f);

            // ジャンプ時の効果音を鳴らす
            audioSource.PlayOneShot(se2);
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
            scale.x = 0.15f; // そのまま（右向き）

        }

        // 左方向に移動中
        if (rb.velocity.x < 0)
        {
            scale.x = -0.15f; // 反転する（左向き）
        }
        // 代入する
        transform.localScale = scale;
    }

    void UpdatePlayerImage()
    {
        if (!isFalling)
        {
            sr.sprite = jumpSprite;
        }
        else
        {
            sr.sprite = normalSprite;
        }
    }
}
