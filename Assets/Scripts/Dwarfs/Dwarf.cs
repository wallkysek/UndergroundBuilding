
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Dwarf : Unit, IF_CanDestroy, IF_Actor, IPointerDownHandler, IF_CanHarvest, IF_CanSleep {

    private delegate void ActionHandler();
    private ActionHandler ActionsToDo;
    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    private WalkingRestrictions WalkRest;
    private Rigidbody Rigid;

    [SerializeField]
    private float ActionRange = 0.6f;
    [SerializeField]
    private float Speed = 0.01f;
    [SerializeField]
    private Vector3 MovingToPosition;
    [SerializeField]
    private int dwarfId;
    [SerializeField]
    private string dwarfName;
    private float dwarfEnergy;
    [SerializeField]
    private float maxDwarfEnergy;
    [SerializeField]
    private DwarfPanel dwarfPanel;

    private Animator AnimController;

    private bool Moving = false;
    private bool OnGround = false;

    [SerializeField]
    private float upperEnergyTime;
    [SerializeField]
    private float energyDecaySpeed;

    [SerializeField] private float GroundDistance = 0.1f;

    public MessagePanel msgPanel;

    private IF_Target target;
    

    public void Destroy(IF_Destroyable target) {
        ActionsToDo = target.Destroy;
        IF_Target tar = (IF_Target)target;
        MovingToPosition = tar.GetTargetPosition();
    }

    public void Update() {
        if (this.WalkRest.AvaiDirec.Contains(WalkingRestrictions.Directions.TOP) && !OnGround)
        {
            Rigid.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation |
            RigidbodyConstraints.FreezePositionY;;
        }
        else
        {
            Rigid.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
        }
        
        
        if (Vector3.Distance(this.transform.position, this.MovingToPosition) > ActionRange) {
            Vector3 Direction = Vector3.MoveTowards(this.transform.position,
                MovingToPosition, Speed * Time.deltaTime);
            Direction.z = 0;
            this.transform.position = Direction;
            Moving = true;
        } else {
            if (ActionsToDo != null) {
                try
                {
                    ActionsToDo();
                }
                catch
                {
                    msgPanel.DisplayMessage("Action is not possible");
                }
                ActionsToDo = null;
            }
            Moving = false;
        }
        dwarfEnergy -= energyDecaySpeed * Time.deltaTime;
            if (dwarfPanel.GetDwarfId() == this.dwarfId)
                dwarfPanel.RefreshEnergyBar(dwarfEnergy);
            if (dwarfEnergy < 0)
            {
                msgPanel.DisplayMessage(this.dwarfName + " died horribly because of exhaustion");
                Destroy(this.gameObject);
            }
        OnGround = IsGrounded();
        this.AnimController.SetBool("Moving", Moving);
        if (this.transform.position.x > this.MovingToPosition.x)
        {
            this.AnimController.SetBool("MovingLeft", false);
        }
        else
        {
            this.AnimController.SetBool("MovingLeft", true);
        }
        if (OnGround && !Moving)
        {
            this.AnimController.SetInteger("State", 0);
        }
        if (OnGround && Moving)
        {
            this.AnimController.SetInteger("State", 1);
        }
        
        if (!OnGround)
        {
            this.AnimController.SetInteger("State", 2);
        }

    }

    private bool IsGrounded()
    {
        return Physics.Raycast(gameObject.transform.position, -Vector3.up, GroundDistance);
    }

    public List<Actions.Action> GetActions() {
        return this.Actions;
    }



    void Start() {
        this.MovingToPosition = this.gameObject.transform.position;
        this.WalkRest = this.GetComponent<WalkingRestrictions>();
        this.Rigid = this.GetComponent<Rigidbody>();
        this.AnimController = this.GetComponent<Animator>();
        this.enabled = true;
        dwarfEnergy = maxDwarfEnergy;
        upperEnergyTime = Time.time;
        if (dwarfPanel == null)
        {
            dwarfPanel = GameObject.Find("DwarfPanel").GetComponent<DwarfPanel>();
        }
        if (msgPanel == null)
        {
            msgPanel = GameObject.Find("MessagePanel").GetComponent<MessagePanel>();
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (ClickModeManager.GetInstance().Mode == ClickModeManager.SelectMode.SELECT_ACTOR) {
            dwarfPanel.SetPanel(this.dwarfName, this.dwarfEnergy, this.dwarfId);
            msgPanel.DisplayMessage("Dwarf selected!");
        }
        ClickModeManager.GetInstance().ClickedOnGO(this.gameObject);
    }

    public void SetPosition(Vector3 pos) {
        MovingToPosition = pos;
    }


    public void Harvest(IF_Harvestable what)
    {
        ActionsToDo = what.Harvest;
        IF_Target tar = (IF_Target)what;
        MovingToPosition = tar.GetTargetPosition();
    }

    public void GoSleep(IF_SleepTarget where)
    {
        ActionsToDo = this.GetSleepConsumed;
        target = (IF_Target)where;
        MovingToPosition = target.GetTargetPosition();
    }

    public void GetSleepConsumed()
    {
        IF_SleepTarget tar = (IF_SleepTarget) target;
        tar.ConsumeSleeping(this);
    }

    public void Refresh()
    {
        dwarfEnergy = maxDwarfEnergy;
    }
}
