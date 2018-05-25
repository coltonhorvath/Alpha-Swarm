using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InfectionController : MonoBehaviour {

    public float searchRadius = 20f;
    [SerializeField]
    Transform huntedTarget;
    NavMeshAgent agent;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }

	// Use this for initialization
	void Start ()
    {
        agent = this.GetComponent<NavMeshAgent>();
	}

    public Transform Target;
	// Update is called once per frame
	void Update () {

        Hunt();
        
        /*if (Vector3.Distance(Target.position, this.transform.position) < 20)
        {
            Vector3 huntTarget = huntedTarget.transform.position;
            agent.SetDestination(huntTarget);
            //Vector3 direction = Target.position - this.transform.position;
        }*/

	}

    private void Hunt()
    {
        if (Vector3.Distance(Target.position, this.transform.position) < 20)
        {
            Vector3 huntTarget = GameObject.FindWithTag("Human").transform.position;
            agent.SetDestination(huntTarget);
            Vector3 direction = GameObject.FindWithTag("Human").transform.position - this.transform.position;
        }
    }
}
