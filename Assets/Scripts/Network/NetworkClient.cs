using UnityEngine;
using LiteNetLib;
using System.Net;
using System.Net.Sockets;
using LiteNetLib.Utils;

public class NetworkClient : MonoBehaviour, INetEventListener
{
    private NetManager _netManager;
    private NetPeer _serverPeer;
    private NetDataWriter _dataWriter;

    private static NetworkClient _instance;

    public static NetworkClient Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else 
        {
            _instance = this;
        }
    }
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        _netManager.PollEvents();
    }

    private void Init()
    {
        _dataWriter = new NetDataWriter();
        _netManager = new NetManager(this)
        {
            DisconnectTimeout = 100000
        };
        _netManager.Start();
    }

    #region public methods
    public void Connect()
    {
        _netManager.Connect("localhost", 9050, "");
    }

    public void SendData(string data)
    {
        if (_serverPeer != null)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(data);
            _serverPeer.Send(bytes, DeliveryMethod.ReliableOrdered);
        }
    }
    #endregion

    #region INetEventListener implementation
    public void OnNetworkReceive(NetPeer peer, NetPacketReader reader, byte channelNumber, DeliveryMethod deliveryMethod)
    {
        // "\0" 計算機的null
        var message = System.Text.Encoding.UTF8.GetString(reader.RawData).Replace("\0","");
        Debug.Log("Received from server: " + message);
    }

    public void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType)
    {
        throw new System.NotImplementedException();
    }
    //連接上server後會呼叫此方法 (peer連接上的裝置)
    public void OnPeerConnected(NetPeer peer)
    {
        //EndPoint = ip + port
        Debug.Log($"Connected to server:{peer.Address}:{peer.Port}");
        _serverPeer = peer;
    }

    public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
    {
        Debug.Log("Disconnected from server");
        if (_serverPeer == peer)
        {
            _serverPeer = null;
        }
    }

    public void OnConnectionRequest(ConnectionRequest request)
    {
        throw new System.NotImplementedException();
    }

    public void OnNetworkError(IPEndPoint endPoint, SocketError socketError)
    {
        throw new System.NotImplementedException();
    }

    // 顯示當前延遲
    public void OnNetworkLatencyUpdate(NetPeer peer, int latency)
    {
        Debug.Log($"延遲: {latency}ms");

        if (latency > 200)
        {
            Debug.Log("網路延遲過高！");
        }
    }
    #endregion
}
