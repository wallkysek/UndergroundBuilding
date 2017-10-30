public interface IPickable<T>{
    void PickUp(T owner);
    void PutDown();
}

public interface IUsable {
    void Use();
}

public interface IConsumable {
    void Eat(IUsable what);
    void Destroy();
}

public interface IStorable {
    void Store();
}

public interface IWearable {
    void Wear();
}

public interface IHarvestable {
    void Harvest();
}

public interface IOwnable<T> {
    void SetOwner(T owner);
    T GetOwner();
    void RemoveOwner();
}
