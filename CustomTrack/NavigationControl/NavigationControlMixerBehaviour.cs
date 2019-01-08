using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.AI;

public class NavigationControlMixerBehaviour : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        NavMeshAgent trackBinding = playerData as NavMeshAgent;

        if (!trackBinding)
            return;

        int inputCount = playable.GetInputCount();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<NavigationControlBehaviour> inputPlayable = (ScriptPlayable<NavigationControlBehaviour>)playable.GetInput(i);
            NavigationControlBehaviour input = inputPlayable.GetBehaviour();

            if (inputWeight > 0.5f && !input.destinationSet && input.destination)
            {
                if (!trackBinding.isOnNavMesh)
                    continue;

                trackBinding.SetDestination(input.destination.position);
                input.destinationSet = true;
            }
        }
    }
}
