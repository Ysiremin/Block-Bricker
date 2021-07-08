using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 10;
    private Vector3 direction;
    private Vector3 movementDirection;
    public RayCaster rayCaster;
    public LineRenderer line;

    public void Start()
    {
        rayCaster.OnMauseButtonUp += OnMauseButtonUp;
    }
    void Update()
    {
        if (rayCaster.isPress && speed == 0)
        {
            direction = (rayCaster.hitPoint - transform.position).normalized;
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, rayCaster.hitPoint);
        }
        transform.position += movementDirection * speed * Time.deltaTime;

    }

    private void OnMauseButtonUp()
    {
        if (speed == 0)
        {
            movementDirection = direction;
            speed = 10;
            line.enabled = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        movementDirection = Vector3.Reflect(movementDirection, collision.GetContact(0).normal);
        Debug.Log(collision.transform.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        speed = 0;
    }
}
