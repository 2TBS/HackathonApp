using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntries : MonoBehaviour {

	public SQLAccess server;
	public GameObject itemPrefab;
	public Transform container;

	public int offset = 0;
	public const int OFFSET_STEP = 20;

	// Use this for initialization
	void Start () {
		server = GetComponent<SQLAccess>();
		server.Initialize();
		Debug.Log(server.items.Length);
		for(int i = 0; i < server.items.Length; i++) {
			GameObject currItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity ) as GameObject;
			currItem.transform.SetParent(container);
			currItem.transform.localPosition += new Vector3(0, offset, 0);
			Debug.Log("spawn " + i);
			offset += OFFSET_STEP;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
