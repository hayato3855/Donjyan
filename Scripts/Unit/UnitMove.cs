using System.Collections;
using UnityEngine;

namespace Donjyan
{
    public class UnitMove : MonoBehaviour
    {

        UnitStatus m_UnitStatus;

        enum StartPos
        {
            Right,
            Left            
        }
        [SerializeField] StartPos m_StartPos = StartPos.Right;

        void Awake()
        {
            m_UnitStatus = GetComponent<UnitStatus>();
        }

        IEnumerator Move()
        {
            float moveValue = m_UnitStatus.GetUnitSpeed();
            if(m_StartPos == StartPos.Right)
            {
                moveValue *= -1;
            }

            float speed = 0;

            while(true)
            {
                yield return new WaitUntil(() => MatchState.s_IsMatch);
                yield return new WaitWhile(() => MatchState.s_IsBattle);
                speed = moveValue * Time.deltaTime;
                transform.position += new Vector3(speed,0, 0);
                yield return null;
            }
        }

        void OnEnable()
        {
            StartCoroutine(Move());
        }
    }
}