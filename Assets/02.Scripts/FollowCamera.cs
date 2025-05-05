using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float camSpeed = 5f;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0f, 0f, -10f);
        target = FindObjectOfType<PlayerController>().GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        if (target == null) return;

        this.transform.position = Vector3.Lerp(this.transform.position, target.position, camSpeed * Time.fixedDeltaTime) + offset;
    }
}
