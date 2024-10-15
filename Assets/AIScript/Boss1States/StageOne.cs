using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;
using System;

[System.Serializable]
public class StageOne : SimpleState
{
    public Timer timer;
    public float attackOneTime;
    public override void OnStart()
    {
        base.OnStart();
        timer.StartTimer(attackOneTime, false);
    }

    public override void UpdateState(float _dt)
    {
        base.UpdateState(_dt);
        ((BossStateMachine)stateMachine).RepeatMov(3);
        if (timer.timeLeft <= 0)
        {
            ((BossStateMachine)stateMachine).CenterAttack();
            if(((BossStateMachine)stateMachine).gameObject.transform.rotation.z < 0)
            {
                ((BossStateMachine)stateMachine).currentPoint = ((BossStateMachine)stateMachine).points[((BossStateMachine)stateMachine).index].transform;
                timer.AddTime(attackOneTime);
            }
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
