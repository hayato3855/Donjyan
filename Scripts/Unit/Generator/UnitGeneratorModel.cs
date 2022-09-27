using UnityEngine;
using System.Collections.Generic;

namespace Donjyan
{
    public class UnitGeneratorModel : MonoBehaviour
    {
        [SerializeField] GameObject[] m_MyUnits;
        [SerializeField] GameObject[] m_EnemyUnits;

        [SerializeField] Transform m_MyTeamTran;
        [SerializeField] Transform m_EnemyTeamTran;

        float m_RecastTime;

        public enum Team
        {
            My,
            Enemy
        }

        public enum Unit
        {
            Power,
            Speed,
            Balance
        }

        void Awake()
        {
            InitGeneration(m_MyUnits, MatchState.s_GanarateMyUnits);
            InitGeneration(m_EnemyUnits, MatchState.s_GanarateEnemyUnits);
        }

        void InitGeneration(GameObject[] units, GameObject[,] generateUnits)
        {
            for (int i = 0; i < units.Length; i++)
            {
                for (int j = 0; j < generateUnits.GetLength(1); j++)
                {
                    GameObject unit = Instantiate(units[i]);
                    unit.SetActive(false);
                    generateUnits[i,j] = unit;
                }
            }
        }

        GameObject GetUnit(GameObject[,] generateUnits,Unit selectUnit)
        {
            GameObject unit = null;

            int unitNum = (int)selectUnit;

            for (int i = 0; i < generateUnits.GetLength(1); i++)
            {
                if (!generateUnits[unitNum, i].activeSelf)
                {
                    unit = generateUnits[unitNum, i];
                    break;
                }
            }

            if(unit == null)
            {
                Debug.LogError("Žæ“¾‘ÎÛ‚Ìƒ†ƒjƒbƒg‚ª‘¶Ý‚µ‚Ü‚¹‚ñ");
            }

            return unit;
        }

        public void Spawn(Team team, Unit selectUnit)
        {
            Vector3 pos = team == Team.My ? m_MyTeamTran.position : m_EnemyTeamTran.position;
            GameObject[,] generateUnits = team == Team.My ? MatchState.s_GanarateMyUnits : MatchState.s_GanarateEnemyUnits;
            GameObject unit = GetUnit(generateUnits, selectUnit);

            unit.transform.position = pos;
            unit.SetActive(true);

            m_RecastTime = unit.GetComponent<UnitStatus>().GetUnitRecastTime();
        }

        public float GetRecastTime(){ return m_RecastTime; }
        public int GetEnemyCount(){ return m_EnemyUnits.Length; }
    }
}
