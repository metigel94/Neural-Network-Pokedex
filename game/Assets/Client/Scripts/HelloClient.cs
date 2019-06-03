using UnityEngine;
using AsyncIO;
using NetMQ;
using NetMQ.Sockets;

public class HelloClient : MonoBehaviour
{
    public static HelloRequester _helloRequester;
    public static bool SendPack = true;
    public Quaternion joint;
    public Transform pos;
    string message;
    string pokenumber;

    
    void Update()
    {
        if (SendPack)
        {


            _helloRequester.messageToSend = playerInteract.pokenumber.ToString();

           

            _helloRequester.Continue();

        } else if (!SendPack)
        {
            _helloRequester.Pause();
        }
    }

    private void Start()
    {
        _helloRequester = new HelloRequester();
        Debug.Log("HelloClientNormal");
        _helloRequester.Start();
    }

    private void OnDestroy()
    {
        _helloRequester.Stop();
    }
}