/****************************************************
    文件：Test.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/9 10:52:26
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Demo02;
 
namespace Demo03
{
    public class Test : MonoBehaviour
    {
        #region 字段


        #endregion

        #region 生命
        void Start()
        {
            AudioSvc.Instance.PlayBGMusic(Constants.BGMainCity);
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