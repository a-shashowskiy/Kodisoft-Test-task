using UnityEngine;
using System.Collections;

public class rippleEffect : MonoBehaviour {
/*	private float[] buffer1;
	private float[] buffer2;
	private int vertices;
	private int[] vertexIndices;

	public GameObject[]  ArreyObg ;


	public float dampner = 0.999f;
	public float maxWaveHeight = 2.0f;

	public int splashForce = 1000;

	//public int slowdown = 20;
	//private int slowdownCount = 0;
	private bool swapMe = true;

	public int cols = 128;
	public int rows =128;

	// Use this for initialization
	void Start () {

		//ArreyObg=new GameObject[];
		for (int i = 0; i < ArreyObg.Length; i++) {
			ArreyObg[i] = GameObject.FindWithTag ["Cube"];}
		print (ArreyObg.Length);
		//for (int i = 0; i < cols; i++) {
		//	for (int j = 0; j < rows; j++) {
		//		ArreyObg [i, j] = GameObject.FindGameObjectsWithTag("Cube");
		//		print (ArreyObg[i,j]);
		//	}
		//}
		for (int i = 0; i < ArreyObg.Length; i++) {print (ArreyObg[i]);}


		vertices = ArreyObg.Length;
		buffer1 = new float[vertices];
		buffer2 = new float[vertices];


		float xStep = ArreyObg.GetLength(0)/cols;
		float zStep = ArreyObg.GetLength(0)/rows;

		vertexIndices = new int[vertices];
		for (int i = 0; i < vertices; i++)
		{
			vertexIndices[i] = -1;
			buffer1[i] = 0;
			buffer2[i] = 0;
		}

		// this will produce a list of indices that are sorted the way I need them to 
		// be for the algo to work right
		for (int i = 0; i < vertices; i++) {
			float column = (vertices/xStep);// + 0.5;
			float row = (vertices/zStep);// + 0.5;
			float position = (row * (cols + 1)) + column + 0.5f;
			if ((int)position <= vertices) {
				if (vertexIndices [(int)position] >= 0) {
					print ("smash");
				}
				vertexIndices [(int)position] = i;
			}	
		}
			
	}

	/*
	void splashAtPoint(int x, int y) {
		int position = ((y * (cols + 1)) + x);
		buffer1[position] = splashForce;
		buffer1[position - 1] = splashForce;
		buffer1[position + 1] = splashForce;
		buffer1[position + (cols + 1)] = splashForce;
		buffer1[position + (cols + 1) + 1] = splashForce;
		buffer1[position + (cols + 1) - 1] = splashForce;
		buffer1[position - (cols + 1)] = splashForce;
		buffer1[position - (cols + 1) + 1] = splashForce;
		buffer1[position - (cols + 1) - 1] = splashForce;
	}
*/
	/*
// Update is called once per frame
	void Update () {

		checkInput();

	}

	void checkInput() {	
		Ray ray;
		RaycastHit hit;

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit) && Input.GetMouseButtonDown (0)) {
			for (int i = 0; i < ArreyObg.GetLength(0); i++) {
				//for (int j = 0; j < ArreyObg.GetLength(0); j++) {
					if (hit.collider.gameObject == ArreyObg [i].gameObject) 
					{
						Debug.Log ("Object of arrey {"+i+"}{"/*+j+"}");
						//splashAtPoint(i,j);
					}
				//}
			}
		}
	}
*/
/*
	void processRipples(int[] source, int[] dest) {
		int x = 0;
		int y  = 0;
		int position = 0;
		for ( y = 1; y < rows - 1; y ++) {
			for ( x = 1; x < cols ; x ++) {
				position = (y * (cols + 1)) + x;
				dest [position] = (((source[position - 1] + 
					source[position + 1] + 
					source[position - (cols + 1)] + 
					source[position + (cols + 1)]) >> 1) - dest[position]);  
				dest[position] = (int)(dest[position] * dampner);
			}			
		}	
	}
*/
}
