using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float camSpeed = 3f;
    private float camWidth;
    private float camHeight;
    [SerializeField] private Vector3 offset;

    [SerializeField] private Vector2 center;
    [SerializeField] private Vector2 mapSize;

    void Start()
    {
        offset = new Vector3(0f, 0f, -10f);
        target = FindObjectOfType<PlayerController>().GetComponent<Transform>();

        // 카메라의 높이, 너비 구하기
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Screen.width / Screen.height;
    }


    void Update()
    {
        if (target == null) return;

        LimitCameraFollow();
    }

    // 제한된 카메라 추적
    void LimitCameraFollow()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, camSpeed * Time.deltaTime) + offset;

        float limitX = mapSize.x - camWidth;
        float clampX = Mathf.Clamp(transform.position.x, -limitX + center.x, limitX + center.x);

        float limitY = mapSize.y - camHeight;
        float clampY = Mathf.Clamp(transform.position.y, -limitY + center.y, limitY + center.y);

        transform.position = new Vector3(clampX, clampY) + offset;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }
}
