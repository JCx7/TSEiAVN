using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitlePanel : MonoBehaviour {

    TextMeshProUGUI subtitle;

	// Use this for initialization
	void Start () {
        subtitle = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        subtitle.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
