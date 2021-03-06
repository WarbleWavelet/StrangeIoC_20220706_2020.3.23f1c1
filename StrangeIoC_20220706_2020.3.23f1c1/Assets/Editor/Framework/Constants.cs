/****************************************************
    文件：Constants.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/8 14:16:7
	功能：常量配置
*****************************************************/


using UnityEngine;

namespace Extense
{
    public class Constants
    {
        public static string SavePath_Framework = Application.dataPath + "\\Editor\\Framework\\Resources\\audiolist.txt";
        public static string SavePath_Resources = Application.dataPath + "\\Resources\\ResText\\audiolist.txt";
        #region Audio
        public const string BGLogin = "bgLogin";
        /// <summary>进入主城的Bgm</summary>
        public const string BGMainCity = "bgMainCity";
        /// <summary>副本</summary>
        public const string InstanceHuangYe = "bgHuangYe";
        public const string InstanceWin = "fbwin";
        public const string InstanceLose = "fblose";
        //
        public const string UILoginBtn = "uiLoginBtn";
        public const string UIClickBtn = "uiClickBtn";
        public const string UIOpenPage = "uiOpenPage";
        /// <summary>点击侧边栏的Bgm</summary>
        public const string UIExtenBtn = "uiExtenBtn";
        /// <summary>强化</summary>
        public const string FBItemEnter = "fbitem";
        public const string AssassinHit = "assassin_Hit";
        #endregion



    }
}