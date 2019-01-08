using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.07186722f, 0.4840468f, 0.8962264f)]
[TrackClipType(typeof(NavAgentTravelClip))]
[TrackBindingType(typeof(GameObject))]
public class NavAgentTravelTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<NavAgentTravelMixerBehaviour>.Create (graph, inputCount);
    }
}
