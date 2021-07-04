using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    Camera camera;
    public bool isPress;
    public Vector3 hitPoint;
    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
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
