using UnityEngine;
using System.Collections;

public class MouseOverCap : MonoBehaviour {

	Vector3 moveObj;
	float tempX=0;
	float tempZ=0;

	//Вызывается при старте 
	void Start()
	{
		moveObj = new Vector3 (0, 0, 0);
		moveObj = transform.position;
		tempX = moveObj.y;
		tempZ = moveObj.z;
	}
	//Вызывается каждый раз при наведении мышы на обект
	void OnMouseEnter()
	{
		moveObj.y = 2.5F;
		moveObj.x = tempX;
		moveObj.z= tempZ;
		transform.Translate (moveObj.x-tempX, 2.5F,moveObj.z-tempZ);
	}
	//Вызывается все время пока курсор над обект
	void OnMouseOver()
	{

	}
	//Вызывается каждый раз при убирании мышки с обьекта
	void OnMouseExit() 
	{
		moveObj.y -= 2.5F;
		moveObj.x = tempX;
		moveObj.z= tempZ;
		transform.Translate (moveObj.x-tempX, moveObj.y-2.5F,moveObj.z-tempZ);
	}
}
