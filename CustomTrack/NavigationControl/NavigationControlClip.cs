using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.AI;

[Serializable]
public class NavigationControlClip : PlayableAsset, ITimelineClipAsset
{
    public NavigationControlBehaviour template = new NavigationControlBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.All; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<NavigationControlBehaviour>.Create (graph, template);
        NavigationControlBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
