using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSEiA;
using TMPro;

public class ControlPanel : MonoBehaviour {
    TMP_InputField branchName;
	// Use this for initialization
	void Start () {
        branchName = transform.GetChild(2).GetComponent<TMP_InputField>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnAddBranchClicked() {
        TSEiAStoryManager.Instance.AddNewBranch(branchName.text, 5.0);
        GameObject.FindGameObjectWithTag("Preview").GetComponent<PreviewPanel>().SetupPreview();
    }
}
