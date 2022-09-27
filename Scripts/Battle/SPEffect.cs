using UnityEngine;

namespace Donjyan
{
    public class SPEffect : MonoBehaviour
    {
        enum Team
        {
            My,
            Enemy
        }

        [SerializeField] Team m_Team = Team.My;

        bool m_Once = false;

        public void Effect()
        {
            if (!m_Once)
            {
                _ = m_Team == Team.My ? MatchState.s_MyAgain = true : MatchState.s_EnemyAgain = true;
                m_Once = true;
            }
        }

        private void OnEnable()
        {
            m_Once = false;
        }
    }
}