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

    // 오브젝트가 활성화 되면 농작물 랜덤 설정
    void OnEnable()
    {
        int num = Random.Range(0, 4);
        SetRandomCrop(num);
    }
    
    /// <summary>
    /// 랜덤한 농작물 설정
    /// </summary>
    /// <param name="num"></param>
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
        // 바구니와 충돌하면 점수 변화
        if (collision.gameObject.CompareTag("Basket"))
        {
            if(num == 3)
                SoundManager.PlaySFX(bombClip);
            else
                SoundManager.PlaySFX(cropClip);

            GameManager.Instance.AddScoreMiniGame(score);
            cropsGenerator.ReturnCrop(this);
        }

        // 바닥과 충돌하면 비활성화
        else if (collision.gameObject.CompareTag("Ground"))
        {
            cropsGenerator.ReturnCrop(this);
        }
    }
}
