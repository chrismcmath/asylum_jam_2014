using UnityEngine;
using System.Collections;

public class DarknessController : MonoBehaviour {
	public bool Active;
	public GameObject ParticlesPrefab;
	public Transform HomeTarget;
	public Transform BabyTarget;
	public NavMeshAgent Agent;
	public GameObject BabyWind;
	//public InputPickupController PickupCtrl;
	public BabyModel Baby;

	private ParticleSystem ps;
	private DarknessParticleAgent pAgent;
	private float AgentNormalSpeed;
	private float AgentBackSpeed;
	public bool restarted;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		//ps.GetComponent<ParticleSystem>();
		AgentNormalSpeed = Agent.speed;
		AgentBackSpeed = Agent.speed *3;
		GameObject clone;
		clone = Instantiate(ParticlesPrefab, transform.position, Quaternion.identity) as GameObject;
		pAgent = clone.GetComponent<DarknessParticleAgent>();
		clone.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Active)
			return;


		if (Baby.State == BabyModel.BabyState.HELD) {
			Agent.SetDestination(HomeTarget.position);
			if(!BabyWind.activeSelf) BabyWind.SetActive(true);
			if(restarted) {

				pAgent.enabled = true; // just turn it on, script handles the rest
				//ps.gameObject.transform.parent = null;
				restarted = false;
				//ps.Simulate(0.0f,false,true);
			}
			Agent.speed = AgentBackSpeed;
		} else {
			Agent.SetDestination(BabyTarget.position);
			if(BabyWind.activeSelf) BabyWind.SetActive(false);
			if(!restarted) {
				//print ("cfdefdedfefvd");
				//ps.Simulate(0.0f,false,true);
				//ps.Play();
				GameObject clone;
				clone = Instantiate(ParticlesPrefab, transform.position, Quaternion.identity) as GameObject;
				pAgent = clone.GetComponent<DarknessParticleAgent>();
				clone.transform.parent = transform;
				restarted = true;

			}
			Agent.speed = AgentNormalSpeed;
		}
	}
}
