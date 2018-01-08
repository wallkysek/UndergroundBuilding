using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IF_CanSleep
{
    void GoSleep(IF_SleepTarget where);
    GameObject GetGameObject();
    void GetSleepConsumed();
    void Refresh();
}
