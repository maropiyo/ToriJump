using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{
    private void Start()
    {

    }

    // 「はじめる」ボタンが押された時
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    // 「とりをえらぶ」ボタンが押された時
    public void OnSelectBirdButtonClicked()
    {
        SceneManager.LoadScene("CharacterSelectScene");
    }
}
