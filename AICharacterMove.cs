using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AICharacterMove : MonoBehaviour {
	#region Private
	[SerializeField] private GameObject[] BodyParts;
	[SerializeField] private GameObject player;
	[SerializeField] private AISplineCreator[] Spline;
	[SerializeField] private AISplineCreator SelectedSpline;

	[SerializeField] private float TargetChangeDistace;
	[SerializeField] private int CurrentDestinationIndex;
	[SerializeField] private float MaxDistanceFromPlayer;
	#endregion
	// Use this for initialization
	void Awake () {
		GetBodyParts ();
		SelectedSpline = null;
		SelectedSpline = Spline [Random.Range (0, Spline.Length)];
	}

	void Update(){
		EnableDisableBodyParts ();
	}

	void OnEnable(){
		GetDestination ();
	}

	public void GetDestination(){
		NavMeshAgent AIAgent = gameObject.GetComponent < NavMeshAgent> ();
		//GameObject Target = SelectedSpline.Spline [CurrentDestinationIndex];
		float Distance = Vector3.Distance (AIAgent.gameObject.transform.position, SelectedSpline.Spline [CurrentDestinationIndex].transform.position);
		if (Distance < TargetChangeDistace)
			CurrentDestinationIndex++;

		if (CurrentDestinationIndex == SelectedSpline.Spline.Length)
			CurrentDestinationIndex = 0;

		AIAgent.SetDestination(SelectedSpline.Spline [CurrentDestinationIndex].transform.position);
	}

	public void GetBodyParts(){
		BodyParts = new GameObject[transform.childCount];
		for(int i = 0; i < BodyParts.Length; i++){
			if (transform.GetChild (i).gameObject.tag == "Bone")
				continue;
			
			BodyParts [i] = transform.GetChild (i).gameObject;
		}
	}

	public void EnableDisableBodyParts(){
		if(Vector3.Distance(player.transform.position , gameObject.transform.position) > MaxDistanceFromPlayer)
		{
			foreach(GameObject go in BodyParts){
				if (go != null)
					go.SetActive (false);
			}
		}
		else
		{
			foreach(GameObject go in BodyParts){
				if (go != null)
					go.SetActive (true);
			}
		}
	}
}
