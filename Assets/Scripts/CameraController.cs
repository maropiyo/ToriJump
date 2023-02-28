using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;  // 追従する対象のTransform
    public float smoothing = 5f;  // 追従のスムージング係数
    public float yOffset = 10f;  // カメラの高さオフセット

    private Rigidbody2D rb;
    private Vector3 offset;  // カメラと対象の距離オフセット

    void Start()
    {
        // カメラと対象の距離オフセットを計算
        offset = transform.position - target.transform.position;
        // カメラのX軸とZ軸を固定
        offset.x = 0f;
        offset.z = -10f;

        rb  = target.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // プレイヤーが-Y方向に移動している場合、カメラの座標を更新する。
        if (rb.velocity.y > 0)
        {
            // 追従する対象のY軸に追従する位置を計算
            Vector3 targetCamPos = new Vector3(offset.x, target.transform.position.y + yOffset, offset.z);

            // カメラの位置をスムージングして更新
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}
