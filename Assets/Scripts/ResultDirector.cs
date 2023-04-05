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

        // ハイスコアを更新した時にランキングを表示
        if(highScore == GameDirector.score)
        {
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(GameDirector.score);
        }
    }

    // ランキングボタンが押された時
    public void OnRankingButtonClicked()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(GameDirector.score);
    }

    // リスタートボタンが押された時
    public void OnRestartButtonClicked()
    {
        SoundManager.Instance.DestroyGameObject();
        SceneManager.LoadScene("GameScene");
    }

    // タイトルへボタンが押された時
    public void OnToTitleButtonClicked()
    {
        SoundManager.Instance.DestroyGameObject();
        SceneManager.LoadScene("TitleScene");
    }
}
