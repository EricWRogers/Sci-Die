using SuperPupSystems.StateMachine;

[System.Serializable]
public class StageOne : SimpleState
{
    private int m_counter = 0;
    public override void OnStart()
    {
        base.OnStart();
    }

    public override void UpdateState(float _dt)
    {
        base.UpdateState(_dt);
        if (m_counter < 4)
        {
            ((BossStateMachine)stateMachine).RepeatMov(3);
            

        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
