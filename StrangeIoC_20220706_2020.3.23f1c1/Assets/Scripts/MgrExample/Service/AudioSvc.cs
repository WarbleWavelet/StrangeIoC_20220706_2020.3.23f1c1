/****************************************************
    文件：AudioMgr.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/9 10:20:18
	功能：声音播放服务
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
namespace Framework
{
    public class AudioSvc : MonoBehaviour
    {
        public static AudioSvc Instance = null;
        public AudioSource bgAudio;
        public AudioSource uiAudio;

        public void InitSvc()
        {
            Instance = this;
            Debug.Log("AudioSvc Init...");
        }


        #region BG
        public void StopBGMusic()
        {
            if (bgAudio != null)
            {
                bgAudio.Stop();
            }
        }


        public void PlayBGMusic(string name, bool isLoop = true)
        {
            AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
            if (bgAudio.clip == null || bgAudio.clip.name != audio.name)
            {
                bgAudio.clip = audio;
                bgAudio.loop = isLoop;
                bgAudio.Play();
            }
        }
        #endregion


        public void PlayUIAudio(string name)
        {
            AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
            uiAudio.clip = audio;
            uiAudio.Play();
        }

        /// <summary>
        /// 播放角色身上的AudioSource
        /// </summary>
        /// <param name="name"></param>
        /// <param name="audioSrc"></param>
        public void PlayCharAudio(string name, AudioSource audioSrc)
        {
            AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
            audioSrc.clip = audio;
            audioSrc.Play();
        }

        /// <summary>
        /// 在某个位置播放音效
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        public void PlayPosAudio(string name, Vector3 position)
        {
            AudioClip clip = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
            AudioSource.PlayClipAtPoint( clip, position);
        }
    }
}

