using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using TSEiA;
using Cinemachine.Timeline;

public class StoryCreator : MonoBehaviour {

    public TSEiATimelineManager timelineManager;
    public TSEiAStoryManager storyManager;
    public ConnectManager connectManager;

    public GameObject actor;
    public GameObject optionPanel;

    private List<string> scriptList = new List<string>();
    int scriptIndex = 0;

	// Use this for initialization
	void Start () {
        scriptList.Add("She sneaked to the room and stole the item from the shelf.");
        scriptList.Add("She sneaked towards him and killed him from back.");
        scriptList.Add("She stood there for a while, waving hand to me and finally turned around and ran away.");
        scriptList.Add("She waved hand to him so that he could notice her. She walked to him and shook hand with him.");
        scriptList.Add("After hearing that she won the prize, she danced happily.");
        scriptList.Add("She dose exercise everyday in order to keep her body in good shape.");
        scriptList.Add("She really loves those days on the farm. Everyday she picks up the fruit and water the veggies.");
        scriptList.Add("She grabbed the torch from the ground telling herself that everything will be fine. Then she encouraged herself and went deeper to search for the item she needed to cure her mother.");
        scriptList.Add("She digged a hole and planted the tree. Looking at the litte tree, she felt very satisified. \"Oh, I also need water\", thinking of this, she grabbed the watering pot and watered the little tree.");
        scriptList.Add("Losing her job, she felt so disappointed at the herself. She was so helpless. She stopped when she passed the store. Looking into the shelf, she could see the necklece is still there, but not shining anymore.");
        scriptList.Add("That day she had an arguement with him. She found he didn't care anything about her. He left and she cried, again.");
        scriptList.Add("She successfully sneaked into the basement. It was so dark that she couldn't see anything. She lit the torch and tried to go deeper inside.");
        scriptList.Add("Calming down, she could be one hundred percent focus. Setting up, aiming, drive and she made it. And she didn't forget to laugh at her oppnents in the end.");
        // register resource database to the word embedding server
        TSEiAResourceManager.LoadAnimation();
        /*
        Debug.Log(TSEiAResourceManager.GetAnimation("drunkwalk"));

        timelineManager.AddTrack(new AnimationTrack(), actor);
        timelineManager.AddAnimationClip(TSEiAResourceManager.GetAnimation("drunkwalk"), actor, 0, false);
        timelineManager.AddAnimationClip(TSEiAResourceManager.GetAnimation("holdwalk"), actor, -0.1, false);

        timelineManager.AddTrack(new CinemachineTrack(), camera, "CameraTrack");
        CinemachineShot cinemaClip = timelineManager.AddCustomClip("CameraTrack", 0) as CinemachineShot;
        */
        SetBranch();
	}

    public void SetBranch() {
        timelineManager.AddVNTrackSet(actor);
        timelineManager.AddTrack(new ActivationTrack(), optionPanel, "activation");
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "This is the example of branching system", 0);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("confuse"), "You can create your own story and actions via script", 0);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("argue"), "Click on those buttons to select branch", 0);
        timelineManager.AddCustomClip("activation", 0);

        storyManager.AddNewBranch("branch one", 5.0);
        storyManager.DoChoice(0);
        timelineManager.AddVNTrackSet(actor);
        timelineManager.AddTrack(new ActivationTrack(), optionPanel, "activation");
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "Hey there", 0);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("confuse"), "You just chose the first branch", 0);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("argue"), "You can also customize the option panel by yourself", 0);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "For example, you can set button for going backward to upper branch.", 0);
        timelineManager.AddCustomClip("activation", 0);
        storyManager.GoBackLevel();

        storyManager.AddNewBranch("branch two", 5.0);
        storyManager.DoChoice(1);
        timelineManager.AddVNTrackSet(actor);
        timelineManager.AddTrack(new ActivationTrack(), optionPanel, "activation");
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "Hey there", 0);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("confuse"), "You just chose the second branch", 0);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("argue"), "You can also customize the option panel by yourself", 0);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "For example, you can set button for going backward to upper branch.", 0);
        timelineManager.AddCustomClip("activation", 0);
        storyManager.GoBackLevel();

        timelineManager.StartTimeline();
    }

    public void ResetActioPosition() {
        actor.transform.position = new Vector3(0, 0, 0);
        actor.transform.rotation = Quaternion.identity;
    }

	// Update is called once per frame
	void Update () {

        
        if (Input.GetKeyDown(KeyCode.S)) {
            connectManager.SendScript("She digged a hole and planted the tree. Looking at the litte tree, she felt very satisified. \"Oh, I also need water\", thinking of this, she grabbed the watering pot and watered the little tree.");
            List<List<string>> labelsList = new List<List<string>>();
            labelsList = connectManager.ReceiveLabel();

            // set up branch
            storyManager.DoChoice(1);
            storyManager.AddNewBranch("branch two one", 5.0);
            storyManager.DoChoice(0);
            timelineManager.AddTrack(new ActivationTrack(), optionPanel, "activation");
            foreach (List<string> label in labelsList) {
                GameObject specialActor = GameObject.Find(label[0]);
                timelineManager.AddVNTrackSet(specialActor);
                for(int i = 1 ; i < label.Count ; i++) {
                    timelineManager.Speak(specialActor, TSEiAResourceManager.GetAnimation(label[i]), "Hey there", 0);
                }
            }
            timelineManager.AddCustomClip("activation", 0);
            storyManager.GoTop();
            timelineManager.StartTimeline();
            scriptIndex++;
        }

	}
}
