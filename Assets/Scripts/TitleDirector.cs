using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{
    // メインカメラ
    public Camera mainCamera;
    // プレイヤーのTransform
    public Transform player;

    private void Start()
    {
        // フレームレートを60に設定
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        CheckPlayerPosition();
    }

    // 「はじめる」ボタンが押された時
    public void OnStartButtonClicked()
    {
        SoundManager.Instance.DestroyGameObject();
        SceneManager.LoadScene("GameScene");
    }

    // 「とりをえらぶ」ボタンが押された時
    public void OnSelectBirdButtonClicked()
    {
        SceneManager.LoadScene("CharacterSelectScene");
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
    }
}
