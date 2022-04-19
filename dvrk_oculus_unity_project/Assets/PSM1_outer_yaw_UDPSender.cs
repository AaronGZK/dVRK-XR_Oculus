using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class PSM1_outer_yaw_UDPSender : MonoBehaviour
{
    private static int localPort;
   
    // prefs
    public string IP;  // define in init
    public int port;  // define in init
   
    // "connection" things
    IPEndPoint remoteEndPoint;
    UdpClient client;

    // Start is called before the first frame update
    void Start()
    {
        IP="100.64.187.186";
        port=34567;
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();
    }

    // Update is called once per frame
    void Update()
    {
        float val = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).eulerAngles.y;
        if (val > 180f) val = val - 360f;
        string s = "OVRInput.Controller.LTouch  eulerAngles.y  :  "+val.ToString();
        sendString(s);
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
}
