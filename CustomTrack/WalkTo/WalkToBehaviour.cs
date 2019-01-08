using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.AI;
using TSEiA;

[Serializable]
public class WalkToBehaviour : PlayableBehaviour
{
    public GameObject actor;
    public NavMeshAgent meshAgent;
    public Transform destination;
    public bool destinationSet;

    public AnimationClip animationClip;

    public override void OnPlayableCreate(Playable playable)
    {
        destinationSet = false;
        actor = GameObject.Find("xbot");
        destination = GameObject.Find("targetPosition2").transform;
        animationClip = Resources.Load("Run") as AnimationClip;
        meshAgent = actor.GetComponent<NavMeshAgent>();
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        NavMeshPath path = new NavMeshPath();
        meshAgent.CalculatePath(destination.position, path);
        if (path.corners.Length < 2)
        {
            return;
        }

        Vector3 previousCorner = path.corners[0];
        float lengthSoFar = 0.0f;
        int i = 1;
        while (i < path.corners.Length)
        {
            Vector3 currentCorner = path.corners[i];
            lengthSoFar += Vector3.Distance(previousCorner, currentCorner);
            previousCorner = currentCorner;
            i++;
        }
        double navTime = lengthSoFar / meshAgent.speed;
        Debug.Log("NavTime: " + navTime);
    }
}
