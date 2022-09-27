using UnityEngine;

namespace Donjyan
{
    public class BattlePresenter : MonoBehaviour
    {
        BattleModel m_BattleModel = new BattleModel();

        [SerializeField] BattleView m_BattleView;

        void Start()
        {
            SetBattleStartEvent();
            SetSelectHandEvent();
            SetBattleWinEvent();
            SetBattleDrawEvent();
            SetBattleLoseEvent();
            SetRockEvent();
            SetScissorsEvent();
            SetPaperEvent();
        }

        void Update()
        {
            if (MatchState.s_HasEnemyContact)
            {
                MatchState.s_HasEnemyContact = false;
                m_BattleModel.BattleStart();
            }
        }

        void SetBattleStartEvent()
        {
            m_BattleModel.BattleStartEvent.AddListener(() =>
            {
                m_BattleView.SwitchingUI();
                StartCoroutine(m_BattleView.DisplayBattleUI());
            });
        }

        void SetSelectHandEvent()
        {
            m_BattleModel.SelectHandEvent.AddListener((myHand, enemyHand) => StartCoroutine(m_BattleView.DisplayBattleResultControll(myHand, enemyHand)));
        }


        void SetBattleWinEvent()
        {
            m_BattleModel.BattleWinEvent.AddListener(() =>
            {
                if (MatchState.s_EnemyAgain)
                {
                    StartCoroutine(m_BattleView.DisplayAgain());
                    MatchState.s_EnemyAgain = false;
                    return;
                }
                m_BattleView.HideEnemyUnit();
                m_BattleView.Init();
                m_BattleModel.BatteleEnd();
            });
        }

        void SetBattleDrawEvent()
        {
            m_BattleModel.BattleDrawEvent.AddListener(() => StartCoroutine(m_BattleView.DisplayBattleUI()));
        }

        void SetBattleLoseEvent()
        {
            m_BattleModel.BattleLoseEvent.AddListener(() => 
            {
                if (MatchState.s_MyAgain)
                {
                    StartCoroutine(m_BattleView.DisplayAgain());
                    MatchState.s_MyAgain = false;
                    return;
                }
                m_BattleView.HideMyUnit();
                m_BattleView.Init();
                m_BattleModel.BatteleEnd();
            });
        }

        void SetRockEvent()
        {
            m_BattleView.RockEvent.AddListener(() => StartCoroutine(m_BattleModel.SelectHand(0)));
        }

        void SetScissorsEvent()
        {
            m_BattleView.ScissorsEvent.AddListener(() => StartCoroutine( m_BattleModel.SelectHand(1)));
        }

        void SetPaperEvent()
        {
            m_BattleView.PaperEvent.AddListener(() => StartCoroutine(m_BattleModel.SelectHand(2)));
        }
    }
}
