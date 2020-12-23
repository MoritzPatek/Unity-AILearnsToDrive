using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brain : MonoBehaviour
{
    private sensors _sensors;
    private carMovement _carMovement;

    //those are the values i will use to tell the neural network, if it messed up or if it performed good
    public float distanceWent; //fitness

    private int[] layers;
    private float[][] neurons;
    private float[][] biases;
    private float[][][] weights;
    private int[] activations;


    private void Start()
    {
        _sensors = this.gameObject.GetComponent<sensors>();
        _carMovement = this.gameObject.GetComponent<carMovement>();

        InitWeights();
        InitBiases();
        InitNeurons();
    }

    void InitWeights()
    {
        
    }
    void InitBiases()
    {
        
    }
    void InitNeurons()
    {
        
    }



    private void FixedUpdate()
    {
        //creating a list of all the sensor data we have 
        List<float> originInputs = new List<float>() {_sensors.currentSpeed, _sensors.rotation, _sensors.distanceForward, _sensors.distanceLeft, _sensors.distanceRight, _sensors.distanceFLeft, _sensors.distanceFRight};
        /*string text = null; 
        foreach (var input in inputs)
        {
            text = text + input.ToString() + " ";
        }
        Debug.Log(text);*/
    }

    public void CarCrash()
    {
        
        distanceWent = 0;
    }
    
    
}
