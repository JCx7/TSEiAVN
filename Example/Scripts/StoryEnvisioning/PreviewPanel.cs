using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TSEiA;
using System.Linq;

public class PreviewPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetupPreview() {
        RemoveAllComponents();
        SetupNode(TSEiAStoryManager.Instance.branchTree.root);
    }

    private void SetupNode(TSEiATreeNode node) {
        GameObject slot = Instantiate(Resources.Load("UIComponents/Slot")) as GameObject;
        slot.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = node.branch.Name;
        slot.transform.SetParent(transform);
        slot.transform.localScale = new Vector3(1, 1, 1);
        slot.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(OnBranchButtonClicked);

        if (node.children.Any()) {
            foreach (TSEiATreeNode child in node.children) {
                SetupNode(child);
            }
        }
    }

    private void RemoveAllComponents() {
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void OnBranchButtonClicked() {
        string branchName = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text;
        TSEiAStoryManager.Instance.SwitchBranch(branchName);
    }
}
