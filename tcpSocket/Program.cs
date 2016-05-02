using System;
using System.Text;
using System.Net.Sockets;


namespace tcpSocket
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            ChatSender myChat = new ChatSender();
            /*
            string serverHost = "192.168.20.145";
            string defaultHostIP = "";
            Console.WriteLine("Please enter default listen port!");
			Int32 port = Int32.Parse (Console.ReadLine ());
            TcpClient client;
            if(serverHost == "")
            {
                Console.WriteLine("DEBUG: No default host IP has been added in code. Add host IP:");
                serverHost = Console.ReadLine();
            } else
            {
                Console.WriteLine("Connecting to host: {0}", serverHost);
            }
			ChatReader myClass = new ChatReader(port);
			Console.WriteLine("My local IP Address is: " + myClass.GetIPAddress());
			bool isConnected = false;
			while(true){
				string myMessage;
				if (isConnected) {
					myMessage = Console.ReadLine ();
				} else {
					myMessage = "CONNECTINGPORT:" + port;
					isConnected = true;
				}
				try 
				{
					if(myMessage != ""){
                    myClass.sentString = myMessage;
				    // Create a TcpClient.
				    // Note, for this client to work you need to have a TcpServer 
				    // connected to the same address as specified by the server, port
				    // combination.

                    if(defaultHostIP == "")
                        {
                            client = new TcpClient(serverHost, 80);
                        } else
                        {
                            client = new TcpClient(defaultHostIP, 80);
                        }

				    // Translate the passed message into ASCII and store it as a Byte array.
				    Byte[] data = Encoding.ASCII.GetBytes(myMessage);         

				    // Get a client stream for reading and writing.
				   //  Stream stream = client.GetStream();

				    NetworkStream stream = client.GetStream();

				    // Send the message to the connected TcpServer. 
				    stream.Write(data, 0, data.Length);

                    // Receive the TcpServer.response.

                    // Buffer to store the response bytes.
                    //data = new Byte[256];
                    string datas;
				    // String to store the response ASCII representation.
				    String responseData = String.Empty;
                    int i;
                    Byte[] bytes = new Byte[256];
                    // Read the first batch of the TcpServer response bytes.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        datas = Encoding.ASCII.GetString(bytes, 0, i);
                        //Cleans info from string
                        Console.WriteLine(data);
                        //send.SendChat(data);
                        break;
                    }
                    //Int32 bytes = stream.Read(data, 0, data.Length);
				    //responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
				    //Console.WriteLine("Received: {0}", responseData);         

				    //Close everything.
				    stream.Close();         
				    client.Close();  
				}
			  } 
			  catch (ArgumentNullException e) 
			  {
			    Console.WriteLine("ArgumentNullException: {0}", e);
			  } 
			  catch (SocketException e) 
			  {
			    Console.WriteLine("SocketException: {0}", e);
			 }
			}
            */
		}
	}
}
