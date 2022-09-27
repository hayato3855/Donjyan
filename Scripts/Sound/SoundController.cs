using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjyan
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] AudioSource m_BGMSource;
        [SerializeField] AudioSource m_SESource;

        [SerializeField] AudioClip[] m_BGMClips;
        [SerializeField] AudioClip[] m_SEClips;

        public void PlayBGM(int clipNum)
        {
            m_BGMSource.clip = m_BGMClips[clipNum];
            m_BGMSource.loop = true;
            m_BGMSource.Play();
        }

        public void PlaySE(int clipNum)
        {
            m_SESource.clip = m_SEClips[clipNum];
            m_SESource.loop = false;
            m_SESource.Play();
        }

        public void StopBGM()
        {
            m_BGMSource.Stop();
        }

        public void StopSE()
        {
            m_SESource.Stop();
        }
        
    }
}