using World.WorldUtils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace World {
    namespace WorldTiles {
        public class StructureTile : Tile, IF_Target, IF_Destroyable, IPointerDownHandler{
            override protected GameObject getTileForInstantiate() {
                return StaticWorldObjects.getInitStructureTile();
            }
            public void Destroy() {
                base.DestroyTile();
            }

            public Vector3 GetTargetPosition()
            {
                return gameObject.transform.position;
            }

            public void OnPointerDown(PointerEventData eventData)
            {
                ClickModeManager.GetInstance().ClickedOnGO(this.gameObject);
            }
        }
    }
}