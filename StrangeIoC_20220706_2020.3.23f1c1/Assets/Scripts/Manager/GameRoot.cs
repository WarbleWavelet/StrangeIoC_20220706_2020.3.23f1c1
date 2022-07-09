/****************************************************
    文件：GaeRoot.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/9 10:55:25
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
namespace Demo02
{
    public class GameRoot : MonoBehaviour
    {
        #region 字段
        AudioSvc audioSvc;
        ResSvc resSvc;

        #endregion

        #region 生命
        void Start()
        {
            audioSvc=GetComponent<AudioSvc>();
            resSvc=GetComponent<ResSvc>();
            //
            resSvc.InitSvc();
            audioSvc.InitSvc();

        }
        
        void Update()
        {
            
        }
        #endregion 

        #region 系统

        #endregion 

        #region 辅助

        #endregion
    }
}