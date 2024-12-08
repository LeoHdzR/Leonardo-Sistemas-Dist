using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatP2P;

public class Peer {
    private readonly TcpListener _listener;
    private TcpClient? _client;
    private const int Port = 8080;

    public Peer() => _listener = new TcpListener(IPAddress.Any, Port);

    public async Task ConnectToPeer(string IPAddress, string port)
    {
        try
        {
            _client = new TcpClient(IPAddress, Convert.ToInt32(port));
            Console.WriteLine("Connecting to peer...");

            var communicationTask = Communicate();
        await communicationTask;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Connection closed :c " + ex.Message);
    }
}

    private async Task Communicate()
    {
        var receiveTask = Task.Run(ReceiveMessages);
        var sendTask = Task.Run(SendMessages);

        await Task.WhenAny(receiveTask, sendTask); // Keeps running until one task completes
    }

   public async Task StartListening()
{
    try
    {
        _listener.Start();
        Console.WriteLine("Listening for connections...");
        _client = await _listener.AcceptTcpClientAsync();
        Console.WriteLine("Connected to peer xD");

        var communicationTask = Communicate();
        await communicationTask;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Connection closed :c " + ex.Message);
    }
}

    private async Task ReceiveMessages()
{
    try
    {
        var stream = _client!.GetStream();
        var reader = new StreamReader(stream, Encoding.UTF8);

        while (true)
        {
            var message = await reader.ReadLineAsync();
            if (message == null) break;
            Console.WriteLine($"Peer message: {message}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error receiving message: {ex.Message}");
    }
    finally
    {
        Close();
    }
}

    private async Task SendMessages()
{
    try
    {
        var stream = _client!.GetStream();
        var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

        while (true)
        {
            Console.Write("> ");
            var message = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(message)) break;

            await writer.WriteLineAsync(message);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error sending messages: {ex.Message}");
    }
    finally
    {
        Close();
    }
}

    private void Close()
    {
        _client?.Close();
        _listener.Stop();
    }
}