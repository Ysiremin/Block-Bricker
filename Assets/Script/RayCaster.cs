using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RayCaster : MonoBehaviour
{
    Camera camera;
    public bool isPress;
    public Vector3 hitPoint;
    public UnityAction OnMauseButtonUp;
    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if (isPress)
        {
            if (Input.GetMouseButtonUp(0))
            {
                OnMauseButtonUp.Invoke();
            }
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
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            hitPoint = hit.point;
            hitPoint.z = 0;
        }
    }
}
