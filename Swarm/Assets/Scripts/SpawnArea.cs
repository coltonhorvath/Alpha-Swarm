using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour {

    public GameObject HumanPrefab;
    float NumberOfHumans;
    public GameObject InfectionPrefab;
    float NumberofInfections;
    public Vector3 center;
    public Vector3 size;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Spawns();
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void Spawns()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < NumberOfHumans; i++)
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
    }

    public void AdjustHumans (float numHumans)
    {
        NumberOfHumans = numHumans;
    }
    public void AdjustInfections(float numInfections)
    {
        NumberofInfections = numInfections;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.2f);
        Gizmos.DrawCube(center, size);
    }
}
