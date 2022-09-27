using UnityEngine;

namespace Donjyan
{
    public class AnimationStatus : MonoBehaviour
    {
        [SerializeField] string m_AnimationName;

        bool m_IsPlaying = false;

        Animator m_Animator;

        void Start()
        {
            m_Animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName(m_AnimationName))
            {
                if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
                {
                    return;
                }

                m_IsPlaying = false;
            }
        }

        public bool GetPlaying()
        {
            return m_IsPlaying;
        }

        private void OnEnable()
        {
            m_IsPlaying = true;
        }
    }
}