using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.03676468f, 0.5055372f, 1f)]
[TrackClipType(typeof(EnvisionIndicatorClip))]
public class EnvisionIndicatorTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<EnvisionIndicatorMixerBehaviour>.Create (graph, inputCount);
    }
}
