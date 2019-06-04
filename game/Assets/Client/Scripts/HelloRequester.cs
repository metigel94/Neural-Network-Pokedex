using AsyncIO;
using NetMQ;
using NetMQ.Sockets;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Linq;


///     You can copy this class and modify Run() to suits your needs.
///     To use this class, you just instantiate, call Start() when you want to start and Stop() when you want to stop.


public class HelloRequester : RunAbleThread
{
    public string messageToSend;
    public static int[] finalPath;
    public static string message = null;

    ///     Stop requesting when Running=false.
    protected override void Run()
    {
        ForceDotNet.Force();

        using (RequestSocket client = new RequestSocket())
        {
            client.Connect("tcp://localhost:5550");
            while(Running)
            {
                if (Send)
                {
                    //string message = client.ReceiveFrameString();
                    client.SendFrame(messageToSend);
                    

                    message = null;
                    bool gotMessage = false;

                    while (Running)
                    {
                        gotMessage = client.TryReceiveFrameString(out message); // this returns true if it's successful
                        if (gotMessage) break;
                    }
                    if (gotMessage)
                    {
                        Debug.Log("Received " + message);
                        //GameObject.Find("PokeDex").GetComponent<pokeBoy>().Status = GameObject.Find("PokeDex").GetComponent<pokeBoy>().Status +  "\n" + message; 



                        // finalPath = finalStringPath.Select(s => int.Parse(s)).ToArray();

                        // wird wird empfangen

                    }
                }       
            }
        }

        NetMQConfig.Cleanup();
    }
}