public abstract class State
{
    protected readonly PlayerCombat combat;

    protected State(PlayerCombat combat) => this.combat = combat;

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
