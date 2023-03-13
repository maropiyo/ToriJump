using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    // スコア
    public static int score;

    // メインカメラ
    public Camera mainCamera;
    // プレイヤーのTransform
    public Transform player;
    // スコアのテキスト
    public TextMeshProUGUI scoreText;
    // ハイスコアのテキスト
    public TextMeshProUGUI highScoreText;

    // 開始位置
    private float playerStartPositionY;
    // ハイスコア
    private int highScore;
    // プレイヤーの大きさ
    private Vector2 playerSize;

    void Start()
    {
        // フレームレートを60に設定
        Application.targetFrameRate = 60;
        
        //　プレイヤーのサイズを取得
        playerSize = GetComponent<SpriteRenderer>().bounds.size;

        // プレイヤーの開始高さを取得
        playerStartPositionY = player.position.y;

        // スコアをリセット
        score = 0;
        // ハイスコアを取得
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = $"High: {highScore}";
    }

    void Update()
    {
        CheckPlayerPosition();

        UpdateScore();
    }

    private void CheckPlayerPosition()
    {
        // ワールド座標をビューポート座標に変換する
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(player.position);

        // ビューポート座標が画面外にある場合
        if (viewportPosition.x < 0f || 1f < viewportPosition.x)
        {
            // 反対側にワープする
            Vector3 newPosition = player.position;

            if (viewportPosition.x < 0f)
            {
                newPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;
            }
            else if (viewportPosition.x > 1f)
            {
                newPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
            }
            player.position = newPosition;
        }

        // プレイヤーがメインカメラの範囲外（下）に行った場合
        if (player.position.y < mainCamera.GetComponent<Transform>().position.y - 5.5)
        {
            // ハイスコアを更新する
            UpdateHighScore();

            // リザルト画面に遷移
            SceneManager.LoadScene("ResultScene");
        }
    }

    private void UpdateScore()
    {
        // プレイヤーが開始位置を超えるまでは何もしない
        if (player.position.y < playerStartPositionY) return;

        // スコアを取得
        int currentScore = ((int)((player.position.y - playerStartPositionY) * 50));

        // スコアが更新された場合
        if (currentScore > score)
        {
            // スコアを更新する
            score = currentScore;
            scoreText.text = $"Score: {currentScore}";
        }
    }

    // ハイスコアを更新する
    private void UpdateHighScore()
    {
        //  スコアがハイスコアより高ければハイスコアを更新する
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
}
