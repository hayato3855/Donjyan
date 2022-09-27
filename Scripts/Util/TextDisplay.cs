using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay
{
    static float s_Speed = 0.2f;

    public static IEnumerator Display(Text text, string comment)
    {
        for(int i = 1; i <= comment.Length; i++)
        {
            text.text = comment.Substring(0, i);
            yield return new WaitForSeconds(s_Speed);
        }
    }
}
