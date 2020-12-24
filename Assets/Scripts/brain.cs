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

    private int[] layers = new int[] {7,5,2}; 

    private float[][][] weights; 
    private float[][] biases;
    private float[][] neurons;
    private float[] activations; 
    
    


    private void Start()
    {
        _sensors = this.gameObject.GetComponent<sensors>();
        _carMovement = this.gameObject.GetComponent<carMovement>();
        InitNeurons();
        InitWeights();
        InitBiases();
        
    }

    void InitNeurons()
    {
        List<float[]> neuronsList = new List<float[]>();
        for (int i = 0; i < layers.Length; i++)
        {
            neuronsList.Add(new float[layers[i]]);
        }
        neurons = neuronsList.ToArray();
    }
    
    void InitWeights()
    {
        
    }
    void InitBiases()
    {
        List<float[]> biasList = new List<float[]>();

        for (int i = 0; i < layers.Length; i++)
        {
            float[] bias = new float[layers[i]];
            for (int x = 0; x < bias.Length; x++)
            {
                bias[x] = UnityEngine.Random.Range(-0.5f, 0.5f);
            }
            biasList.Add(bias);
        }
        biases = biasList.ToArray();
    }
    



    private void FixedUpdate()
    {
        //creating a list of all the sensor data we have 
        List<float> originInputs = new List<float>() {_sensors.currentSpeed, _sensors.rotation, _sensors.distanceForward, _sensors.distanceLeft, _sensors.distanceRight, _sensors.distanceFLeft, _sensors.distanceFRight};
        List<float> output = feedForward(originInputs);
        _carMovement.moveInput = output[0];
        _carMovement.rotateInput = output[1];
    }

    private List<float> feedForward(List<float> inputs)
    {
        List<float> outputs = new List<float>() {1,1};
        return outputs;
    }

    private float sigmoidFunction(float value)
    {
        float k = Mathf.Exp(value);
        return k / (1.0f + k);
    }

    public void CarCrash()
    {
        
        distanceWent = 0;
    }
    
    
}
