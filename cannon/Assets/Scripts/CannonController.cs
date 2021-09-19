using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float PositionMagnitude;

    private void Update()
    {
        Vector3 _targetPosition = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _targetPosition += transform.forward * PositionMagnitude * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            _targetPosition -= transform.forward * PositionMagnitude * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            _targetPosition -= transform.right * PositionMagnitude * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            _targetPosition += transform.right * PositionMagnitude * Time.deltaTime;
        }

        if (_targetPosition.magnitude > 0f)
        {
            transform.Translate(_targetPosition);
        }
    }
}
