using UnityEngine;
using System.Collections;

using ZeroMQ;
using System.Collections.Generic;
using TSEiA;

/// <summary>
/// class to connect to NLP server
/// </summary>
public class ConnectManager : Singleton<ConnectManager> {

    public string serverAddress;

    private ZContext context;
    private ZSocket requester;

    // list to restore all relations from the script
    private string labelString;

	// Use this for initialization
	void Start () {
        context = new ZContext();
        requester = new ZSocket(context, ZSocketType.REQ);
        ConnectToServer();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ConnectToServer() {
        requester.Connect("tcp://" + serverAddress + ":7777");
        Debug.Log("Connected");
    }

    public void SendScript(string script) {
        requester.Send(new ZFrame("<SCRIP>" + script));
    }

    public void SendName(string names) {
        requester.Send(new ZFrame("<NAMES>" + names));
    }

    public void SendSpeak(string speak) {
        requester.Send(new ZFrame("<SPEAK>" + speak));
    }

    public List<List<string>> ReceiveLabel() {
        List<List<string>> actionSequence = new List<List<string>>();
        using (ZFrame reply = requester.ReceiveFrame()) {
            labelString = reply.ReadString();
            Debug.Log(labelString);
            string label = labelString.Substring(0, 7);
            // if get the script
            if (label.Equals("<SCRIP>") && !labelString.Equals(""))
            {
                labelString = labelString.Substring(7);
                string[] actionEvents = labelString.Split(';');
                for (int i = 0; i < actionEvents.Length; i++)
                {
                    string[] actions = actionEvents[i].Split('_');
                    List<string> actionsList = new List<string>();
                    for (int j = 0; j < actions.Length; j++)
                    {
                        actionsList.Add(actions[j]);
                    }
                    actionSequence.Add(actionsList);
                }
            }
            // if get the speak
            else if (label.Equals("<SPEAK>") && !labelString.Equals("")) {
                labelString = labelString.Substring(7);
                string[] speakEvents = labelString.Split(';');
                for (int i = 0; i < speakEvents.Length; i++) {
                    string[] speaks = speakEvents[i].Split('_');
                    List<string> speaksList = new List<string>();
                    for (int j = 0; j < speaks.Length; j++) {
                        speaksList.Add(speaks[j]);
                    }
                    actionSequence.Add(speaksList);
                }
            }
            
        }

        return actionSequence;
    }
}