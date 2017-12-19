using World.WorldUtils;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace World {
    namespace WorldTiles {
        public class WorldTile : Tile, IF_Target, IF_Destroyable, IPointerDownHandler{
            [SerializeField]
            private GameObject resource;

            public void Destroy() {
                Debug.Log("pridan kamen");
                resource = Instantiate(resource);
                resource.transform.position = gameObject.transform.position;
                GameObject.Destroy(gameObject);
            }

            public Vector3 GetTargetPosition() {
                return gameObject.transform.position;
            }

            public void OnPointerDown(PointerEventData eventData) {
                ClickModeManager.GetInstance().ClickedOnGO(this.gameObject);
            }

            override protected GameObject getTileForInstantiate() {
                return StaticWorldObjects.getInitWorldTile();
            }


            /*void OnMouseDown() {
                if (!EventSystem.current.IsPointerOverGameObject())
                    if (EventSystem.current.currentSelectedGameObject != null) {
                        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
                    }
                    ClickModeManager.GetInstance().ClickedOnGO(this.gameObject);
            }*/
        }
    }
}