using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{
    private void Start()
    {

    }

    // スタートボタンが押された時
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
}
