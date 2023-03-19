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

    // メインカメラのTransform
    private Transform mainCameraTransform;
    // 開始高さ
    private float playerStartPositionY;
    // ハイスコア
    private int highScore;

    void Start()
    {
        // フレームレートを60に設定
        Application.targetFrameRate = 60;

        // スコアをリセット
        score = 0;
        // ハイスコアを取得
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = $"High: {highScore}m";

        // メインカメラのTransformを取得
        mainCameraTransform = mainCamera.GetComponent<Transform>();

        // プレイヤーの開始高さを取得
        playerStartPositionY = player.position.y;
    }

    void Update()
    {
        CheckPlayerPosition();

        UpdateScore();
    }

    private void CheckPlayerPosition()
    {
        // プレイヤーのワールド座標をビューポート座標に変換する
        Vector3 playerViewportPosition = mainCamera.WorldToViewportPoint(player.position);

        // プレイヤーがメインカメラの範囲外（左右）に行った場合
        if (playerViewportPosition.x < 0f || 1f < playerViewportPosition.x)
        {
            // 反対側にワープする
            Vector3 newPosition = player.position;

            if (playerViewportPosition.x < 0f)
            {
                newPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;
            }
            else if (playerViewportPosition.x > 1f)
            {
                newPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
            }
            player.position = newPosition;
        }

        // プレイヤーがメインカメラの範囲外（下）に行った場合
        if (player.position.y < mainCameraTransform.position.y - 5.5)
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
            scoreText.text = $"Score: {currentScore} m";
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
