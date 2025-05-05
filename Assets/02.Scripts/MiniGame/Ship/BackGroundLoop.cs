using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    [SerializeField] Transform[] backgrounds;
    [SerializeField] Obstacle[] obstacles;
    [SerializeField] float scrollSpeed = 3f;
    [SerializeField] float backgroundWidth = 22f;
    [SerializeField] int startIdx_Bg;
    [SerializeField] int endIdx_Bg = 0;
    [SerializeField] int startIdx_Ob;
    [SerializeField] int endIdx_Ob = 0;
    private float camWidth;
    void Start()
    {
        startIdx_Bg = backgrounds.Length - 1;
        startIdx_Ob = obstacles.Length - 1;
        camWidth = Camera.main.orthographicSize;

        Vector3 lastObstacle = Vector3.zero;
        
        foreach (var ob in obstacles)
        {
            lastObstacle = ob.SetRandomPosition(lastObstacle);
        }
    }

    void Update()
    {
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
        if (backgrounds[endIdx_Bg].position.x < -backgroundWidth)
        {
            Vector3 frontPos = backgrounds[startIdx_Bg].localPosition;
            backgrounds[endIdx_Bg].localPosition = frontPos + Vector3.right * backgroundWidth;

            int pre_startIndex = startIdx_Bg;
            startIdx_Bg = endIdx_Bg;
            endIdx_Bg = pre_startIndex - 1 == -1 ? backgrounds.Length - 1 : pre_startIndex - 1;
        }
    }

    void ScrollObstacles()
    {
        if (obstacles[endIdx_Ob].transform.position.x < -camWidth)
        {
            Vector3 frontPos = obstacles[startIdx_Ob].transform.localPosition;
            obstacles[endIdx_Ob].SetRandomPosition(frontPos);

            int pre_startIndex = startIdx_Ob;
            startIdx_Ob = endIdx_Ob;
            endIdx_Ob = pre_startIndex - 1 == -1 ? obstacles.Length - 1 : pre_startIndex - 1;
        }
    }
}
