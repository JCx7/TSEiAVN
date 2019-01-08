using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.006974488f, 0.4651959f, 0.9485294f)]
[TrackClipType(typeof(WalkToClip))]
public class WalkToTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<WalkToMixerBehaviour>.Create (graph, inputCount);
    }
}
