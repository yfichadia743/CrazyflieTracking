using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

public class client : MonoBehaviour
{
    Socket s;
    public float roll;
    public float pitch;
    public float yaw;
    public float x;
    public float y;
    public float z;
    public Transform block;
    float[] valuesX = new float[5];
    float[] valuesY = new float[5];
    float[] valuesZ = new float[5];
    int k = 0;
    // Start is called before the first frame update
    void Start()
    {
        string host = Dns.GetHostName();
        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        s.Connect(host, 1234);
        Debug.Log("connected");
    }

    // Update is called once per frame
    void Update()
    {
        byte[] buffer = new byte[255];
        byte[] buffer2 = new byte[255];
        int rec = s.Receive(buffer, buffer.Length, 0);
        string rec2 = Encoding.ASCII.GetString(buffer);
        //string rec3 = "{'stateEstimate.roll': -0.4654850363731384, 'stateEstimate.pitch': 1.24271559715271, 'stateEstimate.yaw': -68.51175689697266, 'stateEstimate.x': -0.41279029846191406, 'stateEstimate.y': -0.004219357855618, 'stateEstimate.z': 0.027834372594952583}";
        print(rec2);
        string[] values = rec2.Split(' ');
        float[] values2 = new float[6];
        int j = 0;
        for (int i = 1; i < values.Length; i = i + 2)
        {
            if (i == 11)
            {
                values[i] = values[i].Replace("}", null);
                print(values[i]);
            }
            else
            {
                values[i] = values[i].TrimEnd(',');
            }
            //print(values[i]);
            try
            {
                values2[j] = float.Parse(values[i]);
            } catch
            {

            }
            j++;
        }

        //roll = Math.Round((decimal)values2[0], 2);
        float averageX = 0;
        float averageY = 0;
        float averageZ = 0;
        if (k < 5)
        {
            valuesX[k] = values2[3];
            valuesY[k] = values2[5];
            valuesZ[k] = values2[4];
            k++;
        } else
        {
            
            for (int i = 0; i < 4; i++)
            {
                valuesX[i] = valuesX[i + 1];
                valuesY[i] = valuesY[i + 1];
                valuesZ[i] = valuesZ[i + 1];
                averageX = averageX + valuesX[i + 1];
                averageY = averageY + valuesY[i + 1];
                averageZ = averageZ + valuesZ[i + 1];
            }
            valuesX[4] = values2[3];
            valuesY[4] = values2[5];
            valuesZ[4] = values2[4];
            averageX = (averageX + valuesX[4])/5;
            averageY = (averageY + valuesY[4])/5;
            averageZ = (averageZ + valuesZ[4])/5;
        }

        

        roll = (float) Math.Round(values2[0], 3);
        pitch = (float) Math.Round(values2[1], 3);
        yaw = (float) Math.Round(values2[2], 3);
        x = (float) Math.Round(averageX, 3);
        y = (float) Math.Round(averageY, 3);
        z = -(float) Math.Round(averageZ, 3);
        block.transform.localEulerAngles = new Vector3((roll + 90), pitch, yaw);
        block.transform.localPosition = new Vector3(z, y, x);

        //print(rec2);
    }
}