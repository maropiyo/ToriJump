using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    public float speed = 2f; // 移動速度
    public float leftLimit = 0f; // 左端の座標
    public float rightLimit = 5f; // 右端の座標

    private bool moveRight = true;

    void Update()
    {
        if (transform.position.x > rightLimit)
        {
            moveRight = false;
        }
        else if (transform.position.x < leftLimit)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
