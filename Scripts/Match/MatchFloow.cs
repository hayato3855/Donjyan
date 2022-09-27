using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Donjyan
{
    public class MatchFloow : MonoBehaviour
    {
        static readonly float s_ResultDisplayDelayTime = 1.5f;

        [SerializeField] GameObject m_MatchStartUI;
        [SerializeField] GameObject m_UnitUI;
        [SerializeField] GameObject m_MatchEndUI;
        [SerializeField] GameObject m_MatchWinUI;
        [SerializeField] GameObject m_MatchLoseUI;
        [SerializeField] GameObject m_MatchEndButton;

        [SerializeField] Button m_RestartButton;
        [SerializeField] Button m_TitleButton;

        [SerializeField] AnimationStatus m_MatchStartAnimation;
        [SerializeField] AnimationStatus m_MatchEndAnimation;

        [SerializeField] SoundController m_SoundController;
        [SerializeField] SceneChanger m_SceneChanger;

        float m_MatchEndButtonDisplayTime = 2.5f;

        void Start()
        {
            m_RestartButton.onClick.AddListener(() => StartCoroutine(m_SceneChanger.Change(SceneChanger.SceneName.Donjan_Main)));
            m_TitleButton.onClick.AddListener(() => StartCoroutine(m_SceneChanger.Change(SceneChanger.SceneName.Donjan_Title)));
            StartCoroutine(DisplayMatchStartUI());
        }

        void MatchStart()
        {
            m_SoundController.PlayBGM(1);
            MatchState.s_IsMatch = true;
            m_MatchStartUI.SetActive(false);
            m_UnitUI.SetActive(true);
        }

        IEnumerator DisplayMatchStartUI()
        {
            m_SoundController.PlayBGM(0);
            yield return new WaitUntil (() => MatchState.s_HasTutorial);
            m_SoundController.StopBGM();
            m_SoundController.PlaySE(0);
            m_MatchStartUI.SetActive(true);
            yield return new WaitWhile(() => m_MatchStartAnimation.GetPlaying());
            MatchStart();
        }

        public IEnumerator MatchEnd()
        {
            m_SoundController.StopBGM();
            m_SoundController.PlaySE(1);
            m_MatchEndUI.SetActive(true);
            MatchState.s_IsMatch = false;
            yield return new WaitWhile(() => m_MatchEndAnimation.GetPlaying());
            yield return new WaitForSeconds(s_ResultDisplayDelayTime);
            m_MatchEndUI.SetActive(false);
            m_UnitUI.SetActive(false);

            Animator animator;

            switch(MatchState.s_WinnerTeam)
            {
                case MatchState.WinnerTeam.My:
                    m_SoundController.PlaySE(2);
                    m_MatchWinUI.SetActive(true);
                    animator = m_MatchWinUI.GetComponent<Animator>();
                    break;
                case MatchState.WinnerTeam.Enemy:
                    m_SoundController.PlaySE(3);
                    m_MatchLoseUI.SetActive(true);
                    animator = m_MatchLoseUI.GetComponent<Animator>();
                    break;
            }

            yield return new WaitForSeconds(m_MatchEndButtonDisplayTime);
            m_MatchEndButton.SetActive(true);

        }
       
    }
}