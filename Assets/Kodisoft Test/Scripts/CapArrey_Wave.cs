using UnityEngine;
using System.Collections;

public class CapArrey_Wave : MonoBehaviour {
	public int masSizeX=3;
	public int masSizey=4;
	float sliderX;
	float sliderY;
	int i,j;
	public GameObject objPrefab;
	GameObject [] objMass;
	Vector3 [] MassBuff1;
	Vector3 [] MassBuff2;
	Vector3[] temp;
	int l, l2;
	Ray ray;
	RaycastHit hit;
	public bool doWindow0 = false;
	int row, column;

	// Use this for initialization

	void Start()
	{
		l2 = masSizeX * masSizey;
		objMass=new GameObject[l2];
		MassBuff1 = new Vector3[l2];
		MassBuff2 = new Vector3[l2];
		temp = new Vector3[l2];
		row = 0; column = 1;
		for (int i = 0; i < l2; i ++) 
		{

			GameObject item = Instantiate (objPrefab) as GameObject;
			item.transform.parent = transform;
			item.name = "Caps_"+i;
			//Вывод в виде квадратного масива А==Б
			if (masSizeX == masSizey) 
			{
				item.transform.Translate(((i % masSizeX) * 1.0F), 0.0f/* Random.Range (0.0F, 3.0F)*/, (Mathf.Floor (i / masSizey) * 3F));
			} 
			else 
				//Вывод в виде прямоугольного масива если А>Б или A<Б
				if (masSizeX > masSizey || masSizeX < masSizey) 
				{
					if(column==masSizeX+1)
					{
						row++; 
						column = 1; 
					}
					item.transform.Translate (column*3-1, 0.0f/* Random.Range (0.0F, 3.0F)*/, row*3F);
					column++;
				} 			
			item.transform.Rotate (0.0F,Random.Range (-40.0F, 40.0F),0.0F);
			objMass [i] = item;
			MassBuff1[ i ] = item.transform.localScale;
			MassBuff2[ i ] = item.transform.localScale;
			temp[i] = item.transform.localScale;
		}
		/*
		for (i = 0; i < masSizeX; i++) 
		{
			for (j = 0; j < masSizey; j++) 
			{
				GameObject item = Instantiate (objPrefab) as GameObject;
				item.transform.parent = transform;
				if (i == 0) 
				{
					item.transform.Translate (0, 0, j * 2.75F);
				} else	item.transform.Translate (i*2.75F, 0, j * 2.75F);
				item.transform.Rotate (0.0F,Random.Range (-40.0F, 40.0F),0.0F);
				objMass [i, j] = item;
			}
		}
		*/
	}

