using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour {

    public GameObject HumanPrefab;
    public int NumberOfHumans;
    public GameObject InfectionPrefab;
    public int NumberofInfections;
    public Vector3 center;
    public Vector3 size;

	// Use this for initialization
	void Start () {
        Spawns();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawns()
    {
        for(int i = 0; i < NumberOfHumans; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(HumanPrefab, pos, Quaternion.identity);
        }
        for (int i = 0; i < NumberofInfections; i++)
        {
            Vector3 pos2 = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(InfectionPrefab, pos2, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center, size);
    }
}
