using UnityEngine;
using System.Collections;

public class RandMove : MonoBehaviour 
{
	Vector3 floatY;
	float number; 
	public float min=-0.5f;
	public float max= 0.5f;

	//private float startPosition;
    
    // Use this for initialization
    void Start () 
	{
		number = Random.Range(min,max);
    }

    // Update is called once per frame
    void Update()
    {
		floatY = transform.position;
		floatY.y = (Mathf.Sin(Time.time) * number) + 1.0f;
		transform.position = floatY;
    }
		

}
