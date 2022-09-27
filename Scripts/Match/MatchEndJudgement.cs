using UnityEngine;

namespace Donjyan
{
    public class MatchEndJudgement : MonoBehaviour
    {
        [SerializeField]
        enum Team
        {
            My,
            Enemy
        };

        [SerializeField] Team m_Team = Team.My;

        [SerializeField] MatchFloow m_MatchFloow;

        void MatchEnd(MatchState.WinnerTeam winnerTeam)
        {
            MatchState.s_WinnerTeam = winnerTeam;
            StartCoroutine(m_MatchFloow.MatchEnd());
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (m_Team == Team.Enemy && collision.tag == TagNameManager.s_MyTagName)
            {
                MatchEnd(MatchState.WinnerTeam.My);
            }
            else if (m_Team == Team.My && collision.tag == TagNameManager.s_EnemyTagName)
            {
                MatchEnd(MatchState.WinnerTeam.Enemy);
            }
        }
    }
}