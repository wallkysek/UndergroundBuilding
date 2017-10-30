using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.WorldTiles;
using World.WorldUtils;


namespace World {
    public class StaticWorldObjects : MonoBehaviour {
        //Edited Dictionaries
        static public Dictionary<CoordinatePair, WorldTile> WorldTiles = new Dictionary<CoordinatePair, WorldTile>();
        static public Dictionary<CoordinatePair, StructureTile> WorldStructureTiles = new Dictionary<CoordinatePair, StructureTile>();
        static public Dictionary<CoordinatePair, WorldBackgroundTile> WorldBackgroundTiles = new Dictionary<CoordinatePair, WorldBackgroundTile>();

        [SerializeField]
        private GameObject sInitWorldTile;
        [SerializeField]
        private GameObject sInitStructureTile;
        [SerializeField]
        private GameObject sInitBackgroundTile;

        private static GameObject initWorldTile;
        private static GameObject initStructureTile;
        private static GameObject initBackgroundTile;

        static public GameObject getInitBackgroundTile() {
            return initBackgroundTile;
        }
        static public GameObject getInitStructureTile() {
            return initStructureTile;
        }
        static public GameObject getInitWorldTile() {
            return initWorldTile;
        }

        public void Awake() {
            initWorldTile = sInitWorldTile;
            initStructureTile = sInitStructureTile;
            initBackgroundTile = sInitBackgroundTile;
            this.enabled = false;
        }
    }


}