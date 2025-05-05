using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float highPosY = 2f;
    [SerializeField] float lowPosY = -2f;

    [SerializeField] float holeSizeMin = 3f;
    [SerializeField] float holeSizeMax = 5f;

    [SerializeField] Transform topObj;
    [SerializeField] Transform bottomObj;

    [SerializeField] float widthPadding = 10f;

    // 장애물 랜덤 배치
    public Vector3 SetRandomPosition(Vector3 lastPosition)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObj.localPosition = new Vector3(0, halfHoleSize);
        bottomObj.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 randomPosition = lastPosition + new Vector3(widthPadding, 0);
        randomPosition.y = Random.Range(lowPosY, highPosY);

        transform.localPosition = randomPosition;

        return randomPosition;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            {
                if(!collision.GetComponent<ShipController>().isDead)
                {

                }
            }
    }
}
