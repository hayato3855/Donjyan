using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecastEffectView : MonoBehaviour
{
    [SerializeField] Image m_RecastTimeMask;

    public IEnumerator Recast(float time)
    {
        float value = 1;
        float speed = Time.deltaTime / time;
        while (value >= 0)
        {
            yield return new WaitWhile(() => MatchState.s_IsBattle);
            value -= speed;
            m_RecastTimeMask.fillAmount = value;
            yield return null;
        }
        yield return true;
    }
}
