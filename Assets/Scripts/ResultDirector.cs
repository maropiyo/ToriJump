using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultDirector : MonoBehaviour
{
    // リスタートボタンが押された時
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
}
