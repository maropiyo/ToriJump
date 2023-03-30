using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultDirector : MonoBehaviour
{
    // リザルトスコアのテキスト
    public Text resultScoreText;
    // ハイスコアのテキスト
    public Text resultHighScoreText;

    // ハイスコア
    private int highScore;

    private void Start()
    {
        // スコアを表示
        resultScoreText.text = $"Score\n{GameDirector.score}m";

        // ハイスコアを取得して表示
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        resultHighScoreText.text = $"High: {highScore}m";
    }

    // リスタートボタンが押された時
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    // タイトルへボタンが押された時
    public void OnToTitleButtonClicked()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
