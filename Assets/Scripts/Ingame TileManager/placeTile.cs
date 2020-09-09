using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class placeTile : MonoBehaviour
{

	/* TODO 
	- change "testTile" to "tileSelected" 
	- implement "SelectTile" method

	*/

	[SerializeField]
	Tile testTile;

	Tile tileSelected;
	[SerializeField]
	Tilemap tilemap;

	Camera cam;

	void Start()
	{
		cam = Camera.main;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
			Vector3Int gridPosition = tilemap.WorldToCell(cam.ScreenToWorldPoint(mousePos));
			if (!tilemap.HasTile(gridPosition))
			{
				Debug.Log(gridPosition);
				tilemap.SetTile(gridPosition, testTile);

			}
			else
			{
				Debug.LogWarning("Can't place tile there!");
			}

		}
	}

	void SelectTile()
	{
		// Todo: select the desired tile to place
	}
}