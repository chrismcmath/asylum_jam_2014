using UnityEngine;
using System.Collections;

// whenever we turn on this script, stop the particle emition and go back home

public class DarknessParticleAgent : MonoBehaviour {
	public Transform HomeTarget;
	public NavMeshAgent Agent;
	public ParticleSystem ps;
	private float AgentBackSpeed;
	
	void Awake(){
		
	}
	
	// Use this for initialization
	void Start () {
		Agent = GetComponent<NavMeshAgent>();
		Agent.enabled = true;
		HomeTarget = GameObject.Find("Darkness Start").transform;
		AgentBackSpeed = Agent.speed *2;
		transform.parent = null;
		ps.enableEmission = false;

		Destroy(gameObject, 25.0f);
	}
	
	// Update is called once per frame
	void Update () {
		Agent.SetDestination(HomeTarget.position);
		Agent.speed = AgentBackSpeed;
	}
}
