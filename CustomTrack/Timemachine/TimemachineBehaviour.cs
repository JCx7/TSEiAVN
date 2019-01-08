using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TimemachineBehaviour : PlayableBehaviour
{
    public bool jump = false;

    public double jumpToTime;

    private bool condition = false;
    private PlayableDirector playableDirector;
    public override void OnPlayableCreate (Playable playable)
    {
        playableDirector = (playable.GetGraph().GetResolver() as PlayableDirector);
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        Debug.Log(playableDirector.time);
        playableDirector.Pause();
        if (jump) {
            playableDirector.time = jumpToTime;
        }
    }
/*
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {      
        if (jump) {
            playableDirector.time = jumpToTime;
        }
    }
    */
    void CheckCondition() {

    }
}
