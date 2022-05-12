using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

public class test2 : MonoBehaviour
{
    private Socket m_Socket;

    public string iPAdress = "127.0.0.1";
    public const int kPort = 5555;

    private int SenddataLength;                     // Send Data Length. (byte)
    private int ReceivedataLength;                     // Receive Data Length. (byte)

    private byte[] Sendbyte;                        // Data encoding to send. ( to Change bytes)
    private byte[] Receivebyte = new byte[2000];    // Receive data by this array to save.
    private string ReceiveString;                     // Receive bytes to Change string.

    void Awake()
    {
        print("sd");
        //=======================================================
        // Socket create.
        m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        m_Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 10000);
        m_Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 10000);

        //=======================================================
        // Socket connect.
        try
        {
            IPAddress ipAddr = System.Net.IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new System.Net.IPEndPoint(ipAddr, kPort);
            m_Socket.Connect(ipEndPoint);
        }
        catch (SocketException SCE)
        {
            Debug.Log("Socket connect error! : " + SCE.ToString());
            return;
        }

        //=======================================================
        
    }

    void Update() 
    {
        StringBuilder sb = new StringBuilder(); // String Builder Create
        sb.Append("Test 1 - By Mac!!");
        sb.Append("Test 2 - By Mac!!");

        try
        {
            //=======================================================
            // Send.
            SenddataLength = Encoding.Default.GetByteCount(sb.ToString());
            Sendbyte = Encoding.Default.GetBytes(sb.ToString());
            m_Socket.Send(Sendbyte, Sendbyte.Length, 0);

            //=======================================================      
            // Receive.
            m_Socket.Receive(Receivebyte);
            ReceiveString = Encoding.Default.GetString(Receivebyte);
            ReceivedataLength = Encoding.Default.GetByteCount(ReceiveString.ToString());
            Debug.Log("Receive Data : " + ReceiveString + "(" + ReceivedataLength + ")");
        }
        catch (SocketException err)
        {
            Debug.Log("Socket send or receive error! : " + err.ToString());
        }
    }

    void OnApplicationQuit()
    {
        m_Socket.Close();
        m_Socket = null;
    }
}
