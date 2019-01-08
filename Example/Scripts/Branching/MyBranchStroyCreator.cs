using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSEiA;
using UnityEngine.Timeline;

public class MyBranchStroyCreator : MonoBehaviour {

    public TSEiATimelineManager timelineManager;
    public TSEiAStoryManager storyManager;
    public GameObject actor;

    public GameObject optionPanel;

	// Use this for initialization
	void Start () {
        timelineManager.AddVNTrackSet(actor);
        //        timelineManager.AddAnimationClip(TSEiAResourceManager.GetAnimation("argue"), actor);

        timelineManager.AddTrack(new ActivationTrack(), optionPanel, "activation");

        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("argue"), "Hello", -0.5);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "blabalblablabl", -0.5);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "this is the first branch", -0.5);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("argue"), "I don't know ", -0.5);

        timelineManager.AddCustomClip("activation", 0);

        storyManager.AddNewBranch("new branch one", 5.0);
        storyManager.DoChoice(0);
        timelineManager.AddVNTrackSet(actor);
        timelineManager.AddTrack(new ActivationTrack(), optionPanel, "activation");

        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("argue"), "Hello", -0.5);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "this is the first sub-branch of the original branch", -0.5);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "because you just cliked on the first button", -0.5);
        timelineManager.AddCustomClip("activation", 0);
        storyManager.GoBackLevel();

        storyManager.AddNewBranch("new branch two", 5.0);
        storyManager.DoChoice(1);
        timelineManager.AddVNTrackSet(actor);
        timelineManager.AddTrack(new ActivationTrack(), optionPanel, "activation");

        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("argue"), "Hello", -0.5);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "this is the second sub-branch of the original branch", -0.5);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "because you just cliked on the second button", -0.5);
        timelineManager.AddCustomClip("activation", 0);
        storyManager.GoBackLevel();

        storyManager.AddNewBranch("new branch three", 5.0);
        storyManager.DoChoice(2);
        timelineManager.AddVNTrackSet(actor);
        timelineManager.AddTrack(new ActivationTrack(), optionPanel, "activation");

        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("argue"), "Hello", -0.5);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "this is the third sub-branch of the original branch", -0.5);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "because you just cliked on the third button", -0.5);
        timelineManager.AddCustomClip("activation", 0);

        storyManager.AddNewBranch("new branch one - one", 5.0);
        storyManager.DoChoice(0);
        timelineManager.AddVNTrackSet(actor);
        timelineManager.AddTrack(new ActivationTrack(), optionPanel, "activation");

        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("argue"), "Hello", -0.5);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "this is the first sub-branch of the new branch three", -0.5);
        timelineManager.Speak(actor, TSEiAResourceManager.GetAnimation("talk"), "because you just cliked on the first button", -0.5);
        timelineManager.AddCustomClip("activation", 0);
        storyManager.GoBackLevel();
        storyManager.GoBackLevel();

        timelineManager.StartTimeline();
    }
	


	// Update is called once per frame
	void Update () {
		
	}
}
