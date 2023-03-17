using UnityEngine;

public class TimeOfDay : MonoBehaviour
{
    public Gradient skyColors;
    public float dayDuration = 120f; // 1日の長さ（秒）
    private float timeOfDay = 0f; // 現在の時間

    private Camera mainCamera;
    private float currentDuration;

    void Start()
    {
        mainCamera = Camera.main;
        currentDuration = dayDuration;
    }

    void Update()
    {
        timeOfDay += Time.deltaTime / currentDuration;
        if (timeOfDay >= 1f)
        {
            timeOfDay -= 1f;
        }
        mainCamera.backgroundColor = skyColors.Evaluate(timeOfDay);
    }
}
