using UnityEngine;

namespace Donjyan
{
    [CreateAssetMenu(fileName = "UnitParameters", menuName = "Donjyan/Unit/Parameters")]
    public class UnitParameters : ScriptableObject
    {
        [SerializeField] float  m_Speed;
        [SerializeField] float  m_RecastTime;
        public float GetSpeed()         { return m_Speed; }
        public float GetRecastTime()    { return m_RecastTime; }
    }
}