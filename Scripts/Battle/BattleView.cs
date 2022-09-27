using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

namespace Donjyan
{
    public class BattleView : MonoBehaviour
    {
        static readonly string s_FirstComment = "じゃんけんぽん！";
        static readonly string s_NextComment = "あいこでしょ！";
        static readonly string s_AgainComment = "もういっかい！";

        static readonly float s_AgainDelayTime = 1.5f;

        [SerializeField] Button m_RockButton;
        [SerializeField] Button m_ScissorsButton;
        [SerializeField] Button m_PaperButton;

        [SerializeField] GameObject m_UnitUI;
        [SerializeField] GameObject m_BattleUI;
        [SerializeField] GameObject m_BattleResultUI;
        [SerializeField] GameObject m_BattleHandUI;

        [SerializeField] Text m_BattleText;

        [SerializeField] Image m_MyHandImage;
        [SerializeField] Image m_EnemyHandImage;

        [SerializeField] Sprite[] m_HandSprites = new Sprite[3];

        int m_TextDisplayCount = 0;

        [HideInInspector] public UnityEvent RockEvent = new UnityEvent();
        [HideInInspector] public UnityEvent ScissorsEvent = new UnityEvent();
        [HideInInspector] public UnityEvent PaperEvent = new UnityEvent();

        void Start()
        {
            m_RockButton.onClick.AddListener(() => RockEvent.Invoke());
            m_ScissorsButton.onClick.AddListener(() => ScissorsEvent.Invoke());
            m_PaperButton.onClick.AddListener(() => PaperEvent.Invoke());
        }

        IEnumerator DisplayBattleText()
        {
            string comment;
            comment = m_TextDisplayCount++ == 0 ? s_FirstComment : s_NextComment;
            yield return StartCoroutine(TextDisplay.Display(m_BattleText, comment));
        }

        public void SwitchingUI()
        {
            m_UnitUI.SetActive(!m_UnitUI.activeSelf);
            m_BattleUI.SetActive(!m_BattleUI.activeSelf);
        }

        public void DisplayHandUI(bool display)
        {
            m_BattleHandUI.SetActive(display);
        }

        public IEnumerator DisplayBattleUI()
        {
            yield return StartCoroutine(DisplayBattleText());
            DisplayHandUI(true);
        }

        public void HideEnemyUnit()
        {
            MatchState.s_EnemyBattleUnit.SetActive(false);
            MatchState.s_EnemyBattleUnit = null;
        }

        public void HideMyUnit()
        {
            MatchState.s_MyBattleUnit.SetActive(false);
            MatchState.s_MyBattleUnit = null;
        }

        public IEnumerator DisplayBattleResultControll(int handNum, int enemyHandNum)
        {
            m_MyHandImage.sprite = m_HandSprites[handNum];
            m_EnemyHandImage.sprite = m_HandSprites[enemyHandNum];
            m_BattleResultUI.SetActive(true);
            m_BattleHandUI.SetActive(false);

            yield return new WaitWhile(() => BattleAnimaStatus.GetIsPlaying());
            m_BattleResultUI.SetActive(false);
        }

        public IEnumerator DisplayAgain()
        {
            yield return StartCoroutine(TextDisplay.Display(m_BattleText, s_AgainComment));
            yield return new WaitForSeconds(s_AgainDelayTime);
            m_TextDisplayCount = 0;
            StartCoroutine(DisplayBattleUI());
        }

        public void Init()
        {
            m_TextDisplayCount = 0;
            m_UnitUI.SetActive(true);
            m_BattleUI.SetActive(false);
        }
    }
}
