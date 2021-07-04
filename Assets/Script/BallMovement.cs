using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector3 direction;
    public RayCaster rayCaster;

    void Update()
    {
        if (rayCaster.isPress)
        {
            direction = (rayCaster.hitPoint - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
     
    }
}
