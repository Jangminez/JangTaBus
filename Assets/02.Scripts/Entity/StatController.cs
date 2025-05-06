using System;
using UnityEngine;

public class StatController : MonoBehaviour
{
    private float hp = 10f;
    public float HP
    {   
        get => hp;
        set => hp = Math.Max(0, value);
    }
    
    private float speed = 3f;
    public float Speed
    {
        get => speed;   
        set => speed = Math.Max(0, value);
    }
}
