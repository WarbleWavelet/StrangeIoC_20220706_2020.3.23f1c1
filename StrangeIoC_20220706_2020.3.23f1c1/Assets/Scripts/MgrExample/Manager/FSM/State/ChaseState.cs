using UnityEngine;
using System.Collections;


namespace FSM
{
public class ChaseState : FSMState {

    private GameObject from;
    private Rigidbody fromRgb;
    private GameObject to;
    public ChaseState(GameObject npc,GameObject player)
    {
        stateID = StateID.Chase;
        this.from = npc;
        fromRgb = npc.GetComponent<Rigidbody>();
        this.to = player;
    }
    public override void Enter()
    {
        Debug.Log("Entering state " + ID);
    }

    public override void Process()
    {
        CheckTransition();
        ChaseMove();
    }
    private void CheckTransition()
    {
        if (Vector3.Distance(to.transform.position, from.transform.position) >10)
        {
            fsm.PerformTransition(Transition.LostPlayer);
        }
    }

    private void ChaseMove()
    {
        fromRgb.velocity = from.transform.forward * 5;
        Vector3 toPos = to.transform.position;
        toPos.y = from.transform.position.y;
        from.transform.LookAt(toPos);
    }
}

}
