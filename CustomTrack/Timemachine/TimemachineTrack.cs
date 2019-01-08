using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.02238324f, 1f, 0.1934734f)]
[TrackClipType(typeof(TimemachineClip))]
public class TimemachineTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<TimemachineMixerBehaviour>.Create (graph, inputCount);
    }
}
