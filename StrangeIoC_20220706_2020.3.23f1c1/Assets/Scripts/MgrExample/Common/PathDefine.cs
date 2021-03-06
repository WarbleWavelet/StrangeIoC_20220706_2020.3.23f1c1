/****************************************************
    文件：PathDefine.cs
	作者：lenovo
    邮箱: 
    日期：2022/4/29 17:3:33
	功能：路径配置
*****************************************************/

using UnityEngine;


namespace Framework
{ 
public class PathDefine
{

        #region Localization本地化
        public const string Localization_Chinese = "ResLocalization/Chinese";
        public const string Localization_English = "ResLocalization/English";
        #endregion


        public const string Res_GameObjectPoolCfg = "ResCfgs/gameobjectpool";
        public const string Res_SavePath_Audio = "ResText/audiolist";

        // public static string GameObjectPoolCfg = Application.dataPath + "/Resources/ResCfgs/gameobjectpool.property";
        public static string GameObjectPoolCfg = "Assets/Resources/ResCfgs/gameobjectpool.asset";

        //
        public static string SavePath_Framework = Application.dataPath + "\\Editor\\Framework\\Resources\\audiolist.txt";
        public static string SavePath_Resources1 = Application.dataPath + "\\Resources\\ResText\\audiolist.txt";
        public static string SavePath_Resources = Application.dataPath + "/Resources/ResText/audiolist.txt";
        public static string SavePath1 = "ResText\\audiolist.txt";
        public static string Path = "audiolist.txt";
        #region Cfg    

        //
        public const string RDNameCfg = "ResCfgs/rdname";
    public const string MapCfg = "ResCfgs/map";
    public const string MapCfg_V1 = "ResCfgs/map_v1";
    public const string GuideCfg = "ResCfgs/guide";
    public const string StrongCfg = "ResCfgs/strong";
    public const string TaskRewardCfg = "ResCfgs/taskreward";
    public const string SkillCfg = "ResCfgs/skill";
    public const string SkillMoveCfg = "ResCfgs/skillmove";
    public const string SkillActionCfg = "ResCfgs/skillaction";
    public const string MonsterCfg = "ResCfgs/monster";

    #endregion

    #region AutoGuide
    public const string TaskHead = "ResImages/task";
    public const string WiseManHead = "ResImages/wiseman";
    public const string GeneralHead = "ResImages/general";
    public const string ArtisanHead = "ResImages/artisan";
    public const string TraderHead = "ResImages/trader";
    //
    public const string SelfIcon = "ResImages/assassin";
    public const string GuideIcon = "ResImages/npcguide";
    public const string WiseManIcon = "ResImages/npc0";
    public const string GeneralIcon = "ResImages/npc1";
    public const string ArtisanIcon = "ResImages/npc2";
    public const string TraderIcon = "ResImages/npc3";
    #endregion

    public const string AssassinCityPlayerPrefab = "PrefabPlayer/AssassinCity";
    public const string AssassinBattlePlayerPrefab = "PrefabPlayer/AssassinBattle";


    #region 强化页
    /// <summary>强化部位被点击时</summary>
    public const string ItemArrorBG = "ResImages/btnstrong";
    public const string ItemPlatBG = "ResImages/charbg3";
    public const string ItemHead = "ResImages/toukui";
    public const string ItemBody = "ResImages/body";
    public const string ItemWaist = "ResImages/yaobu";
    public const string ItemHands = "ResImages/hand";
    public const string ItemLeg = "ResImages/leg";
    public const string ItemFeet = "ResImages/foot";
    public const string SpStarFull = "ResImages/star1";
    public const string SpStarNull = "ResImages/star2";
    #endregion


    #region MainCity
    public const string BtnTypeSelect = "ResImages/btntype1";  
    public const string BtnTypeUnselect = "ResImages/btntype2";
    #endregion



    #region 任务
    public const string TaskDailySprite = "ResImages/dailytask";
    public const string TaskAutoSprite = "ResImages/autotask";
    public const string TaskSprite = "ResImages/task";
    public const string TaskItemPrefab = "PrefabUI/ItemTaskPrefab";
    public const string TaskPrizeImg = "ResImages/box2";
    public const string TaskPrizeGrayImg = "ResImages/box1";

    #endregion


    #region UI
    public const string ItemEntityHp = "PrefabUI/ItemEntityHp";
    #endregion


}
}
