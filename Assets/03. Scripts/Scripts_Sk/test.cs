using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;

//using NetMQ.Sockets;
//using AsyncIO;

public class test : MonoBehaviour
{
    bool socketReady = false;
    TcpClient mySocket;
    public NetworkStream theStream;
    StreamWriter theWriter;
    StreamReader theReader;
    public String Host = "127.0.0.1";
    public Int32 Port = 7000;

    // Start is called before the first frame update
    void Start()
    {
        //aaa();
        
    }

    // Update is called once per frame
    void Update()
    {
       // setupSocket();
    }

    public void setupSocket()
    {                            // Socket setup here
        try
        {
            mySocket = new TcpClient(Host, Port);
            print(mySocket);
            theStream = mySocket.GetStream();
            theWriter = new StreamWriter(theStream);
            theReader = new StreamReader(theStream);
            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("Socket error:" + e);                // catch any exceptions
        }
    }

    public void TextMessage(string message)
    {
        if (true)
        {
            theWriter.Write(message);
            theWriter.Flush();
        }
    }

    private void start()
    {
        
        byte[] buffer = new Byte[1024];
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5005);
        Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);

            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                Socket socket = listener.Accept();
                String data = null;

                while (true)
                {
                    int bytesRec = socket.Receive(buffer);
                    data += Encoding.ASCII.GetString(buffer, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }

                Console.WriteLine("Text received : {0}", data);
                byte[] msg = Encoding.ASCII.GetBytes(data);

                socket.Send(msg);
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\nPress ENTER to continue...");
        Console.Read();
    }

    //public void aaa() 
    //{
    //    print("aa");
    //    ForceDotNet.Force();
    //    using (RequestSocket client = new RequestSocket()) 
    //    {
    //        client.Connect("tcp://localhost:5555");
    //    }
    //}
}
