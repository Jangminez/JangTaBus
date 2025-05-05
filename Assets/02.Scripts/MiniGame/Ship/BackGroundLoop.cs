using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    [SerializeField] Transform[] backgrounds;
    [SerializeField] Obstacle[] obstacles;
    [SerializeField] float scrollSpeed = 3f;
    [SerializeField] float backgroundWidth = 22f;
    [SerializeField] int rightIdx_Bg; // 오른쪽 끝
    [SerializeField] int leftIdx_Bg = 0;
    [SerializeField] int rightIdx_Ob; // 오른쪽 끝
    [SerializeField] int leftIdx_Ob = 0;
    private float camWidth;
    public bool isGameOver = false;

    void Start()
    {
        rightIdx_Bg = backgrounds.Length - 1;
        rightIdx_Ob = obstacles.Length - 1;

        camWidth = Camera.main.orthographicSize;

        Vector3 lastObstacle = Vector3.zero;
        
        foreach (var ob in obstacles)
        {
            lastObstacle = ob.SetRandomPosition(lastObstacle);
        }
    }

    void Update()
    {
        if(isGameOver) return;
        
        foreach (Transform bg in backgrounds)
        {
            bg.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }

        foreach (Obstacle ob in obstacles)
        {
            ob.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }

        ScrollBackGround();
        ScrollObstacles();
    }

    void ScrollBackGround()
    {
        if (backgrounds[leftIdx_Bg].position.x < -backgroundWidth)
        {
            Vector3 frontPos = backgrounds[rightIdx_Bg].localPosition;
            backgrounds[leftIdx_Bg].localPosition = frontPos + Vector3.right * backgroundWidth;

            int pre_rightIndex = rightIdx_Bg;
            rightIdx_Bg = leftIdx_Bg;
            leftIdx_Bg = pre_rightIndex - 1 == -1 ? backgrounds.Length - 1 : pre_rightIndex - 1;
        }
    }

    void ScrollObstacles()
    {
        if (obstacles[leftIdx_Ob].transform.position.x < -camWidth)
        {
            Vector3 frontPos = obstacles[rightIdx_Ob].transform.localPosition;
            obstacles[leftIdx_Ob].SetRandomPosition(frontPos);

            int pre_rightIndex = rightIdx_Ob;
            rightIdx_Ob = leftIdx_Ob;
            leftIdx_Ob = pre_rightIndex - 1 == -1 ? obstacles.Length - 1 : pre_rightIndex - 1;
        }
    }
}
