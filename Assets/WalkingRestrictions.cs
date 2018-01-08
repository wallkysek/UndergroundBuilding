using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World;

public class WalkingRestrictions : MonoBehaviour {
	public enum Directions{
		TOP, BOTTOM, LEFT, RIGHT
	}

	public List<Directions> AvaiDirec = new List<Directions>();
	[SerializeField]
	private GameObject Target;
	
	// Update is called once per frame
	void Update ()
	{
		AvaiDirec.Clear();
		World.WorldUtils.CoordinatePair TarPos = World.WorldUtils.CoordinatePair.Init(
			(int) Math.Round(Target.transform.position.x), (int) Math.Floor(-Target.transform.position.y));
		if (StaticWorldObjects.WorldStructureTiles.ContainsKey(TarPos) && StaticWorldObjects.WorldStructureTiles[TarPos].IsDestroyed == false)
		{
			AvaiDirec.Add(Directions.TOP);
			AvaiDirec.Add(Directions.BOTTOM);
			AvaiDirec.Add(Directions.LEFT);
			AvaiDirec.Add(Directions.RIGHT);
			return;
		}
		TarPos.Y++;
		TarPos.X--;
		if (StaticWorldObjects.WorldTiles.ContainsKey(TarPos) && StaticWorldObjects.WorldTiles[TarPos].IsDestroyed == false)
		{
			AvaiDirec.Add(Directions.LEFT);
		}
		TarPos.X+=2;
		if (StaticWorldObjects.WorldTiles.ContainsKey(TarPos) && StaticWorldObjects.WorldTiles[TarPos].IsDestroyed == false)
		{
			AvaiDirec.Add(Directions.RIGHT);
		}
	}
}

