using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class WalkToClip : PlayableAsset, ITimelineClipAsset
{
    public WalkToBehaviour template = new WalkToBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.All; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<WalkToBehaviour>.Create (graph, template);
        WalkToBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
