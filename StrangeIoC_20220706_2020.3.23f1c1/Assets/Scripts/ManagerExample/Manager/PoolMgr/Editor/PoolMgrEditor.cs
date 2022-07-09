/****************************************************
    文件：PoolMgr.cs
	作者：lenovo
    邮箱: 
    日期：2022/7/9 13:7:16
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;
 
namespace Demo02
{
    public class PoolMgrEditor : MonoBehaviour
    {
        #region 字段


        #endregion

        #region 生命

        //放在文件夹Editor下
        [MenuItem("Manager/CreateGameObjectPoolCfg")]
        static void CreateGameObjectPoolLst()
        { 
            GameObjectPoolLst lst = ScriptableObject.CreateInstance<GameObjectPoolLst>();
            AssetDatabase.CreateAsset(lst, AssetDatabase.GenerateUniqueAssetPath(PathDefine.GameObjectPoolCfg));
            AssetDatabase.SaveAssets();
        }
        void Start()
        {
            
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