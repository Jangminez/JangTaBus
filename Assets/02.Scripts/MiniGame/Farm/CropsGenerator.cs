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

    public void GetCrop()
    {
        if (cropsPool.Count > 0)
        {
            Crop crop = cropsPool.Dequeue();
            crop.gameObject.SetActive(true);
        }
        else
        {
            Crop newCrop = Instantiate(cropPrefab, transform);
            newCrop.cropsGenerator = this;
        }
    }

    public void ReturnCrop(Crop crop)
    {
        crop.gameObject.SetActive(false);
        cropsPool.Enqueue(crop);
    }

    IEnumerator GenerateCrop()
    {
        while (!isGameOver)
        {
            GetCrop();

            yield return new WaitForSeconds(interval);
        }
    }
}
