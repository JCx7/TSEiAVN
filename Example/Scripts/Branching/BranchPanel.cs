using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TSEiA;
using System;

public class BranchPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}

    private void OnEnable()
    {
        
        int number = TSEiAStoryManager.Instance.GetBranchCount();
        Debug.Log(number);
        for (int i = 0; i < number; i++) {
            int j = i;
            GameObject newButton = Instantiate(Resources.Load("UIComponents/Button")) as GameObject;
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.transform.SetParent(transform, false);
            newButton.GetComponent<Button>().onClick.AddListener(delegate () { OnButtonClicked(j); });
        }
    }

    private void OnButtonClicked(int i)
    {
        Debug.Log(i);
        TSEiAStoryManager.Instance.DoChoice(i);
        TSEiATimelineManager.Instance.StartTimeline();
    }

    private void OnDisable()
    {
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
