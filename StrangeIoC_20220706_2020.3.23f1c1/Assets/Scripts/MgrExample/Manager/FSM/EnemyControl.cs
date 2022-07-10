using UnityEngine;
using System.Collections;


namespace FSM
{
    public class EnemyControl : MonoBehaviour
    {

        private FSMSys fsm;
        private GameObject to;
        private GameObject from;
        public Transform[] waypoints;



        #region 生命
        // Use this for initialization
        void Start()
        {
            from = this.gameObject;
            to = GameObject.FindGameObjectWithTag(Tags.Player);
            //
            GameObject[] goArr = GameObject.FindGameObjectsWithTag(Tags.WayPoint);
            waypoints=new Transform[goArr.Length];
            for (int i = 0; i < goArr.Length ; i++)
            {
                GameObject go;
                for (int j = 0; j < goArr.Length; j++)
                {
                    
                    if (goArr[j].name.Equals(i.ToString()))
                    {
                        
                       go= goArr[j];
                        waypoints[i] = go.transform;
                        break;
                    }
                }
                 
            }
            //
            InitFSM();
        }

        void Update()
        {
            fsm.CurState.Process();
        }
        #endregion



        /// <summary>
        /// 初始化状态机
        /// </summary>
        void InitFSM()
        {
            fsm = new FSMSys();
            
            PatrolState patrolState = new PatrolState(waypoints, from, to);
            patrolState.AddTransition(Transition.SawPlayer, StateID.Chase);

            ChaseState chaseState = new ChaseState(from, to);
            chaseState.AddTransition(Transition.LostPlayer, StateID.Patrol);

            fsm.AddState(patrolState);
            fsm.AddState(chaseState);

            fsm.Start(StateID.Patrol);
        }
    }
}
