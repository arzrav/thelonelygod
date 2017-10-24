using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TreeSpawner{

	public static List<Vector3> SpawnTrees (float[,] heightMap, TerrainType[] regions, float heightMultiplier, AnimationCurve heightCurve, float woodiness) {
		int width = heightMap.GetLength (0);
		int height = heightMap.GetLength (1);
		int delta = (width - 1) * 5 - 5;
		List<Vector3> treeMap = new List<Vector3> ();

		for (int y = 0; y < height - 1; y++) {
			for (int x = 0; x < width - 1; x++) {
				float currentHeight = heightMap [x, y];
				for (int i = 0; i < regions.Length; i++) {
					if (i == 0) {
						if (currentHeight > 0 && currentHeight <= regions [i].height && regions [i].treeSpawnRate > 0 && Random.value <= regions [i].treeSpawnRate / woodiness) {
							treeMap.Add (new Vector3 ((x == 0) ? -delta : x * 10 - delta, heightCurve.Evaluate (heightMap [x, y]) * heightMultiplier * 10, (y == 0) ? delta : -(y * 10 - delta)));
							break;
						}
					} else {
						if (currentHeight > regions [i - 1].height && currentHeight <= regions [i].height && regions [i].treeSpawnRate > 0 && Random.value <= regions [i].treeSpawnRate / woodiness) {
							treeMap.Add (new Vector3 ((x == 0) ? -delta : x * 10 - delta, heightCurve.Evaluate (heightMap [x, y]) * heightMultiplier * 10, (y == 0) ? delta : -(y * 10 - delta)));
							break;
						}
					}
				}
			}
		}
		return treeMap;
	}
}