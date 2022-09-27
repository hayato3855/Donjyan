using UnityEngine;

namespace Donjyan
{
    public class PagerPresenter : MonoBehaviour
    {
        [SerializeField] PagerView m_PagerView;

        PagerModel m_PagerModel = new PagerModel();

        void Start()
        {
            m_PagerView.NextEvent.AddListener(() => m_PagerModel.ViewNextPage(m_PagerView.GetTutorialItems,ref m_PagerView.NowPage));
            m_PagerView.FrontEvent.AddListener(() => m_PagerModel.ViewFrontPage(m_PagerView.GetTutorialItems,ref m_PagerView.NowPage));
            m_PagerView.CloseEvent.AddListener(() => m_PagerModel.CloseTutorial());
        }
    }
}
