using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class NavAgentTravelClip : PlayableAsset, ITimelineClipAsset
{
    public NavAgentTravelBehaviour template = new NavAgentTravelBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.All; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<NavAgentTravelBehaviour>.Create (graph, template);
        NavAgentTravelBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
