using UnityEngine;

namespace Donjyan
{
    public class UnitStatus : MonoBehaviour
    {
        [SerializeField] UnitParameters m_UnitParameters;

        public float GetUnitSpeed()         { return m_UnitParameters.GetSpeed(); }
        public float GetUnitRecastTime()    { return m_UnitParameters.GetRecastTime(); }
        
    }
}
