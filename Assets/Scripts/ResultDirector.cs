using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultDirector : MonoBehaviour
{
    // リザルトスコアのテキスト
    public TextMeshProUGUI resultScoreText;

    private void Start()
    {
        resultScoreText.text = $"Score\n{GameDirector.score}";
    }

    // リスタートボタンが押された時
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
}
