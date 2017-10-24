using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour {

	public Renderer textureRender;
	public MeshFilter meshFilter;
	public MeshRenderer meshRenderer;

	public GameObject[] treePrefab;
	public GameObject[] rockPrefab;

	public void DrawTexture(Texture2D texture) {
		textureRender.sharedMaterial.mainTexture = texture;
		textureRender.transform.localScale = new Vector3 (texture.width, 1, texture.height);
	}

	public void DrawMesh(MeshData meshData, Texture2D texture) {
		meshFilter.sharedMesh = meshData.CreateMesh ();
		meshRenderer.sharedMaterial.mainTexture = texture;
	}

	public void ClearObjects() {
		foreach (Transform child in transform) {
			GameObject.DestroyImmediate (child.gameObject);
		}
	}

	public void SpawnTree(List<Vector3> treeMap) {
		foreach (var item in treeMap) {
			GameObject newTree = (GameObject)Instantiate (treePrefab[Random.Range (0, treePrefab.Length)], item, Quaternion.Euler (Vector3.up * Random.Range (0, 360)));
			newTree.transform.localScale += new Vector3 (10.0f, 10.0f, 10.0f);
			newTree.transform.parent = transform;
		}
	}

	public void SpawnRock(List<Vector3> rockMap) {
		foreach (var item in rockMap) {
			GameObject newRock = (GameObject)Instantiate (rockPrefab[Random.Range (0, rockPrefab.Length)], item, Quaternion.Euler (Vector3.up * Random.Range (0, 360)));
			newRock.transform.localScale += new Vector3 (10.0f, 10.0f, 10.0f);
			newRock.transform.parent = transform;
		}
	}
}
