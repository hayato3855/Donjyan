using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Donjyan
{
    public class PagerView : MonoBehaviour
    {
        [SerializeField] GameObject[] m_TutorialItems;

        [SerializeField] GameObject m_Tutorial;

        [SerializeField] Text m_PageText;

        [SerializeField] Button m_NextButton;
        [SerializeField] Button m_FrontButton;
        [SerializeField] Button m_CloseButton;

        [HideInInspector] public int NowPage = 1;

        [HideInInspector] public UnityEvent NextEvent;
        [HideInInspector] public UnityEvent FrontEvent;
        [HideInInspector] public UnityEvent CloseEvent;

        public GameObject[] GetTutorialItems{ get {return m_TutorialItems;}}

        void Start()
        {
            if(MatchState.s_HasTutorial)
            {
                m_Tutorial.SetActive(false);
            }

            m_NextButton.onClick.AddListener(() => {
                NextEvent.Invoke();
                CheckButtonInteracable();
                DisplayPage();
            });

            m_FrontButton.onClick.AddListener(() => {
                FrontEvent.Invoke();
                CheckButtonInteracable();
                DisplayPage();
            });

            m_CloseButton.onClick.AddListener(()=> {
                Close();
                CloseEvent.Invoke();
            });
        }

        void DisplayPage()
        {
            m_PageText.text = NowPage + "/" + m_TutorialItems.Length;
        }

        void Close()
        {
            m_Tutorial.SetActive(false);
        }

        void CheckButtonInteracable()
        {
            int firstPageNum = 1;

            m_NextButton.interactable = NowPage == m_TutorialItems.Length ? false : true;
            m_FrontButton.interactable = NowPage == firstPageNum ? false : true;
        }
    }
}

