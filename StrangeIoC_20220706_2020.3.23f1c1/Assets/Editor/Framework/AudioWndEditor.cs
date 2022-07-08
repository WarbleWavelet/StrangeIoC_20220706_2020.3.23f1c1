/****************************************************
    文件：AudioWndEditor.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/8 15:41:14
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;
 
namespace Framework
{
    public class AudioWndEditor : EditorWindow
    {
        #region 字段


        #endregion

        #region 生命
        [MenuItem("Framework/AudioWndEditor")]
        static void CreateAudioWnd()
        { 
            Rect rect=new Rect(0,0,500,500);//会记录上次位置
            AudioWndEditor editor= GetWindowWithRect( typeof(AudioWndEditor),rect) as AudioWndEditor;
        }

        #endregion 

        #region 系统

        #endregion 

        #region 辅助

        #endregion
    }
}