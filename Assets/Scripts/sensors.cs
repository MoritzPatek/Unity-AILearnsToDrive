using System;
using UnityEngine;


public class sensors : MonoBehaviour
{

    public float distanceForward;
    public float distanceRight;
    public float distanceLeft;
    public float rotation;
    public float distanceFLeft;
    public float distanceFRight;
    public float currentSpeed;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            distanceForward = hit.distance;
        }
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
            distanceRight = hit.distance;
        }
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.yellow);
            distanceLeft = hit.distance;
        }
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left + new Vector3(0,0,1)), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left + new Vector3(0,0,1)) * hit.distance, Color.yellow);
            distanceFLeft = hit.distance;
        }
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right + new Vector3(0,0,1)), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right + new Vector3(0,0,1)) * hit.distance, Color.yellow);
            distanceFRight = hit.distance;
        }

        rotation = transform.localRotation.y;
        currentSpeed = _rb.velocity.magnitude;
    }
}
