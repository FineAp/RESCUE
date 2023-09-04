using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Drone : MonoBehaviour
{
    //드론이 가운데로 이동
    public float speed = 3f;
    private Vector2 targetPos;
    
    void Start()
    {
        targetPos = new Vector2(950, transform.position.y);
       
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);

        if(transform.position.Equals(targetPos))
        {
            speed = 0;
        }

    }
}
