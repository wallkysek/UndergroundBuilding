using World.WorldUtils;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.AI;

namespace World {
    namespace WorldTiles {
        public class WorldTile : Tile, IF_Target, IF_Destroyable, IPointerDownHandler{
            [SerializeField]
            private GameObject resource;


            public void Destroy() {
                resource = Instantiate(resource);
                resource.transform.position = gameObject.transform.position;
                base.DestroyTile();
            }

            public Vector3 GetTargetPosition() {
                return gameObject.transform.position;
            }

            public void OnPointerDown(PointerEventData eventData) {
                
                ClickModeManager.GetInstance().ClickedOnGO(this.gameObject);
                Debug.Log("Clicked on Tile");
            }

            override protected GameObject getTileForInstantiate() {
                return StaticWorldObjects.getInitWorldTile();
            }

            public void setResource(GameObject resource)
            {
                this.resource = resource;
            }
        }
    }
}