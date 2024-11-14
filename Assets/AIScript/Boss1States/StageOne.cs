using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;
using System;

[System.Serializable]
public class StageOne : SimpleState
{
    public override void OnStart()
    {
        base.OnStart();
        ((BossStateMachine)stateMachine).timer.StartTimer(((BossStateMachine)stateMachine).attackTime, false);
    }

    public override void UpdateState(float _dt)
    {
        base.UpdateState(_dt);
        ((BossStateMachine)stateMachine).RepeatMov(3);
        if (((BossStateMachine)stateMachine).timer.timeLeft <= 0)
        {
            ((BossStateMachine)stateMachine).CenterAttack();
        }
        if (((BossStateMachine)stateMachine).halfHealth)
        {

            ((BossStateMachine)stateMachine).ChangeState(nameof(StageTwo));
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
