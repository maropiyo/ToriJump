using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // プレイヤーのTransform
    public Vector3 offset; // プレイヤーからの距離（カメラの位置）

    // プレイヤーの最高到達点
    private float playerMaxPoint = 0;

    void LateUpdate()
    {
        // プレイヤーが最高到達点に辿りつかない場合
        if (playerTransform.position.y < playerMaxPoint) return;

        // プレイヤーの最高到達点の更新を行う
        playerMaxPoint = (playerMaxPoint < playerTransform.position.y) ? playerTransform.position.y : playerMaxPoint;

        // プレイヤーのY座標とZ座標を追従する
        Vector3 newPosition = new Vector3(transform.position.x, playerTransform.position.y, offset.z);

        // カメラの位置を更新
        transform.position = newPosition;
    }
}
