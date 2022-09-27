using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Donjyan
{
    public class UnitGeneratorView : MonoBehaviour
    {
        [SerializeField] Button m_PowerButton;
        [SerializeField] Button m_SpeedButton;
        [SerializeField] Button m_BalanceButton;

        public Button PowerButton { get { return m_PowerButton; } }
        public Button SpeedButton { get { return m_SpeedButton; } }
        public Button BalanceButton { get { return m_BalanceButton; } }

        public UnityEvent PowerEvent    { get; set; } = new UnityEvent();
        public UnityEvent SpeedEvent    { get; set; } = new UnityEvent();
        public UnityEvent BalanceEvent   { get; set; } = new UnityEvent();


        void Awake()
        {
            m_BalanceButton.onClick.AddListener(() => BalanceEvent.Invoke());
            m_SpeedButton.onClick.AddListener(() => SpeedEvent.Invoke());
            m_PowerButton.onClick.AddListener(() => PowerEvent.Invoke());
        }

        public void ChangeButtonInteractable(Button button, bool isInteractable)
        {
            button.interactable = isInteractable;
        }
    }
}