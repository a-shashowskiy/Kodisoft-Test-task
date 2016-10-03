using UnityEngine;
using System;
using System.Collections;

public class MouseOver : MonoBehaviour 
{
	string nameObj;
	public GameObject TestCub;
	Vector3 moveObj;
	float tempx, tempy, tempz;


	//Вызывается при старте 
	void Start()
	{
		moveObj = new Vector3 (0, 0, 0);
		moveObj = transform.position;
		tempx = moveObj.x;
		tempy = moveObj.y;
		tempz = moveObj.z;

	}
	//Вызывается каждый раз при наведении мышы на обект
	void OnMouseEnter()
	{
		//print ("On Mouse Enter");//debug mesage
		moveObj.y = 2.5f;
		moveObj.x = tempx;
		moveObj.z = tempz;
		if (GetComponent<RandMove> ().enabled == true) 
		{
			GetComponent<RandMove> ().enabled = false;
		}
		transform.Translate (moveObj.x-tempx, 2.5f, moveObj.z-tempz);
	}
	//Вызывается все время пока курсор над обект
	void OnMouseOver()
	{

	}
	//Вызывается каждый раз при убирании мышки с обьекта
	void OnMouseExit() {
		//print ("On Mouse Exit");//debug mesage
		moveObj.y -= tempy; //print (tempy);
		moveObj.x = tempx; //print (tempx);
		moveObj.z= tempz; //print (tempz);
		//print (moveObj);
		transform.Translate (moveObj.x-tempx, moveObj.y, moveObj.z-tempz);
		if (GetComponent<RandMove> ().enabled == false) {
			GetComponent<RandMove> ().enabled = true;
		}
	}
}