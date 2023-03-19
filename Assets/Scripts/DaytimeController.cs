using UnityEngine;

/// <summary>
/// プレイ時間の経過に応じて、ゲーム画面の背景色を変更するコントローラークラス。
/// </summary>
public class DaytimeController : MonoBehaviour
{
    // 空の色
    [SerializeField] private Gradient skyColors;
    // 1日の長さ（秒）
    public float dayDuration = 120f;
    // 現在の時間
    private float timeOfDay = 0f;
    // メインカメラ
    private Camera mainCamera;

    void Start()
    {
        // メインカメラを取得する。
        mainCamera = Camera.main;
    }

    void Update()
    {
        UpdateTimeOfDay();

        // 背景色を現在の時間に合わせて変更する。
        mainCamera.backgroundColor = skyColors.Evaluate(timeOfDay);
    }

    // 現在の時間を更新する。
    private void UpdateTimeOfDay()
    {
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay >= 1f)
        {
            timeOfDay = 0f;
        }
    }
}
