using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public CropsGenerator cropsGenerator;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] cropSprites;
    [SerializeField] AudioClip cropClip;
    [SerializeField] AudioClip bombClip;
    int[] scores = { 5, 10, 20, -100 };
    int score;
    int num;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        int num = Random.Range(0, 4);
        SetRandomCrop(num);
    }

    public void SetRandomCrop(int num)
    {
        this.num = num;

        float x = Random.Range(-7.5f, 7.5f);
        float y = Random.Range(5f, 4f);

        transform.position = new Vector3(x, y, 0);

        score = scores[num];
        spriteRenderer.sprite = cropSprites[num];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Basket"))
        {
            if(num == 3)
                SoundManager.PlaySFX(bombClip);
            else
                SoundManager.PlaySFX(cropClip);

            GameManager.Instance.AddScoreMiniGame(score);
            cropsGenerator.ReturnCrop(this);
        }

        else if (collision.gameObject.CompareTag("Ground"))
        {
            cropsGenerator.ReturnCrop(this);
        }
    }
}
