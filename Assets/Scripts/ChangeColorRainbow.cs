using UnityEngine;
using UnityEngine.UI;

public class ChangeColorRainbow : MonoBehaviour
{
    public SpriteRenderer sprite;

    private float hue;

    void Update()
    {
        hue += Time.deltaTime / 2f;
        if (hue > 1.0f)
        {
            hue -= 1.0f;
        }

        sprite.color = Color.HSVToRGB(hue, 1.0f, 1.0f);
    }
}
