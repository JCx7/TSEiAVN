using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.05109212f, 0.9926471f, 0.5251163f)]
[TrackClipType(typeof(EnvisionPlayClip))]
public class EnvisionPlayTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<EnvisionPlayMixerBehaviour>.Create (graph, inputCount);
    }
}
