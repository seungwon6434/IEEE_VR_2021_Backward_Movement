using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class TCPTestClient : MonoBehaviour
{
	public string temp;
	public bool connect = false;

	private Stopwatch sw_temp;

	#region private members 	
	private TcpClient socketConnection;
	private Thread clientReceiveThread;
	public string Direction;

	#endregion
	// Use this for initialization 	
	void Start()
	{
		print("클라이언트 시작");
		ConnectToTcpServer();

		sw_temp = new Stopwatch();
		sw_temp.Start();
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		
		Stopwatch();

		if (connect) 
		{
			SendMessage();
			connect = false;
		}

	}

	void Stopwatch() 
	{
		if (sw_temp.ElapsedMilliseconds > 1000) 
		{
			sw_temp.Restart();
			connect = true;
		}
	
	}
	/// <summary> 	
	/// Setup socket connection. 	
	/// </summary> 	
	private void ConnectToTcpServer()
	{
		try
		{
			clientReceiveThread = new Thread(new ThreadStart(ListenForData));
			clientReceiveThread.IsBackground = true;
			clientReceiveThread.Start();
			print("성공!");
		}
		catch (Exception e)
		{
			print("실패!");
			Debug.Log("On client connect exception " + e);
		}
	}
	/// <summary> 	
	/// Runs in background clientReceiveThread; Listens for incomming data. 	
	/// </summary>     
	private void ListenForData()
	{
		try
		{
			//socketConnection = new TcpClient("210.107.197.100", 2222);
			socketConnection = new TcpClient("127.0.0.1", 2222);
			Byte[] bytes = new Byte[1024];
			while (true)
			{
				// Get a stream object for reading 				
				using (NetworkStream stream = socketConnection.GetStream())
				{
					int length;
					// Read incomming stream into byte arrary. 					
					while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
					{
						var incommingData = new byte[length];
						Array.Copy(bytes, 0, incommingData, 0, length);
						// Convert byte array to string message. 						
						string serverMessage = Encoding.UTF8.GetString(incommingData);

						temp = serverMessage;
						Debug.Log("server message received as: " + serverMessage);
					}
				}
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("Socket exception: " + socketException);
		}
	}
	/// <summary> 	
	/// Send message to server using socket connection. 	
	/// </summary> 	
	private void SendMessage()
	{
		if (socketConnection == null)
		{
			return;
		}
		try
		{
			// Get a stream object for writing. 			
			NetworkStream stream = socketConnection.GetStream();
			if (stream.CanWrite)
			{
				string clientMessage1 = GameObject.Find("MoveDetect").GetComponent<Find_Index>().sensors;

				//string clientMessage1 = "20200515, 19:14:38, 0.06, 26.73714, 1.442945, 11.02973, 0.898469, 0.1125997, 0.4189014, 26.80681, 1.437814, 11.26383, 0.6713184, -0.03039808, 0.7388303, 26.87277, 3.213294, 11.11868, -0.04088308, 0.7835543, 0.07496116, Backward";
				// Convert string message to byte array.         
				//print(clientMessage1);
				byte[] clientMessageAsByteArray = Encoding.UTF8.GetBytes(clientMessage1);
				//print(clientMessageAsByteArray);
				// Write byte array to socketConnection stream.                 
				stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
				stream.Flush();
				Debug.Log("Client sent his message - should be received by server");
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("Socket exception: " + socketException);
		}
	}
}