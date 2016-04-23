using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour {
	public GameObject ION;
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			Rigidbody rb = gameObject.AddComponent<Rigidbody> ();
			rb.mass = 0.5f;
			StartCoroutine (Timer ());

		}
	}

	IEnumerator Timer(){
		yield return new WaitForSeconds (1);
		ION.SetActive (true);
	}
}
