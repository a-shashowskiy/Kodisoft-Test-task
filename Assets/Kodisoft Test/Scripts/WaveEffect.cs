using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveEffect : MonoBehaviour {
	Ray ray;
	RaycastHit hit;
	public int masSizeX;
	public int masSizeZ;
	float sliderX;
	float sliderZ;
	public int size = 1;
	public int res = 15;
	int l, l2;
	//int sizeres, halfsizeres;
	public GameObject cubePrefab;
	GameObject[] Mass;
	Vector3 [] MassBuff1;
	Vector3 [] MassBuff2;
	Vector3[] temp;
	public bool doWindow0 = false;
	int row, column;



	// Use this for initialization
	[ContextMenu ("Spawn Object NOW")]
	void Start ()
	{
		l = res * res;
		l2 = 0;
		l2 = masSizeX * masSizeZ;
		//sizeres = size * res;
		//halfsizeres = sizeres / 2;
		Mass= new GameObject[l2];
		MassBuff1 = new Vector3[l2];
		MassBuff2 = new Vector3[l2];
		temp = new Vector3[l2];

		row = 0; column = 1;

		// Прозиводится инициализация масива одномерного массива из Prefab-ов 
		for (int i = 0; i < l2; i ++) 
		{
			
			GameObject item = Instantiate (cubePrefab) as GameObject;
			item.transform.parent = transform;
			item.name = "Cube_"+i;
			//Вывод в виде квадратного масива А==Б
			if (masSizeX == masSizeZ) 
			{
				item.transform.Translate(((i % masSizeX) * 1.0F), 0.0f/* Random.Range (0.0F, 3.0F)*/, (Mathf.Floor (i / masSizeZ) * 1.0F));
			} 
			else 
				//Вывод в виде прямоугольного масива если А>Б или A<Б
				if (masSizeX > masSizeZ || masSizeX < masSizeZ) 
				{
					if(column==masSizeX+1)
					{
						row++; 
						column = 1; 
					}
					item.transform.Translate (column-1, 0.0f/* Random.Range (0.0F, 3.0F)*/, row);
					column++;
				} 			
			Mass [i] = item;
			MassBuff1[ i ] = item.transform.localScale;
			MassBuff2[ i ] = item.transform.localScale;
			temp[i] = item.transform.localScale;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		// Рейкаст - определение щелчка по одному из кубов и его место в масиве
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit))
		{
			for (int i = 1; i < Mass.Length; i++)
			{
				if (hit.collider.name == Mass[i].name)
				{
					Splash (i);
				}				
			
			}
		}
		if(Input.GetMouseButtonDown (0)){
			Wave ();
			Wave ();
						
		}

	}

	void Splash(int i)
	{
		//Line One Center
		MassBuff1 [i] = new Vector3 (MassBuff1 [i].x, 20.0f, MassBuff1 [i].z);
		//-1 left object in one line with centr 
		MassBuff1 [i - 1] = new Vector3 (MassBuff1 [i].x, 15.0f, MassBuff1 [i].z);
		//+1 left object in one line with centr 
		MassBuff1[i + 1 >= MassBuff1.Length ? MassBuff1.Length - (masSizeX * 2) : i + 1] = new Vector3 (MassBuff1 [i].x, 15.0f, MassBuff1 [i].z);
		//Line two below 
		MassBuff1 [(i + masSizeX) >= MassBuff1.Length ? MassBuff1.Length - (masSizeX * 2) : i + masSizeX] = new Vector3 (MassBuff1 [i].x, 15.0f, MassBuff1 [i].z);
		MassBuff1 [(i + (masSizeX - 1)) >= MassBuff1.Length ? MassBuff1.Length-(masSizeX*2)-1 : i + (masSizeX - 1)] = new Vector3 (MassBuff1 [i].x, 10.0f, MassBuff1 [i].z);
		MassBuff1 [i + (masSizeX) + 1 >= MassBuff1.Length ? MassBuff1.Length-(masSizeX*2)+1 : i + (masSizeX) + 1] = new Vector3 (MassBuff1 [i].x, 10.0f, MassBuff2 [i].z);
		//Line thre up
		MassBuff1 [i - (masSizeX) >= MassBuff1.Length || i - (masSizeX) <= 0 ? MassBuff1.Length-masSizeX*2 : i - (masSizeX)] = new Vector3 (MassBuff1 [i].x, 15.0f, MassBuff1 [i].z);
		MassBuff1 [(i - (masSizeX) - 1) <= 0 || (i - (masSizeX) - 1) >= MassBuff1.Length ? MassBuff2.Length - (masSizeX * 2)-1 : i - (masSizeX) - 1] = new Vector3 (MassBuff1 [i].x, 10.0f, MassBuff1 [i].z);
		MassBuff1 [i - (masSizeX) + 1 >= MassBuff1.Length || i - (masSizeX) + 1 <= 0 ? MassBuff1.Length - (masSizeX * 2)+1 : i - (masSizeX) + 1] = new Vector3 (MassBuff1 [i].x, 10.0f, MassBuff1 [i].z);

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

	void OnMousOver(){

	}

	void OnMouseExit(){
		
	}

	void Wave()
	{

		int bottom = masSizeX*masSizeZ - masSizeZ; // нижняя граница (длинна масива минус один ряд) ??? вычислялась в оригинальном алгоритме не понятно зачем

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


			MassBuff2 [i].y = ((x1.y + x2.y + y1.y + y2.y) / 3.59f) - MassBuff2 [i].y;
			MassBuff1 [i].y += (MassBuff2[i].y - MassBuff1[i].y)*0.25f;
			//MassBuff2 [i].y -= MassBuff2 [i].y / 7.25f;
		}
		
		for (int i = 0; i < l2; i++)
		{
				temp[i].y = MassBuff1[i].y;
				MassBuff1[i].y = MassBuff2[i].y;
				MassBuff2 [i].y = temp[i].y;
		}


		for (int i = 0; i < temp.Length; i++)
		{
			float tempVectY = 0.0f;

			if (MassBuff2 [i].y > 15f) {
					tempVectY = 15.0f;
				} else if (MassBuff2 [i].y < 1f) {
					tempVectY = 5.0f;
				} else
					tempVectY = MassBuff2 [i].y;
			// Обновление позиции елементов основного масива 

			Mass[i].transform.localScale = new Vector3(temp[i].x, tempVectY*0.45f, temp[i].z);

			//Mass[i].transform.Rotate(0,0,0);
		}
		

	}
	

	public void Restart () 
	{
		for (int i = 0; i < Mass.Length; i++) 
		{
			GameObject.Destroy(Mass [i]);
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
		GUILayout.Box("Curent size Y: "+ masSizeZ);
		GUILayout.Box("Choise new size");
		GUILayout.Box("New Value X: " + Mathf.Round(sliderX));
		sliderX = GUILayout.HorizontalSlider (sliderX, 1, 100);
		GUILayout.Box("New Value Y: " + Mathf.Round(sliderZ));
		sliderZ = GUILayout.HorizontalSlider (sliderZ, 1, 100);
		//Reset arrey
		if (GUILayout.Button ("Regenerate"))
		{
			masSizeX=(int)Mathf.FloorToInt(sliderX);
			masSizeZ=(int)Mathf.FloorToInt(sliderZ);
			Restart();
		}
		//GUILayout.EndVertical();
		//GUILayout.EndHorizontal();
		GUILayout.EndArea();	
	}

}
