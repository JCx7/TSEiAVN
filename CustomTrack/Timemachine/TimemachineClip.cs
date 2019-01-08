using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TimemachineClip : PlayableAsset, ITimelineClipAsset
{
    public TimemachineBehaviour template = new TimemachineBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<TimemachineBehaviour>.Create (graph, template);
        TimemachineBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
