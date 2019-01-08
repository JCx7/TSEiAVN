using System;
using UnityEngine;
using UnityEngine.Playables;
using TSEiA;

[Serializable]
public class EnvisionIndicatorBehaviour : PlayableBehaviour
{
    public string fileName;
    private bool isFirst = true;
    public override void OnPlayableCreate (Playable playable)
    {
        
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (isFirst) {
            TSEiATimelineManager.Instance.PauseTimeline();
            GameObject.Find("EnvisioningTemplate").transform.GetChild(0).gameObject.SetActive(true);
            isFirst = false;
        }

    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {

    }
}
