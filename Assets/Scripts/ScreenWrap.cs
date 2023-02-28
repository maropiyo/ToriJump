using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera mainCamera;
    private bool isWrappingX = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Wrap();
    }

    void Wrap()
    {
        Vector3 position = transform.position;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(position);

        if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            position.x = -position.x;
            isWrappingX = true;
        }

        if (viewportPosition.x >= 0 && viewportPosition.x <= 1)
        {
            isWrappingX = false;
        }

        transform.position = position;
    }
}
