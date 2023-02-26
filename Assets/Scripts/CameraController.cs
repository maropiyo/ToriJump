using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 追従するオブジェクト
    public Transform target;
    // 追従速度
    public float smoothSpeed = 0.125f;
    // 追従位置のオフセット
    public Vector3 offset; 

    private void FixedUpdate()
    {
        // 追従位置を設定
        Vector3 desiredPosition = target.position + offset; 
        // 追従位置に徐々に移動
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // カメラが下方向に移動しないよう制限
        smoothedPosition.y = Mathf.Max(smoothedPosition.y, transform.position.y);
        // カメラを設定した追従位置に移動
        transform.position = smoothedPosition; 
    }
}
