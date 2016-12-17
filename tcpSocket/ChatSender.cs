using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;

//By Thomas Jansson
//For support use google...

namespace tcpSocket
{
    class ChatSender
    {
        string serverHost = "XX.XX.XX.XX"; //public IP to the host
        TcpClient client;
        Int32 port;
        NetworkStream stream = null;
        string myMessage;
        ThreadStart ChatReading;
        Thread Reader = null;
        
        public ChatSender()
        {
            Console.WriteLine("Please enter server port!");
            port = Int32.Parse(Console.ReadLine());
            if (serverHost == "")
            {
                Console.WriteLine("DEBUG: No default host IP has been added in code. Add host IP:");
                serverHost = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Connecting to host: {0}", serverHost);
            }
            client = new TcpClient(serverHost, port);
            while (true)
            {
                try
                {
                    // Create a TcpClient.
                    // Note, for this client to work you need to have a TcpServer 
                    // connected to the same address as specified by the server, port
                    // combination.

                    // Translate the passed message into ASCII and store it as a Byte array.
                    if (Reader == null)
                    {
                        ChatReading = new ThreadStart(ReadResponse);
                        Reader = new Thread(ChatReading);
                        Reader.Start();
                    }

                    if (stream == null)
                    {
                        stream = client.GetStream();
                    }
                    // Send the message to the connected TcpServer.
                    myMessage = Console.ReadLine();
                    Byte[] data = Encoding.ASCII.GetBytes(myMessage);
                    try
                    {
                        stream.Write(data, 0, data.Length);
                    } catch
                    {
                        return;
                    }

                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("ArgumentNullException: {0}", e);
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        void ReadResponse()
        {
            while (true)
            {
                string datas;
                // String to store the response ASCII representation.
                String responseData = String.Empty;
                int i;
                Byte[] bytes = new Byte[256];
                // Read the first batch of the TcpServer response bytes.
                try
                {
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        datas = Encoding.ASCII.GetString(bytes, 0, i);
                        //Cleans info from string
                        Console.WriteLine(datas);
                        //send.SendChat(data);
                        break;
                    }
                } catch (Exception e)
                {
                    //Console.WriteLine(e.GetBaseException());
                    if (e.ToString().Contains("An existing connection was forcibly closed by the remote host"))
                    {
                        Console.WriteLine("The server closed the connection.");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine(e);
                        Console.ReadKey();
                    }
                }
            }
            
        }
    }
}
