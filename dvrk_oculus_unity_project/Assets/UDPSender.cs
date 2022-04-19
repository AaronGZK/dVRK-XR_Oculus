using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
 
public class UDPSender : MonoBehaviour
{
    // prefs
    public string IP;  // define in init
    public int port;  // define in init

    public static float outer_yaw_joint_angle;
    public static float outer_pitch_joint_angle;
    public static float outer_insertion_joint_angle;
    public static float outer_roll_joint_angle;
    public static float outer_wrist_yaw_joint_angle;
    public static float outer_wrist_pitch_joint_angle;
   
    // "connection" things
    IPEndPoint remoteEndPoint;
    UdpClient client;

    // Start is called before the first frame update
    void Start()
    {
        // IP="172.31.254.155";
        IP="10.42.0.1";
        port=34567;
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();
        Debug.Log("PSM 1 : " + ": UDP Sender started." + IP);
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log("PSM 1 : " + ": UDP Sender started." + IP);

        float val;
        string s = "";
        val = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch).z;
        s = s + " " + val.ToString();
        val = -OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch).x;
        s = s + " " + val.ToString();
        val = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch).y;
        s = s + " " + val.ToString();
        val = -OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).z;
        s = s + " " + val.ToString();
        val = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).x;
        s = s + " " + val.ToString();
        val = -OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).y;
        s = s + " " + val.ToString();
        val = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).w;
        s = s + " " + val.ToString();
        sendString(s);

        receiveMessage();
    }

    // sendData
    private void sendString(string message)
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, remoteEndPoint);
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    private void receiveMessage()
    {
        byte[] data = client.Receive(ref remoteEndPoint);
        string str = Encoding.Default.GetString(data);
        // print(str);
        // Console.WriteLine("The String is: " + str);

        string[] numbers = str.Split(' ');

        outer_yaw_joint_angle = - float.Parse(numbers[0]) * 180f / 3.14159f;
        outer_pitch_joint_angle = float.Parse(numbers[1]) * 180f / 3.14159f;
        outer_insertion_joint_angle = float.Parse(numbers[2]);
        outer_roll_joint_angle = float.Parse(numbers[3]) * 180f / 3.14159f;
        outer_wrist_yaw_joint_angle = float.Parse(numbers[4]) * 180f / 3.14159f;
        outer_wrist_pitch_joint_angle = float.Parse(numbers[5]) * 180f / 3.14159f;
        
    }
}
