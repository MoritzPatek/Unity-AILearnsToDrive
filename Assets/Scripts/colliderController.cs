using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderController : MonoBehaviour
{
    private brain _brain;
    private carMovement _carMovement;

    private void Start()
    {
        _brain = gameObject.GetComponent<brain>();
        _carMovement = gameObject.GetComponent<carMovement>();
    }

    private void OnCollisionEnter(Collision other)
    {
        _carMovement.Respawn();
        _brain.CarCrash();
    }
}
