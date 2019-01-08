using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

/// <summary>
/// this class provided tools for calculation, comparation and other
/// math opreations. Use static method directly. 
/// </summary>
public class GraphicRecordingUtility {

    /// <summary>
    /// According to the speech label, the system will give different reactions.
    /// </summary>
    public enum SpeechLabel
    {
        GREETINGS,
        ARGUING,
        EXPLAINING,
        IDLE,
    }

    // list to store words 
    public List<string> wordsList = new List<string>();

    /// <summary>
    /// Default constructor can be only used by StoryManager. Using this to load script files.
    /// </summary>
    public GraphicRecordingUtility() {
        wordsList.Add("I shook hands with him.");

        wordsList.Add("I couldn't agree what he said about artificial intelligence");

        wordsList.Add("We talked a lot that day.");

        wordsList.Add("He told me something about his new findings.");
    }

    /// <summary>
    /// constructor can be used by any other Monobehaviour children classes.
    /// </summary>
    /// <param name="behaviour"> instance of the monobehaviour which is using the utility class. </param>
    public GraphicRecordingUtility(MonoBehaviour behaviour) {

    }

    /// <summary>
    /// Get the Speech label according to the text got from the recognizer.
    /// </summary>
    /// <param name="text"> text recognized by the recognizer </param>
    /// <returns> The label of the speech </returns>
    public SpeechLabel RequireSpeechLabel(string text) {
        ratios = new float[wordsList.Count];
        for (int i = 0; i < wordsList.Count; i++) {
            ratios[i] = EditDistance(text, wordsList[i]);
        }
        int minIndex = Array.IndexOf(ratios, ratios.Min());

        switch (minIndex) {
            case 0:
                Debug.Log("GREETINGS");
                return SpeechLabel.GREETINGS;
            case 1:
                Debug.Log("ARGUING");
                return SpeechLabel.ARGUING;
            case 2:
                Debug.Log("EXPLAINING");
                return SpeechLabel.EXPLAINING;
            default:
                Debug.Log("IDLE");
                return SpeechLabel.IDLE;
        }
    }

    private static float[] ratios;
    private static float ratio = 0.0f;
    /// <summary>
    /// Method to get the edit distance between two text sentence, the lower the ratio,
    /// the smaller the distance is.
    /// </summary>
    /// <param name="original"> The first sentence </param>
    /// <param name="modified"> The second sentence </param>
    /// <returns> edit distance between two strings </returns>
    public float EditDistance(string original, string modified)
    {
        int len_orig = original.Length;
        int len_diff = modified.Length;

        var matrix = new int[len_orig + 1, len_diff + 1];
        for (int i = 0; i <= len_orig; i++)
            matrix[i, 0] = i;
        for (int j = 0; j <= len_diff; j++)
            matrix[0, j] = j;

        for (int i = 1; i <= len_orig; i++)
        {
            for (int j = 1; j <= len_diff; j++)
            {
                int cost = modified[j - 1] == original[i - 1] ? 0 : 1;
                var vals = new int[] {
                matrix[i - 1, j] + 1,
                matrix[i, j - 1] + 1,
                matrix[i - 1, j - 1] + cost
            };
                matrix[i, j] = vals.Min();
                if (i > 1 && j > 1 && original[i - 1] == modified[j - 2] && original[i - 2] == modified[j - 1])
                    matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
            }
        }
        if (len_orig != 0)
            ratio = (float)matrix[len_orig, len_diff] / len_orig;
        return ratio;
    }
}
