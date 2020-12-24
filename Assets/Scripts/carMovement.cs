using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    GameObject _car;
    Rigidbody _rb;
    brain _brain;

    public Transform startPoint;

    Vector3 _rotationRight = new Vector3(0, 30, 0);
    Vector3 _rotationLeft = new Vector3(0, -30, 0);

    Vector3 _forward = new Vector3(0, 0, 1);
    
    //this value multiplies with the movespeed
    public float moveInput;

    //when this value is under 0.4 its turning right 
    //when its over 0.6 then its turning left
    //the 0.2 inbetween are there so the ai can drive straight 
    public float rotateInput;
    
    void Start()
    {
        _car = this.gameObject;
        _rb = this.gameObject.GetComponent<Rigidbody>();
        _brain = this.gameObject.GetComponent<brain>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(_forward * (_movingSpeed * moveInput * Time.deltaTime));
        
        if (rotateInput < 0.4f) {
            Quaternion deltaRotationRight = Quaternion.Euler(_rotationRight * Time.deltaTime);
            _rb.MoveRotation(_rb.rotation * deltaRotationRight);
        }
        if(rotateInput > 0.6f){
            Quaternion deltaRotationLeft = Quaternion.Euler(_rotationLeft * Time.deltaTime);
            _rb.MoveRotation(_rb.rotation * deltaRotationLeft); 
        }
        
    }

    public void Respawn()
    {
        gameObject.transform.position = startPoint.position;
        gameObject.transform.localRotation = startPoint.localRotation;
    }

  
}
