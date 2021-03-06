using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class NavigationControlBehaviour : PlayableBehaviour
{

    public Transform destination;
    public bool destinationSet;

    public override void OnPlayableCreate(Playable playable)
    {
        destinationSet = false;
    }
}
