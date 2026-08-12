using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 12f, -10f);


    void Start()
    {
        Vector3 offset = new Vector3(0f, 12f, -10f);
        Quaternion rotation = Quaternion.Euler(50f, 0f, 0f);
    }

    private void LateUpdate()
    {
        transform.position = _target.position + _offset;
        transform.rotation = Quaternion.Euler(50f, 0f, 0f);
    }
}
