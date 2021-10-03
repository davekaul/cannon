using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float PositionMagnitude;
    public float RotationMagnitude;
    public float FireMagnitude;

    public Transform CannonBarrel;

    public GameObject Cannonball;

    private void Update()
    {
        UpdateMovement();
        UpdateCannonBarrelMovement();
        UpdateCannonball();
    }

    private void UpdateMovement()
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

    private void UpdateCannonBarrelMovement()
    {
        Vector3 eularAngles = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            eularAngles += Vector3.left * RotationMagnitude * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))    
        {
            eularAngles -= Vector3.left * RotationMagnitude * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            eularAngles += Vector3.forward * RotationMagnitude * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            eularAngles -= Vector3.forward * RotationMagnitude * Time.deltaTime;
        }

        if (eularAngles.magnitude > 0f)
        {            
            var qTarget = Quaternion.Euler(eularAngles);
            CannonBarrel.rotation *= qTarget;          
        }
    }

    private void UpdateCannonball()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var cannonBall = Instantiate(Cannonball, CannonBarrel.position, CannonBarrel.rotation);
            var rigidbody = cannonBall.GetComponent<Rigidbody>();
            rigidbody.AddForce(-CannonBarrel.up * FireMagnitude);
        }
    }

}
