using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class EnvisionPlayClip : PlayableAsset, ITimelineClipAsset
{
    public EnvisionPlayBehaviour template = new EnvisionPlayBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<EnvisionPlayBehaviour>.Create (graph, template);
        EnvisionPlayBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
