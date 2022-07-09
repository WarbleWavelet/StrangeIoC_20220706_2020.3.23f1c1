/****************************************************
    文件：DelayUnActive.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/9 13:44:0
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 
namespace Demo02
{
    public class DelayInactive : MonoBehaviour
    {
        #region 字段


        #endregion

        #region 生命
        void Start()
        {
            Invoke("DelayInactiveSelf", 3);
        }
        
        void Update()
        {
            
        }
        #endregion 

        #region 系统

        #endregion 

        #region 辅助
        void DelayInactiveSelf()
        {
            this.gameObject.SetActive(false);
        }
        #endregion
    }
}