using UnityEngine;
using System.Collections;

public class AIManager : MonoBehaviour {
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject[] AI_Man_Dynamic; //holds the AI
	[SerializeField] private GameObject AI_Root_Dynamic; //holds all the Ai characters
	[SerializeField] private AICharacterMove m_AiCharacterMove;
	[SerializeField] private float MaxDisableDistance = 70;
	private bool started;

	// Use this for initialization
	void Start () {
		AI_Man_Dynamic = new GameObject[AI_Root_Dynamic.transform.childCount];
		for(int i = 0; i < AI_Root_Dynamic.transform.childCount; i++){
			AI_Man_Dynamic [i] = AI_Root_Dynamic.transform.GetChild (i).gameObject;
		}//Gets all the Gameobject from the AI Root Dynamic to the AI Manager Dynamic
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!started)
			StartCoroutine (GetAIUpdated ());

		for(int i = 0 ; i < AI_Man_Dynamic.Length; i++)
		{
			if (Vector3.Distance (player.transform.position, AI_Man_Dynamic [i].transform.position) > MaxDisableDistance)
				AI_Man_Dynamic [i].SetActive (false);
			else
				AI_Man_Dynamic [i].SetActive (true);
		}
	}

	IEnumerator GetAIUpdated(){
		started = true;
		for(int i = 0; i < AI_Man_Dynamic.Length; i++){
			AI_FixedUpdate (AI_Man_Dynamic [i]);
		}

		for(int i = 0; i < AI_Man_Dynamic.Length; i++){
			AI_FixedUpdate (AI_Man_Dynamic [i]);
			yield return new WaitForSeconds(0.5f);
			if (i == AI_Man_Dynamic.Length - 1) {
				i = -1;
			}
		}
	}

	void AI_FixedUpdate(GameObject AI){
		if (!AI.activeSelf)
			return;
		
		m_AiCharacterMove = AI.GetComponent<AICharacterMove> ();
		m_AiCharacterMove.GetDestination ();
	}
}
