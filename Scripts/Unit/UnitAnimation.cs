using System.Collections;
using UnityEngine;

namespace Donjyan
{
    public class UnitAnimation : MonoBehaviour
    {
        const float WALK_ANIMATION_SPEED = 0.3f;
        [SerializeField] Sprite[] m_WalkSprites;

        SpriteRenderer m_UniteSprite;

        void Awake()
        {
            m_UniteSprite = GetComponent<SpriteRenderer>();
        }

        IEnumerator LoopWalk()
        {
            while(true)
            {
                for(int i = 0; i < m_WalkSprites.Length; i++)
                {
                    yield return new WaitUntil(() => MatchState.s_IsMatch);
                    yield return new WaitWhile(() => MatchState.s_IsBattle);
                    yield return new WaitForSeconds(WALK_ANIMATION_SPEED);
                    m_UniteSprite.sprite = m_WalkSprites[i];
                }
            }
        }

        void OnEnable()
        {
            StartCoroutine(LoopWalk());
        }

    }
}