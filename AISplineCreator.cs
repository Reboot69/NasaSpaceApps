using UnityEngine;
using System.Collections;

public class AISplineCreator : MonoBehaviour {
	#region public
	public GameObject[] Spline; //holds the Spline Points
	#endregion

	#region Private
	[SerializeField] private float SplinePointSize;
	#endregion
	void OnDrawGizmos(){
		if (Spline.Length == transform.childCount) {
			for(int i = 0; i < Spline.Length; i++){
				Gizmos.DrawWireSphere (Spline [i].transform.position, SplinePointSize);
				if((i+1) != Spline.Length)
					Gizmos.DrawLine (Spline [i].transform.position, Spline [i + 1].transform.position);
			}
			return;
		}
		
		Spline = new GameObject[gameObject.transform.childCount];
		for(int i = 0; i < transform.childCount; i++){
			Spline [i] = transform.GetChild (i).gameObject;
		}
	}
}
