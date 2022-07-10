using UnityEngine;
using System.Collections;


namespace FSM
{
    public class PatrolState : FSMState {

        #region 字段 属性 构造
        private int targetWaypoint;
        private Transform[] waypoints;
        private GameObject npc;
        private Rigidbody npcRd;
        private GameObject player;
        public PatrolState(Transform[] wp, GameObject enemy,GameObject player)
        {
            stateID = StateID.Patrol;
            waypoints = wp;
            targetWaypoint = 0;
            this.npc = enemy;
            npcRd = enemy.GetComponent<Rigidbody>();
            this.player = player;
        }
        #endregion


        public override void Enter()
        {
            Debug.Log("Entering state " + ID);
        }

        public override void Process()
        {
            CheckTransition();
            PatrolMove();

        }
        //检查转换条件
        private void CheckTransition()
        {
            if (Vector3.Distance(player.transform.position, npc.transform.position) < 5)
            {
                fsm.PerformTransition(Transition.SawPlayer);
            }
        }
        private void PatrolMove()
        {
            npcRd.velocity = npc.transform.forward * 3;
            Transform targetTrans = waypoints[targetWaypoint];
            Vector3 targetPosition = targetTrans.position;
            targetPosition.y = npc.transform.position.y;
            npc.transform.LookAt(targetPosition);
            if (Vector3.Distance(npc.transform.position, targetPosition) < 1)
            {
                targetWaypoint++;
                targetWaypoint %= waypoints.Length;
            }
        }
    }
}
