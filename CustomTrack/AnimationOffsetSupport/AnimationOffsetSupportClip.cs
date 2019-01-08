using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class AnimationOffsetSupportClip : PlayableAsset, ITimelineClipAsset
{
    public AnimationOffsetSupportBehaviour template = new AnimationOffsetSupportBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Looping | ClipCaps.Extrapolation | ClipCaps.ClipIn | ClipCaps.SpeedMultiplier; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<AnimationOffsetSupportBehaviour>.Create (graph, template);
        AnimationOffsetSupportBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
