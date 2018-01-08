using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Structure_Inn : Structure, IF_SleepTarget, IPointerDownHandler, IF_Target
{
    [SerializeField]
    private float SleepingInterval;
    [SerializeField]
    private float NewInterval;

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickModeManager.GetInstance().ClickedOnGO(this.gameObject);
    }

    [SerializeField] private GameObject NewDwarf;
    
    private Dictionary<GameObject, float> Sleeping = new Dictionary<GameObject, float>();
    private float LastNew = 0f;
    
    
    public void ConsumeSleeping(IF_CanSleep who)
    {
        who.GetGameObject().SetActive(false);
        who.Refresh();
        Sleeping.Add(who.GetGameObject(), Time.time);
    }


    private void FixedUpdate()
    {
        List<GameObject> keys = new List<GameObject>(Sleeping.Keys);
        foreach (var Sleeper in keys)
        {
            if ((Sleeping[Sleeper] + SleepingInterval) <= Time.time)
            {
                Debug.Log("Zacal: " + Sleeping[Sleeper] + " +interval: " + (Sleeping[Sleeper] + SleepingInterval) 
                          +" Probuzen: " + Time.time);
                Sleeper.SetActive(true);
                Sleeping.Remove(Sleeper);
            }
        }
        if (Sleeping.Count >= 2 && ((LastNew + NewInterval) < Time.time))
        {
            TryCreateNew();
        }
    }

    private void TryCreateNew()
    {
        int rnd = Random.Range(1, Sleeping.Count + 1);
        if (rnd > 1)
        {
            MessagePanel.getInstance().DisplayMessage("New dwarf was born!");
            Instantiate(NewDwarf);
            LastNew = Time.time;
        }
            
    }

    public Vector3 GetTargetPosition()
    {
        return this.gameObject.transform.position;
    }
}
