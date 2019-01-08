using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class WalkToMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        int inputCount = playable.GetInputCount ();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<WalkToBehaviour> inputPlayable = (ScriptPlayable<WalkToBehaviour>)playable.GetInput(i);
            WalkToBehaviour input = inputPlayable.GetBehaviour ();

            // Use the above variables to process each frame of this playable.
            if (inputWeight > 0.5f && !input.destinationSet && input.destination) {
                if (!input.meshAgent.isOnNavMesh)
                    continue;

                Debug.Log(input.meshAgent);
                input.meshAgent.SetDestination(input.destination.position);
                input.destinationSet = true;
                
            }
        }
    }
}
