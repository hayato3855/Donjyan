using System.Collections;
using UnityEngine;
using System;

namespace Donjyan
{

    public class EnemyGenerator : MonoBehaviour
    {
        [SerializeField] UnitGeneratorModel m_UnitGeneratorModel;

        [SerializeField] bool m_IsDebug;

        bool[] m_CanGeneration;

        float m_DelayTime = 1.0f;
        float m_CountTime = 0;

        void Start()
        {
            m_CanGeneration = new bool[m_UnitGeneratorModel.GetEnemyCount()];
            for(int i = 0; i < m_UnitGeneratorModel.GetEnemyCount(); i++)
            {
                m_CanGeneration[i] = true;
            }
        }

        void Update()
        {
            if (MatchState.s_IsMatch)
            {
                if(m_IsDebug)
                {
                    return;
                }
                GeneratorLottery();
            }
        }

        void GeneratorLottery()
        {
            if(MatchState.s_IsBattle)
            {
                return;
            }

            m_CountTime += Time.deltaTime;

            if(m_CountTime < m_DelayTime)
            {
                return;
            }

            m_CountTime = 0;

            for(int i = 0; i < m_UnitGeneratorModel.GetEnemyCount(); i++)
            {
                if(Calculation.Probability(30.0f))
                {
                    Generator(i);
                }
            }
        }

        void Generator (int unitNum)
        {
            if(!m_CanGeneration[unitNum])
            {
                return;
            }

            UnitGeneratorModel.Unit unit = (UnitGeneratorModel.Unit)Enum.ToObject(typeof(UnitGeneratorModel.Unit), unitNum);
            m_UnitGeneratorModel.Spawn(UnitGeneratorModel.Team.Enemy, unit);
            StartCoroutine(Recast(m_UnitGeneratorModel.GetRecastTime(), unitNum));
        }

        IEnumerator Recast(float time,int unitNum)
        {
            m_CanGeneration[unitNum] = false;
            yield return new WaitForSeconds(time);
            m_CanGeneration[unitNum] = true;
        }
    }
}