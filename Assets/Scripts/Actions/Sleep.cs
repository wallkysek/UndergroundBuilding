

public class Sleep : Actions.Action {
    public override void Do(object actor, object target) {
        if (!(actor is IF_CanSleep)) {
            throw new ActionException("This unit doesn't know how to sleep");
        }
        if (!(target is IF_SleepTarget)) {
            throw new ActionException("Sleeping is not possible here");
        }
        ((IF_CanSleep)actor).GoSleep((IF_SleepTarget)target);
    }
}
