using UnityEngine;

namespace Donjyan
{
    public class BattleJudgement : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == TagNameManager.s_EnemyTagName)
            {
                MatchState.s_HasEnemyContact = true;
                MatchState.s_EnemyBattleUnit = collision.gameObject;
                MatchState.s_MyBattleUnit = gameObject;

                SPEffectCheck(gameObject);
                SPEffectCheck(collision.gameObject);
            }
        }

        void SPEffectCheck(GameObject Obj)
        {
            SPEffect SPEffect = Obj.GetComponent<SPEffect>();

            if (SPEffect != null)
            {
                SPEffect.Effect();
            }
        }
    }
}