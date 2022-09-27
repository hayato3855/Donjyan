using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Donjyan
{
    public class SceneChanger : MonoBehaviour
    {
        readonly float m_FadeTime = 1.5f;

        [SerializeField] Image m_FadePanel;

        public enum SceneName
        {
            Donjan_Title,
            Donjan_Main
        }

        IEnumerator FadeOut()
        {
            m_FadePanel.gameObject.SetActive(true);

            float time = 0;
            float fade = 0;

            float fadeValue = 0;

            // フェードパネルの初期化
            m_FadePanel.fillAmount = 0;

            while (time < m_FadeTime)
            {
                time += Time.deltaTime;
                fadeValue = 1 / m_FadeTime * Time.deltaTime;

                fade += fadeValue;

                m_FadePanel.fillAmount = fade;
                yield return null;
            }
        }

        public IEnumerator Change(SceneName sceneName)
        {
            yield return StartCoroutine(FadeOut());
            SceneManager.LoadScene(sceneName.ToString());
        }
    }
}