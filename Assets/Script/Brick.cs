using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private BallMovement ballMovement;

    private void OnCollisionEnter()
    {
        if (ballMovement.IsColorSame)
        {
            Destroy(gameObject);
        }
    }
}
