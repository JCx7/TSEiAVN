using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class NavAgentTravelBehaviour : PlayableBehaviour
{
    public Transform destination;

    public override void OnPlayableCreate (Playable playable)
    {
        
    }
}
