using UnityEngine;
using System.Collections;

public class GenCubeMassive : MonoBehaviour 
{

	public int masSizeX=3;
	public int masSizeY=4;
	float sliderX;
	float sliderY;
	int i,j;
	public GameObject cubePrefab;
	GameObject [,] Mass;
	GameObject [,] MassBuff1;
	GameObject [,] MassBuff2;
	public bool doWindow0 = false;

// Use this for initialization

void Start()
	{
		Mass=new GameObject[masSizeX,masSizeY];

		for (i = 0; i < masSizeX; i++) 
		{
			for (j = 0; j < masSizeY; j++) 
			{
				GameObject item = Instantiate (cubePrefab) as GameObject;
				item.transform.parent = transform;
				/*if (i > 1) 
				{
					item.transform.Translate (i + 1.55F, Random.Range (0.0F, 3.0F), j + 0.55F);
				} else*/
					item.transform.Translate (i, Random.Range (0.0F, 3.0F), j + 0.55F);
				Mass [i, j] = item;
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
		masSizeY = newMasSizeY;
	}

	// Update is called once per frame
public void Restart () 
	{
		for (i = 0; i < Mass.GetLength(0); i++) 
		{
			for (j = 0; j < Mass.GetLength(1); j++) 
			{
				GameObject.Destroy(Mass [i, j]);
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
		GUILayout.Box("Curent size Y: "+ masSizeY);
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
