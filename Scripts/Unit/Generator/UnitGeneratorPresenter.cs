using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Donjyan
{
    public class UnitGeneratorPresenter : MonoBehaviour
    {
        [SerializeField] UnitGeneratorModel m_UnitGeneratorModel;
        [SerializeField] UnitGeneratorView  m_UnitGeneratorView;

        void Start()
        {
            m_UnitGeneratorView.BalanceEvent.AddListener(() =>
            {
                m_UnitGeneratorView.ChangeButtonInteractable(m_UnitGeneratorView.BalanceButton, false);
                m_UnitGeneratorModel.Spawn(UnitGeneratorModel.Team.My, UnitGeneratorModel.Unit.Balance);
                StartCoroutine(FinishRecast(m_UnitGeneratorView.BalanceButton));
            });

            m_UnitGeneratorView.SpeedEvent.AddListener(() =>
            {
                m_UnitGeneratorView.ChangeButtonInteractable(m_UnitGeneratorView.SpeedButton, false);
                m_UnitGeneratorModel.Spawn(UnitGeneratorModel.Team.My, UnitGeneratorModel.Unit.Speed);
                StartCoroutine(FinishRecast(m_UnitGeneratorView.SpeedButton));
            });

            m_UnitGeneratorView.PowerEvent.AddListener(() =>
            {
                m_UnitGeneratorView.ChangeButtonInteractable(m_UnitGeneratorView.PowerButton, false);
                m_UnitGeneratorModel.Spawn(UnitGeneratorModel.Team.My, UnitGeneratorModel.Unit.Power);
                StartCoroutine(FinishRecast(m_UnitGeneratorView.PowerButton));
            });
        }

        IEnumerator FinishRecast(Button button)
        {
            IEnumerator corution = button.GetComponent<RecastEffectView>().Recast(m_UnitGeneratorModel.GetRecastTime());
            yield return corution;
            m_UnitGeneratorView.ChangeButtonInteractable(button, (bool)corution.Current);
        }
    }
}