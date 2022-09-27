using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Donjyan
{
    public class BattleModel
    {
        /// <summary>
        /// ����񂯂�̏��s
        /// �s�͎����̎�
        /// ��͑���̎�
        /// ��� 0���O�[�A1���`���L�A2���p�[
        /// ���ʂ� -1�������A0�����������A1������
        /// </summary>
        int[,] m_Result = new int[,]
        {
            { 0, 1, -1 },
            { -1, 0, 1 },
            { 1, -1, 0 }
        };

        public UnityEvent BattleStartEvent = new UnityEvent();
        public UnityEvent BattleWinEvent = new UnityEvent();
        public UnityEvent BattleDrawEvent = new UnityEvent();
        public UnityEvent BattleLoseEvent = new UnityEvent();
        public UnityEvent<int, int> SelectHandEvent = new UnityEvent<int, int>();

        public void BattleStart()
        {
            BattleStartEvent.Invoke();
            MatchState.s_IsBattle = true;
        }

        public void BatteleEnd()
        {
            MatchState.s_IsBattle = false;
        }

        public IEnumerator SelectHand(int handNum)
        {
            int enemyHandNum = Random.Range(0, 3);
            SelectHandEvent.Invoke(handNum, enemyHandNum);
            
            yield return new WaitWhile(() => BattleAnimaStatus.GetIsPlaying());

            Result(GetResult(handNum,enemyHandNum));
        }

        void Result(int resutNum)
        {
            switch (resutNum)
            {
                case -1:
                    BattleLoseEvent.Invoke();
                    break;
                case 0:
                    BattleDrawEvent.Invoke();
                    break;
                case 1:
                    BattleWinEvent.Invoke();
                    break;
            }
        }

        int GetResult(int myHand, int enemyHand)
        {
            return m_Result[myHand, enemyHand];
        }
    }
}