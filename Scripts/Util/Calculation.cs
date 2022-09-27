using UnityEngine;

public class Calculation
{
   public static bool Probability (float Percent)
   {
        float ProbabilityRate = Random.value * 100.0f;

        if(Percent == 100.0f)
        {
            return true;
        }
        else if(ProbabilityRate <= Percent)
        {
            return true;
        }
        else
        {
            return false;
        }
   }
}
