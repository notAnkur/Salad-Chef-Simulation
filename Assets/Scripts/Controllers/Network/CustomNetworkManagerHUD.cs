using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Net.Sockets;
using UnityEngine.UI;

public class CustomNetworkManagerHUD : MonoBehaviour
{
    TelepathyTransport telepathyTransport;
    NetworkManager networkManager;

    // host input fields
    [SerializeField] private InputField hostIpAddress;
    [SerializeField] private InputField hostPort;

    // client input fields
    [SerializeField] private InputField clientIpAddress;
    [SerializeField] private InputField clientPort;

    private void Awake()
    {
        networkManager = GetComponent<NetworkManager>();
        telepathyTransport = GetComponent<TelepathyTransport>();
    }

    public void StartHost()
    {
        if(!NetworkClient.isConnected && !NetworkServer.active)
        {
            if(!NetworkClient.active)
            {
                Debug.Log("StartHost: Starting server");
                NetworkSetup(hostIpAddress.text, hostPort.text);
                networkManager.StartHost();
            }
        }
    }

    public void StopHost()
    {
        if(NetworkServer.active && NetworkClient.isConnected)
        {
            networkManager.StopHost();
        }
    }

    public void StartClient()
    {
        if(!NetworkClient.active)
        {
            try
            {
                NetworkSetup(clientIpAddress.text, clientPort.text);
                networkManager.StartClient();
            } catch(SocketException socketEx)
            {
                Debug.Log($"Cannot connect: {socketEx.Message}");
            }
        }
    }

    private void NetworkSetup(string ip, string strPort)
    {
        NetworkManager.singleton.networkAddress = string.IsNullOrEmpty(ip) ? "127.0.0.1" : ip;
        ushort port = 0;
        // parse the port to ushort
        telepathyTransport.port = ushort.TryParse(strPort, out port) ? port : (ushort)7777;
    }
}
