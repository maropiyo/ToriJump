using UnityEngine;
using System.Collections.Generic;

public class FloorGenerator : MonoBehaviour
{
    public GameObject[] objects; //　生成する床のプレファブ配列
    public float floorGap = 3.0f; // 床のY軸方向の間隔
    public float minX = 0.0f; // 床の最小X座標
    public float maxX = 5.0f; // 床の最大X座標
    public int floorNum = 10; // 最初に生成する床の数
    public float startFloorY = 0.0f; // 最初に生成する床の位置のY座標

    private float playerHeight; // プレイヤーの高さ
    private float lastFloorY; // 最後に生成した床のY座標
    private List<GameObject> floors = new List<GameObject>(); // 生成した床のリスト

    private void Start()
    {
        lastFloorY = startFloorY;
        for (int i = 0; i < floorNum; i++)
        {
            GenerateNextFloor();
        }
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHeight = player.transform.position.y;
        if (floors.Count < floorNum)
        {
            GenerateNextFloor();
        }
        RemoveFloor();
    }

    // 次の床を生成する
    private void GenerateNextFloor()
    {
        float randomX = Random.Range(minX, maxX);
        int randomIndex = Random.Range(0, objects.Length);
        GameObject selectedFloor = objects[randomIndex];
        GameObject newFloor = Instantiate(selectedFloor, new Vector3(randomX, lastFloorY + floorGap, 0), Quaternion.identity);
        floors.Add(newFloor);
        lastFloorY = newFloor.transform.position.y;
    }

    // 床を削除する
    private void RemoveFloor()
    {
        for (int i = 0; i < floors.Count; i++)
        {
            if (floors[i].transform.position.y < playerHeight - 10.0f)
            {
                Destroy(floors[i]);
                floors.RemoveAt(i);
                i--;
            }
        }
    }
}

