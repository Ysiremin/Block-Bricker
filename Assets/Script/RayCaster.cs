using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RayCaster : MonoBehaviour
{
    public UnityAction OnMauseButtonUp;
    private bool isPress;
    private Vector3 hitPoint;

    public bool IsPress { get => isPress; }
    public Vector3 HitPoint { get => hitPoint; }

    private void Update()
    {
        if (isPress && Input.GetMouseButtonUp(0))
        {
            OnMauseButtonUp.Invoke();
        }

        if (Input.GetMouseButton(0))
        {
            isPress = true;
            RayFromCamera();
        }
        else
        {
            isPress = false;
        }
    }

    private void RayFromCamera()
    {
        Camera camera = Camera.main;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            hitPoint = hit.point;
            hitPoint.z = 0;
        }
    }
}
