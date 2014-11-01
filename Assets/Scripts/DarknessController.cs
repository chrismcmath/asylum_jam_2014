using UnityEngine;
using System.Collections;

public class DarknessController : MonoBehaviour {
	public bool Active;
	public Transform HomeTarget;
	public Transform BabyTarget;
	public NavMeshAgent Agent;
	public GameObject BabyWind;
	public InputPickupController PickupCtrl;

	public ParticleSystem ps;
	private float AgentNormalSpeed;
	private float AgentBackSpeed;

	void Awake(){
		ps.randomSeed = 1;
	}

	// Use this for initialization
	void Start () {
		//ps.GetComponent<ParticleSystem>();
		AgentNormalSpeed = Agent.speed;
		AgentBackSpeed = Agent.speed *2;
	}
	
	// Update is called once per frame
	void Update () {
		if (PickupCtrl.HoldingBaby) {
			Agent.SetDestination(HomeTarget.position);
		//	if(!BabyWind.activeSelf) BabyWind.SetActive(true);
			//if(ps.isPlaying) {
				//ps.Stop();
				//ps.Simulate(0.0f,false,true);
			//}
			Agent.speed = AgentBackSpeed;
		} else {
			Agent.SetDestination(BabyTarget.position);
		//	if(BabyWind.activeSelf) BabyWind.SetActive(false);
			if(ps.isStopped == true) {
				print ("cfdefdedfefvd");
				//ps.Simulate(0.0f,false,true);
				//ps.Play();

			}
			Agent.speed = AgentNormalSpeed;
		}
	}
}
