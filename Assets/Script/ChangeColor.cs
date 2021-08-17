using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Color color;
    private void Start()
    {
        color = GetComponent<Renderer>().material.color;
    }
    private void OnTriggerEnter(Collider collider)
    {
        collider.transform.GetComponent<Renderer>().material.color = color;
        Destroy(gameObject);
    }
}