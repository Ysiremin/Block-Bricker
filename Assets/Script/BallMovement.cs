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
        if (rayCaster.isPress)
        {
            direction = (rayCaster.hitPoint - transform.position).normalized;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, rayCaster.hitPoint);
        }
        transform.position += movementDirection * speed * Time.deltaTime;

    }
    private void OnMauseButtonUp()
    {
        movementDirection = direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        movementDirection = Vector3.Reflect(movementDirection, collision.GetContact(0).normal);
        Debug.Log(collision.transform.name);
    }
}
