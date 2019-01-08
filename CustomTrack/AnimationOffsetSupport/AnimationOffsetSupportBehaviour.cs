using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class AnimationOffsetSupportBehaviour : PlayableBehaviour
{
    private PlayableDirector playableDirector;

    public GameObject bindingObject;
    public AnimationPlayableAsset animationPlayableAsset;

    public override void OnPlayableCreate (Playable playable)
    {
        playableDirector = (playable.GetGraph().GetResolver()) as PlayableDirector;     
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        animationPlayableAsset.position = bindingObject.transform.position;
        animationPlayableAsset.rotation = bindingObject.transform.rotation;
    }
}
