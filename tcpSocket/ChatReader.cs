using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;

class ChatReader
{
    public InputCleaner cleaner = new InputCleaner();
    public string sentString = "";  //Dirty solution but the easiest one so far...
    public NetworkStream stream = null;

    public void Start()
    {
        ThreadStart ChatReading = new ThreadStart(Listen);
        Thread Reader = new Thread(ChatReading);
        Reader.Start();
    }

    public void Listen()
    {
        TcpListener server = null;

        try
        {
            
            while (true)
            {
                // Get a stream object for reading and writing
                Byte[] bytes = new Byte[256];
                String data = null;
                int i;

                //addresses.AddIP(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
                //((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() <-- Gets IP address!

                // Loop to receive all the data sent by the client.
                Console.WriteLine(2);

                try
                {
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = Encoding.ASCII.GetString(bytes, 0, i);
                        //Cleans info from string
                        Console.WriteLine(data);
                        if (data.StartsWith("CONNECTINGPORT:"))
                        { //&& addresses.findIP (((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()) == false){
                            data = data.Replace("CONNECTINGPORT:", "");
                            //addresses.AddClients(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString(), Int32.Parse(data));
                        } else
                        {
                            Console.WriteLine(data);
                        }
                        
                        break;
                    }
                }
                catch (Exception e)
                {
                    ///Console.WriteLine("Client disconnected, closing thread number {0}", mySpot);
                    Console.WriteLine(e);
                    ///myThreads[mySpot].Abort();
                }
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            // Stop listening for new clients.
            server.Stop();
        }
    }
    /*
    public string GetIPAddress()
    {
        IPHostEntry host;
        string localIP = "?";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
            }
        }
        return localIP;
    }*/
}
