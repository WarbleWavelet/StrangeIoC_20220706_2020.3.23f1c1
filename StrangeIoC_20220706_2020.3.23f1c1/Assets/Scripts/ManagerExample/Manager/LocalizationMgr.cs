/****************************************************
    文件：LocalizationMgr.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/9 19:54:46
	功能：本地化（也就是翻译）
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
 
namespace Demo02
{
    public class LocalizationMgr:MonoBehaviour
    {
         Dictionary<string, Text> localizationDic=new Dictionary<string, Text>();
        #region 单例
        private static LocalizationMgr _instance;      

        public static LocalizationMgr Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LocalizationMgr();
                }
                return _instance;
            }
        }
        #endregion



        public void Init()
        {
            GameObject[] goArr = GameObject.FindGameObjectsWithTag(Tags.LocalizationText);
            foreach (GameObject go in goArr)
            {
                string key = go.GetComponent<LocalizationText>().key;
                Text value = go.GetComponent<Text>();
                localizationDic.Add(key, value);
            }

            foreach (var item in localizationDic)
            {
                item.Value.text = ResSvc.Instance.GetLocalization(item.Key);
            }
        }
    }
}