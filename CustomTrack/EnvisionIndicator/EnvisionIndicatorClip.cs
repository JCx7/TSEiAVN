using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class EnvisionIndicatorClip : PlayableAsset, ITimelineClipAsset
{
    public EnvisionIndicatorBehaviour template = new EnvisionIndicatorBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<EnvisionIndicatorBehaviour>.Create (graph, template);
        EnvisionIndicatorBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
