using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropsGenerator : MonoBehaviour
{
    [SerializeField] int gerateCount = 20;
    [SerializeField] float interval = 1;
    Queue<Crop> cropsPool = new Queue<Crop>();
    [SerializeField] Crop cropPrefab;
    public bool isGameOver = false;

    public void Init()
    {
        for (int i = 0; i < 20; i++)
        {
            Crop crop = Instantiate(cropPrefab);
            crop.cropsGenerator = this;
            crop.gameObject.SetActive(false);
            cropsPool.Enqueue(crop);
        }

        StartCoroutine(GenerateCrop());
    }

    // crop 큐에서 꺼내서 사용 
    public void GetCrop()
    {
        if (cropsPool.Count > 0)
        {
            Crop crop = cropsPool.Dequeue();
            crop.gameObject.SetActive(true);
        }
        // 부족하면 새로 생성
        else
        {
            Crop newCrop = Instantiate(cropPrefab, transform);
            newCrop.cropsGenerator = this;
        }
    }

    // 사용된 crop 다시 큐로 반환
    public void ReturnCrop(Crop crop)
    {
        crop.gameObject.SetActive(false);
        cropsPool.Enqueue(crop);
    }

    // 일정한 주기로 농작물 생성
    IEnumerator GenerateCrop()
    {
        while (!isGameOver)
        {
            GetCrop();

            yield return new WaitForSeconds(interval);
        }
    }
}
