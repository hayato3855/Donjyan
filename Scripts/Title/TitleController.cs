using UnityEngine;
using UnityEngine.UI;

namespace Donjyan
{
    public class TitleController : MonoBehaviour
    {
        [SerializeField] SceneChanger m_SceneChanger;

        [SerializeField] Button m_StartButton;


        void Awake()
        {
            m_StartButton.onClick.AddListener(() => StartCoroutine(m_SceneChanger.Change(SceneChanger.SceneName.Donjan_Main)));
        }
    }
}