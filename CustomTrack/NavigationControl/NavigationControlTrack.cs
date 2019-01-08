using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.AI;

[TrackColor(1f, 0.0522275f, 0.5500612f)]
[TrackClipType(typeof(NavigationControlClip))]
[TrackBindingType(typeof(NavMeshAgent))]
public class NavigationControlTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<NavigationControlMixerBehaviour>.Create (graph, inputCount);
    }
}
