using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.WorldUtils;

public class SelectableTile : MonoBehaviour {

    public void OnMouseDrag() {
        CoordinatePair coordinates = this.transform.parent.GetComponent<TileParent>().GetParent().GetCoordinates();
        if (TileActionsOnSelected.Selected.Contains(coordinates))
            return;
        TileActionsOnSelected.Selected.Add(coordinates);
        Debug.Log("Dragged");
    }

}
