using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float PositionMagnitude;

    private void Update()
    {
        Vector3 _targetPosition = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _targetPosition += transform.forward * PositionMagnitude * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _targetPosition -= transform.forward * PositionMagnitude * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _targetPosition -= transform.right * PositionMagnitude * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _targetPosition += transform.right * PositionMagnitude * Time.deltaTime;
        }

        if (_targetPosition.magnitude > 0f)
        {
            transform.Translate(_targetPosition);
        }
    }
}
