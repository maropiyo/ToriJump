using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    // スコア
    public static int score;

    // プレイヤーのTransform
    public Transform player;
    // スコアのテキスト
    public TextMeshProUGUI scoreText;
    // メインカメラ
    public Transform mainCamera;

    // 開始位置
    private float playerStartPositionY;

    void Start()
    {
        // フレームレートを60に設定
        Application.targetFrameRate = 60;
        // プレイヤーの開始高さを取得
        playerStartPositionY = player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        WrapObject();

        UpdateScore();
    }

    private void WrapObject()
    {
        // プレイヤーがメインカメラの範囲外（下）に行った場合
        if (player.position.y < mainCamera.position.y - 5.5)
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
        // ハイスコアを取得する
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        //  スコアがハイスコアより高ければハイスコアを更新する
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
}
