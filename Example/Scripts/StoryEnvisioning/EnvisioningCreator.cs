using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSEiA;
using TMPro;
using System;

public class EnvisioningCreator : MonoBehaviour {
    public TSEiAStoryManager storyManager;
    public TSEiATimelineManager timelineManager;

    public ConnectManager connectManager;
    public Transform originalPosition_A;
    public Transform originalPosition_B;

    public GameObject storyPanel;
	// Use this for initialization
	void Start () {
        TSEiAResourceManager.LoadAnimation();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // what happened if the send button were clicked
    public void OnSendButtonClicked() {
        // check the story content 
        string content = storyPanel.transform.GetChild(0).GetComponent<TMP_InputField>().text;
        List<List<string>> labelsList = new List<List<string>>();
        if (content.Contains(":"))
        {
            connectManager.SendSpeak(content);
            labelsList = connectManager.ReceiveLabel();

            foreach (List<string> labels in labelsList) {
                Debug.Log(labels[0]);
                GameObject subject = GameObject.Find(labels[0]);

                if (subject == null) {
                    continue;
                }

                Debug.Log("Track count before Adding:" + timelineManager.IsObjectHasVNTrackSet(subject));

                if (!timelineManager.IsObjectHasVNTrackSet(subject)) {
                    timelineManager.AddVNTrackSet(subject);
                }

                Debug.Log("Track count after Adding:" + timelineManager.IsObjectHasVNTrackSet(subject));

                System.Random rdm = new System.Random();
                int rrrr = rdm.Next(1, 3);
                Debug.Log(rrrr);
                if (rrrr == 1)
                {
                    timelineManager.Speak(GameObject.Find(labels[0]), TSEiAResourceManager.GetAnimation("argue"), labels[1], 0);
                }
                else if (rrrr == 2) {
                    timelineManager.Speak(GameObject.Find(labels[0]), TSEiAResourceManager.GetAnimation("talk"), labels[1], 0);
                }

                Debug.Log(timelineManager.GetTimelineAsset().duration);
//                timelineManager.DoAnimationWhileSpeaking(TSEiAResourceManager.GetAnimation("talk"), labels[1], GameObject.Find(labels[0]), 0);
            }
        }
        else {
            connectManager.SendScript(content);
            labelsList = connectManager.ReceiveLabel();

            foreach (List<string> labels in labelsList) {
                GameObject actor = GameObject.Find(labels[0]);

                if (actor == null) {
                    continue;
                }

                Debug.Log("Track count before Adding:" + timelineManager.IsObjectHasVNTrackSet(actor));

                if (!timelineManager.IsObjectHasVNTrackSet(actor)) {
                    timelineManager.AddVNTrackSet(actor);
                }

                Debug.Log("Track count after Adding:" + timelineManager.IsObjectHasVNTrackSet(actor));
                for (int i = 1; i < labels.Count; i++) {

                    timelineManager.AddAnimationClip(TSEiAResourceManager.GetAnimation(labels[i]), actor, 0, false);
                }
            }
        }

        timelineManager.StartTimeline();
        storyPanel.transform.GetChild(0).GetComponent<TMP_InputField>().text = "";
    }

    public void ResetPosition(Transform position, GameObject actor) {
        actor.transform.localPosition = position.position;
    }
}
