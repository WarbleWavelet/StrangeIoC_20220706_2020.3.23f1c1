using UnityEngine;
using System.Collections;
using ProtoBuf;
using System.IO;
using UnityEditor;
using UnityEngine.UI;

namespace Protobuf
{
    public class TestProtobuf : MonoBehaviour
    {
        public Button btnSaveType1;
        public Button btnSaveType2;
        public Button btnRead;
        public Text txtShow;

        // Use this for initialization
        void Start()
        {

            User user = new User();
            user.ID = 100;
            user.Username = "siki";
            user.Password = "123456";
            user.Level = 100;
            user._UserType = User.UserType.Master;
            //
            btnSaveType1 = transform.Find("Canvas/btnSaveType1").GetComponent<Button>();
            btnSaveType2 = transform.Find("Canvas/btnSaveType2").GetComponent<Button>();
            btnRead = transform.Find("Canvas/btnRead").GetComponent<Button>();
            txtShow = transform.Find("Canvas/txtShow").GetComponent<Text>();
            //
            btnSaveType1.onClick.AddListener(() => { Save01(user, PathDefine.UserData); });
            btnSaveType1.onClick.AddListener(() => { Save02(user, PathDefine.UserData); });
            btnRead.onClick.AddListener(() => { Read(PathDefine.UserData); });


        }


        /// <summary>
        /// 手动关闭文件流
        /// </summary>
        /// <param name="user"></param>
        /// <param name="path"></param>
        private void Save01(User user,string path)
        {
            FileStream fs = File.Create(path);
            txtShow.text=("保存路径_" + path);
            Serializer.Serialize<User>(fs, user);
            fs.Close();
            AssetDatabase.Refresh();//刷新文件夹
        }

        /// <summary>
        /// 系统关闭文件流
        /// </summary>
        /// <param name="user"></param>
        /// <param name="path"></param>
        private void Save02(User user, string path)
        {
            using (var fs = File.Create(path))
            {
                Serializer.Serialize<User>(fs, user);
            }
            txtShow.text = ("保存路径_" + path);
            AssetDatabase.Refresh();//刷新文件夹
        }

        private void Read(string path)
        {
            User user = null;

            using (var fs = File.OpenRead(path))
            {
                user = Serializer.Deserialize<User>(fs);
            }
            txtShow.text ="";
            txtShow.text+="\n"+user.ID;
            txtShow.text+="\n"+user._UserType;
            txtShow.text+="\n"+user.Username;
            txtShow.text+="\n"+user.Password;
            txtShow.text+="\n"+user.Level;
        }
    }
    public class PathDefine
    {
        public static string UserData = Application.dataPath + "/Resources/ResBin/user.bin";
    }

}

