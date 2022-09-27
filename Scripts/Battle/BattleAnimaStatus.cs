using UnityEngine;

namespace Donjyan
{
    public class BattleAnimaStatus : MonoBehaviour
    {
        static string s_AnimationName = "DisplayMyHand";

        static bool s_IsPlaying = true;

        Animator m_Animator;

        void Awake()
        {
            m_Animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName(s_AnimationName))
            {
                if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
                {
                    return;
                }

                s_IsPlaying = false;
            }
        }

        void OnEnable()
        {
            s_IsPlaying = true;
        }

        public static bool GetIsPlaying()
        {
            return s_IsPlaying;
        }
    }
}