	void Update () 
	{
		// Рейкаст - определение щелчка по одному из кубов и его место в масиве
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit))
		{
			for (int i = 1; i < objMass.Length; i++)
			{
				if (hit.collider.name == objMass[i].name)
				{
					Splash (i);
				}				

			}
		}
		if(Input.GetMouseButtonDown (0)){						

			Wave ();

		}

	}
	void Splash(int i)
	{
		MassBuff1 [i] = new Vector3 (MassBuff1 [i].x, 20.0f, MassBuff1 [i].z);
		MassBuff1 [i - 1] = new Vector3 (MassBuff1 [i].x, 15.0f, MassBuff1 [i].z);
		MassBuff1 [i + 1 >= MassBuff1.Length ? MassBuff1.Length - (masSizeX * 2) : i + 1] = new Vector3 (MassBuff1 [i].x, 15.0f, MassBuff1 [i].z);
		MassBuff1 [(i + masSizeX) >= MassBuff1.Length ? MassBuff1.Length - (masSizeX * 2) : i + masSizeX] = new Vector3 (MassBuff1 [i].x, 15.0f, MassBuff1 [i].z);
		MassBuff1 [(i + (masSizeX - 1)) >= MassBuff1.Length ? MassBuff1.Length-(masSizeX*2)-1 : i + (masSizeX - 1)] = new Vector3 (MassBuff1 [i].x, 10.0f, MassBuff1 [i].z);
		MassBuff1 [i + (masSizeX) + 1 >= MassBuff1.Length ? MassBuff1.Length-(masSizeX*2)+1 : i + (masSizeX) + 1] = new Vector3 (MassBuff1 [i].x, 10.0f, MassBuff2 [i].z);
		MassBuff1 [i - (masSizeX) >= MassBuff1.Length || i - (masSizeX) <= 0 ? MassBuff1.Length-masSizeX*2 : i - (masSizeX)] = new Vector3 (MassBuff1 [i].x, 15.0f, MassBuff1 [i].z);
		MassBuff1 [(i - (masSizeX) - 1) < 0 ? MassBuff2.Length - (masSizeX * 2)-1 : i - (masSizeX) - 1] = new Vector3 (MassBuff1 [i].x, 10.0f, MassBuff1 [i].z);
		MassBuff1 [i - (masSizeX) + 1 >= MassBuff1.Length ? MassBuff1.Length - (masSizeX * 2)+1 : i - (masSizeX) + 1] = new Vector3 (MassBuff1 [i].x, 10.0f, MassBuff1 [i].z);

		//print ("Worked Splash");	
		//Всплекск - подьем кроме наведннного окужающих его 8 елементов
		/*if (i <= Mass.Length) {
			MassBuff1 [i] = new Vector3 (MassBuff1 [i].x, 20.0f, MassBuff1 [i].z);
			MassBuff1 [i - 1] = new Vector3 (MassBuff1 [i].x, 15.0f, MassBuff1 [i].z);
			MassBuff1 [i + 1 >= MassBuff1.Length ? MassBuff2.Length : i + 1] = new Vector3 (MassBuff1 [i].x, 15.0f, MassBuff1 [i].z);
			MassBuff1 [(i + masSizeX) >= MassBuff1.Length ? MassBuff2.Length - (masSizeX * 2) : i + masSizeX] = new Vector3 (MassBuff1 [i].x, 15.0f, MassBuff1 [i].z);
			MassBuff1 [(i + (masSizeX - 1)) >= MassBuff1.Length ? MassBuff2.Length : i + (masSizeX - 1)] = new Vector3 (MassBuff1 [i].x, 10.0f, MassBuff1 [i].z);
			MassBuff1 [i + (masSizeX) + 1 >= MassBuff1.Length ? MassBuff2.Length : i + (masSizeX) + 1] = new Vector3 (MassBuff1 [i].x, 10.0f, MassBuff2 [i].z);
			MassBuff1 [i - (masSizeX) >= MassBuff1.Length || i - (masSizeX) <= 0 ? MassBuff2.Length : i - (masSizeX)] = new Vector3 (MassBuff1 [i].x, 15.0f, MassBuff1 [i].z);
			MassBuff1 [(i - (masSizeX) - 1) < 0 ? MassBuff2.Length + (masSizeX * 2) : i - (masSizeX) - 1] = new Vector3 (MassBuff1 [i].x, 10.0f, MassBuff1 [i].z);
			MassBuff1 [i - (masSizeX) + 1 >= MassBuff1.Length ? MassBuff2.Length : i - (masSizeX) + 1] = new Vector3 (MassBuff1 [i].x, 10.0f, MassBuff1 [i].z);
		}//MassBuff1 [i] = new Vector3(1,10f,1);*/
		Wave ();

	}
	void Wave()
	{

		int bottom = l2 - masSizeX; // нижняя граница (длинна масива минус один ряд) ??? вычислялась в оригинальном алгоритме не понятно зачем

		// update buffers
		for (int i = 0; i < bottom; i++) {

			Vector3 x1, x2, y1, y2; // координаты как я понимаю границы масива

			if (i % masSizeX == 0) {

				// left edge/левая кромка

				x1 = new Vector3 (1, 3, 1);
				x2.y = MassBuff1 [i + 1].y;

			} else if (i % masSizeX == masSizeX - 1) {

				// right edge/ правая кромка

				x1.y = MassBuff1 [i - 1].y;
				x2 = new Vector3 (1, 3, 1);

			} else
				x1.y = MassBuff1 [i - 1].y;
			x2.y = MassBuff1 [i].y;

			if (i < masSizeX) {

				// top edge

				y1 = new Vector3 (1, 3, 1);
				y2.y = MassBuff1 [i + masSizeX].y;

			} else if (i > l - masSizeX - 1) {

				// bottom edge

				y1.y = MassBuff1 [i - masSizeX].y;
				y2 = new Vector3 (1, 3, 1);
			} else
				y1.y = MassBuff1 [i - masSizeX].y;
			if (i + masSizeX > MassBuff1.Length) {
				y2 = MassBuff1 [i];
			} else
				y2 = MassBuff1 [i+masSizeX];


			MassBuff2 [i].y = ((x1.y + x2.y + y1.y + y2.y) /4.99f) - MassBuff2 [i].y;
			//MassBuff1 [i].y += (MassBuff2[i].y - MassBuff1[i].y)*0.25f;
			MassBuff2 [i].y -= MassBuff2 [i].y / 6.25f;
		}
		for (int i = bottom; i < l2; i++) {
			MassBuff1[i].y = 5.0f;
		}

		for (int i = 0; i < l2; i++)
		{
			temp[i].y = MassBuff1[i].y;
			MassBuff1[i].y = MassBuff2[i].y;
			MassBuff2 [i].y = temp[i].y;
		}


		for (int i = 0; i < temp.Length; i++)
		{
			float tempVectY = 3.0f;

			if (temp [i].y > 20) {
				tempVectY = 20.0f;
			} else if (temp [i].y < 1) {
				tempVectY = 3.0f;
			} else
				tempVectY = temp [i].y;
			// Обновление позиции елементов основного масива 
			objMass[i].transform.position += new Vector3(0, temp [i].y, 0);
			//objMass[i].transform.localScale = new Vector3(temp[i].x, tempVectY*0.5f, temp[i].z);

			//Mass[i].transform.Rotate(0,0,0);
		}

	}
	//Give abilyty change from UI 
	public void SetX(int newMasSizeX)
	{
		masSizeX = newMasSizeX;
	}
	public void SetY(int newMasSizeY)
	{
		masSizey = newMasSizeY;
	}

	// Update is called once per frame
	public void Restart () 
	{
		for (i = 0; i < l2; i++) 
		{
			
				GameObject.Destroy(objMass [i]);

		}

		Start ();
	}

	void OnGUI() 
	{
		doWindow0 = GUI.Toggle (new Rect (10, 10, 100, 200), doWindow0, "Option");
		if (doWindow0) 
		{
			GUI.Window (0, new Rect (10, 50, 175, 225), DoWindow0, "Option Window");
		}
		GUI.Label (new Rect (85, 10, 100, 50), "Use Q and E \n to zoom in/out");
	}

	void DoWindow0(int windowID) 
	{
		// Draw any Controls inside the window
		// Wrap everything in the designated GUI Area
		GUILayout.BeginArea (new Rect (10,25,150,200));
		// Begin the singular Horizontal Group
		//GUILayout.BeginHorizontal();
		// Arrange two more Controls vertically beside the Button
		//GUILayout.BeginVertical();
		GUILayout.Box("Curent size X: "+ masSizeX);
		GUILayout.Box("Curent size Y: "+ masSizey);
		GUILayout.Box("Choise new size");
		GUILayout.Box("New Value X: " + Mathf.Round(sliderX));
		sliderX = GUILayout.HorizontalSlider (sliderX, 1, 100);
		GUILayout.Box("New Value Y: " + Mathf.Round(sliderY));
		sliderY = GUILayout.HorizontalSlider (sliderY, 1, 100);
		//Reset arrey
		if (GUILayout.RepeatButton ("Regenerate"))
		{
			Restart();
			SetX(System.Convert.ToInt32(sliderX));
			SetY(System.Convert.ToInt32(sliderY));
		}
		//GUILayout.EndVertical();
		//GUILayout.EndHorizontal();
		GUILayout.EndArea();	
	}
}
