using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ジャンプ時の効果音
    public AudioClip se1;
    // スーパージャンプ時の効果音
    public AudioClip se2;

    // プレイヤーの移動速度
    public float moveSpeed = 5.0f;
    // ジャンプ力
    public float jumpForce = 800f;

    // 通常時の画像
    private Sprite characterImage;
    // ジャンプ時の画像
    private Sprite characterJumpImage;

    // プレイヤーのRigidbody2D
    private Rigidbody2D rb;
    // プレイヤーのSpriteRenderer
    private SpriteRenderer sr;

    // キャラクター情報のリスト
    private List<CharacterData> characterDataList;


    // 落下中か
    private bool isFalling = false;

    void Start()
    {
        // ScriptableObjectをロード
        characterDataList = Resources.Load<CharacterList>("CharacterList").characters;

        // 選択されたキャラクター情報を探す
        string selectedCharacterId = PlayerPrefs.GetString("SelectedCharacter", "normal_inko");
        CharacterData selectedCharacter = characterDataList.Find(c => c.Id == selectedCharacterId);

        // 選択されたキャラクターの画像をセットする
        characterImage = selectedCharacter.Image;
        characterJumpImage = selectedCharacter.JumpImage;

        this.rb = GetComponent<Rigidbody2D>();
        this.sr = GetComponent<SpriteRenderer>();
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

        // 接触したオブジェクトのタグが"Floor"の場合
        if (collision.gameObject.CompareTag("Floor"))
        {
            // 上方向に力を加える
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * this.jumpForce);

            // ジャンプ時の効果音を鳴らす
            SoundManager.Instance.PlayJumpSound();
        }

        // 接触したオブジェクトのタグが"JumpFloor"の場合
        if (collision.gameObject.CompareTag("JumpFloor"))
        {
            // 上方向に力を加える
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * this.jumpForce * 1.45f);

            // ジャンプ時の効果音を鳴らす
            SoundManager.Instance.PlaySuperJumpSound();
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
            sr.sprite =  characterJumpImage;
        }
        else
        {
            sr.sprite = characterImage;
        }
    }
}
