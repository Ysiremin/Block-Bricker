using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private RayCaster rayCaster;

    private Vector3 direction;
    private Vector3 movementDirection;
    private Color color;
    private bool isColorSame = false;
    private float speed = 0;

    public LineRenderer line;

    public bool IsColorSame { get => isColorSame; }

    public void Start()
    {
        rayCaster.OnMauseButtonUp += OnMauseButtonUp;
    }
    private void Update()
    {
        color = GetComponent<Renderer>().material.color;

        if (rayCaster.IsPress && speed == 0)
        {
            direction = (rayCaster.HitPoint - transform.position).normalized;
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, rayCaster.HitPoint);
        }
        transform.position += movementDirection * speed * Time.deltaTime;
    }

    private void OnMauseButtonUp()
    {
        if (speed == 0)
        {
            movementDirection = direction;
            speed = 25;
            line.enabled = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Renderer>().material.color == color)
        {
            isColorSame = true;
        }
        else
        {
            isColorSame = false;
        }

        if (collision.transform.TryGetComponent(out Glue glue))
        {
            speed = 0;
        }
        else
        {
            movementDirection = Vector3.Reflect(movementDirection, collision.GetContact(0).normal);
            //Debug.Log(collision.transform.name);
        }
    }
}