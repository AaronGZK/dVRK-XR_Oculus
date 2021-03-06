using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
 
public class UDPSend : MonoBehaviour
{
    private static int localPort;
   
    // prefs
    public string IP;  // define in init
    public int port;  // define in init
   
    // "connection" things
    IPEndPoint remoteEndPoint;
    UdpClient client;
   
    // gui
    string strMessage="Hi, wish you all the best.";
   
       
    // call it from shell (as program)
    private static void Main()
    {
        UDPSend sendObj=new UDPSend();
        sendObj.init();
       
        // testing via console
        // sendObj.inputFromConsole();
       
        // as server sending endless
        sendObj.sendEndless(" endless infos \n");
       
    }
    // start from unity3d
    public void Start()
    {
        init();
        
        sendString("Hello. Wish you all the best.");
    }

    void Update()
    {

        sendString("Hello. This is Oculus.");
    }
   
    // OnGUI
    void OnGUI()
    {
        Rect rectObj=new Rect(40,380,200,400);
            GUIStyle style = new GUIStyle();
                style.alignment = TextAnchor.UpperLeft;
        GUI.Box(rectObj,"# UDPSend-Data\n"+IP+" "+port+" #\n"
                    + "shell> nc -lu"+IP+" "+port+" \n"
                ,style);
       
        // ------------------------
        // send it
        // ------------------------
        strMessage=GUI.TextField(new Rect(40,420,140,20),strMessage);
        if (GUI.Button(new Rect(190,420,40,20),"send"))
        {
            sendString(strMessage+"\n");
        }      
    }
   
    // init
    public void init()
    {
        // Endpunkt definieren, von dem die Nachrichten gesendet werden.
        print("UDPSend.init()");
       
        // define
        // IP="172.27.160.1";
        IP="172.31.254.155";
        port=34567;
       
        // ----------------------------
        // Senden
        // ----------------------------
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();
       
        // status
        print("Sending to "+IP+" : "+port);
        print("Testing: nc -lu "+IP+" : "+port);
   
    }
 
    // inputFromConsole
    private void inputFromConsole()
    {
        try
        {
            string text;
            do
            {
                text = Console.ReadLine();
 
                // Den Text zum Remote-Client senden.
                if (text != "")
                {
 
                    // Daten mit der UTF8-Kodierung in das Bin??rformat kodieren.
                    byte[] data = Encoding.UTF8.GetBytes(text);
 
                    // Den Text zum Remote-Client senden.
                    client.Send(data, data.Length, remoteEndPoint);
                }
            } while (text != "");
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
 
    }
 
    // sendData
    private void sendString(string message)
    {
        try
        {
                //if (message != "")
                //{
 
                    // Daten mit der UTF8-Kodierung in das Bin??rformat kodieren.
                    byte[] data = Encoding.UTF8.GetBytes(message);
 
                    // Den message zum Remote-Client senden.
                    client.Send(data, data.Length, remoteEndPoint);
                //}
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }
   
   
    // endless test
    private void sendEndless(string testStr)
    {
        do
        {
            sendString(testStr);
        }
        while(true);
    }
   
}
