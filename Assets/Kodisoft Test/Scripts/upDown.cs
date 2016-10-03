using UnityEngine;
using System.Collections;

public class upDown : MonoBehaviour 
{ 
		Color[] colors = new Color[6];

		void Start()
		{
			colors[0] = Color.blue;
			colors[1] = Color.red;
			colors[2] = Color.green;
		    colors[3] = Color.white;
			colors[4] = Color.yellow;
			colors[5] = Color.red;

		gameObject.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
		}
}