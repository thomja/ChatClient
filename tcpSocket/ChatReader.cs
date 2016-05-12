using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;

class ChatReader
{
    public string myIPAddress;
	public Int32 currentPort;
    public InputCleaner cleaner = new InputCleaner();
    public string sentString = "";  //Dirty solution but the easiest one so far...

	public ChatReader(Int32 port)
    {
		currentPort = port;
        this.myIPAddress = "192.168.0.196";
        Start();
    }

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
            // TcpListener server = new TcpListener(port);
            server = new TcpListener(IPAddress.Parse(this.myIPAddress), currentPort);

            // Start listening for client requests.
            server.Start();

            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            String data = null;

            // Enter the listening loop.
            while (true)
            {
                // Perform a blocking call to accept requests.
                // You could also user server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();

                data = null;

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();


                int i;

                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    data = data.Replace("Replying: ", "");
                    if(data != sentString)
                    {
                        Console.WriteLine(data);
                        sentString = "";
                    } else
                    {
                        sentString = "";
                    }
                    break;
                }

                // Shutdown and end connection
                client.Close();
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
    }
}
