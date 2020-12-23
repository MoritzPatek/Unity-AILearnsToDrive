using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    [SerializeField] private float movingSpeed;
    private GameObject car;
    private Rigidbody rb;

    Vector3 rotationRight = new Vector3(0, 30, 0);
    Vector3 rotationLeft = new Vector3(0, -30, 0);

    Vector3 forward = new Vector3(0, 0, 1);
    
    //this value multiplies with the movespeed
    public float moveInput;

    //when this value is under 0.4 its turning right 
    //when its over 0.6 then its turning left
    //the 0.2 inbetween are there so the ai can drive straight 
    public float rotateInput;
    
    void Start()
    {
        car = this.gameObject;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(forward * (movingSpeed * moveInput * Time.deltaTime));
        
        if (rotateInput < 0.4f) {
            Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationRight);
        }
        if(rotateInput > 0.6f){
            Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationLeft); 
        }
        
    }
}
