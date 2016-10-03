using UnityEngine;
using System.Collections;

public class GenCapMassive : MonoBehaviour 
{

	public int masSizeX=3;
	public int masSizey=4;
	float sliderX;
	float sliderY;
	int i,j;
	public GameObject objPrefab;
	GameObject [,] objMass;
	GameObject [,] MassBuff1;
	GameObject [,] MassBuff2;
	public bool doWindow0 = false;

	// Use this for initialization

	void Start()
	{
		objMass=new GameObject[masSizeX,masSizey];

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
		for (i = 0; i < objMass.GetLength(0); i++) 
		{
			for (j = 0; j < objMass.GetLength(1); j++) 
			{
				GameObject.Destroy(objMass [i, j]);
			}
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
