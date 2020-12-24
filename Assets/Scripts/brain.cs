using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static System.Math;

public class brain : MonoBehaviour
{
    private sensors _sensors;
    private carMovement _carMovement;

    //those are the values i will use to tell the neural network, if it messed up or if it performed good
    public float distanceWent; //fitness
    private int[] layers = new int[3] {7,5,2}; 

    private float[][][] weights; 
    private float[][] biases;
    private float[][] neurons;
    private float[] activations;

    public int chance;
    public float strenght;
    
    


    private void Start()
    {
        _sensors = this.gameObject.GetComponent<sensors>();
        _carMovement = this.gameObject.GetComponent<carMovement>();
        Debug.Log(layers[0]);
        InitNeurons();
        InitBiases();
        InitWeights();
        
        
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
        List<float[][]> weightsList = new List<float[][]>();
        for (int l = 1; l < layers.Length; l++)
        {
            List<float[]> layerWeightsList = new List<float[]>();
            int neuronsInPreviousLayer = layers[l - 1];            
            for (int j = 0; j < neurons[l].Length; j++)            
            {                 
                float[] neuronWeights = new float[neuronsInPreviousLayer];
                for (int k = 0; k < neuronsInPreviousLayer; k++)  
                {                                      
                    neuronWeights[k] = UnityEngine.Random.Range(-0.5f, 0.5f); 
                }               
                layerWeightsList.Add(neuronWeights);            
            }            
            weightsList.Add(layerWeightsList.ToArray());        
        }        
        weights = weightsList.ToArray();  
        
        Debug.Log("Sup");
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
        float[] originInputs = new [] {_sensors.currentSpeed, _sensors.rotation, _sensors.distanceForward, _sensors.distanceLeft, _sensors.distanceRight, _sensors.distanceFLeft, _sensors.distanceFRight};
        float[] output = feedForward(originInputs);
        
        _carMovement.moveInput = output[0];
        _carMovement.rotateInput = output[1];
        
        
    }

    private float[] feedForward(float[] inputs)
    {
        for (int i = 0; i < inputs.Length; i++)        
        {            
            neurons[0][i] = inputs[i];        
        }        
        for (int i = 1; i < layers.Length; i++)        
        {            
            int layer = i - 1;            
            for (int j = 0; j < neurons[i].Length; j++)            
            {                
                float value = 0f;               
                for (int k = 0; k < neurons[i - 1].Length; k++)  
                {                    
                    value += weights[i - 1][j][k] * neurons[i - 1][k];      
                }                
                neurons[i][j] = sigmoidFunction(value + biases[i][j]);            
            }        
        }        
        return neurons[neurons.Length - 1];
    }

    private float sigmoidFunction(float value)
    {
        decimal x = new decimal(value);
        double k = Math.Exp((double)value);
        
        return (float)(k / (1.0f + k));
    }
    
    public void Mutate(int chance, float val)//used as a simple mutation function for any genetic implementations.
    {
        for (int i = 0; i < biases.Length; i++)
        {
            for (int j = 0; j < biases[i].Length; j++)
            {
                biases[i][j] = (UnityEngine.Random.Range(0f, chance) <= 5) ? biases[i][j] += UnityEngine.Random.Range(-val, val) : biases[i][j];
            }
        }

        for (int i = 0; i < weights.Length; i++)
        {
            for (int j = 0; j < weights[i].Length; j++)
            {
                for (int k = 0; k < weights[i][j].Length; k++)
                {
                    weights[i][j][k] = (UnityEngine.Random.Range(0f, chance) <= 5) ? weights[i][j][k] += UnityEngine.Random.Range(-val, val) : weights[i][j][k];
                }
            }
        }
    } 

    public void CarCrash()
    {
        
        distanceWent = 0;
        Mutate(chance, strenght);
    }
    
    
}
