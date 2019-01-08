using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using TSEiA;
using Cinemachine.Timeline;

public class SequenceGenerateController : MonoBehaviour {

    StoryCreator storyCreator;

    List<string> animationList = new List<string>();
    Transform operationPanel;
    public GameObject instructionPanel;
	// Use this for initialization
	void Start () {

        storyCreator = GameObject.Find("StoryCreator").GetComponent<StoryCreator>();

        animationList = TSEiAResourceManager.LoadAnimation();
        operationPanel = gameObject.transform.GetChild(0);
        for (int i = 0; i < operationPanel.childCount - 2; i++) {
            operationPanel.GetChild(i).gameObject.GetComponent<Dropdown>().AddOptions(animationList);
        }
	}

    // triggered when the generated button is clicked
    public void OnGenerateClicked() {
        storyCreator.storyManager.CreateNewBranch("new", 0.0);
        storyCreator.storyManager.DoChoice(0);
        storyCreator.timelineManager.AddTrack(new AnimationTrack(), storyCreator.actor);
        CinemachineTrack cameraTrack = storyCreator.timelineManager.AddTrack(new CinemachineTrack(), "Camera") as CinemachineTrack;
        CinemachineShot cameraClip = storyCreator.timelineManager.AddCustomClipWithInitialTime(cameraTrack, 0) as CinemachineShot;


        storyCreator.ResetActioPosition();
        for (int i = 0; i < operationPanel.childCount - 2; i++) {
            int option = operationPanel.GetChild(i).GetComponent<Dropdown>().value;
            if (animationList[option] != "None") {
                storyCreator.timelineManager.AddAnimationClip(TSEiAResourceManager.GetAnimation(animationList[option]), 
                    storyCreator.actor, -0.1, false);
            }
        }
        storyCreator.timelineManager.StartTimeline();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I)) {
            instructionPanel.SetActive(!instructionPanel.activeSelf);
        }
	}
}
