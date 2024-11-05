using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;
using System;

[System.Serializable]
public class StageTwo : SimpleState
{
    public override void OnStart()
    {
        base.OnStart();
    }

    public override void UpdateState(float _dt)
    {
        base.UpdateState(_dt);
        if (((BossStateMachine)stateMachine).centerAttacking)
        {
            ((BossStateMachine)stateMachine).Lasers.SetActive(true);
        }
        else
        {
            ((BossStateMachine)stateMachine).Lasers.SetActive(false);
        }
        ((BossStateMachine)stateMachine).RepeatMov(3);
        if (((BossStateMachine)stateMachine).timer.timeLeft <= 0)
        {
            ((BossStateMachine)stateMachine).CenterAttack();
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
