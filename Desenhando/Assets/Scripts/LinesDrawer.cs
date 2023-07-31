using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesDrawer : MonoBehaviour
{
	public GameObject linePrefab;
	public LayerMask cantDrawOverLayer;
	int cantDrawOverLayerIndex;

	[Space(30f)]
	public Gradient lineColor;
	public float linePointsMinDistance;
	public float lineWidth;

	Line currentLine;

	public Camera cam;

    void Start()
	{
		cantDrawOverLayerIndex = LayerMask.NameToLayer("Obstaculo");
	}

	void Update()
	{
		if (Time.timeScale == 1 && gameObject.layer != LayerMask.NameToLayer("Obstaculo") && gameObject.layer != LayerMask.NameToLayer("UI"))
		{
			if (Input.GetMouseButtonDown(0))
				BeginDraw();

			if (currentLine != null)
				Draw();

			if (Input.GetMouseButtonUp(0))
				EndDraw();
		}
	}

	// Begin Draw ----------------------------------------------
	void BeginDraw()
	{
		if (Time.timeScale == 0) // Verifica se o jogo está em pausa
			return;

		if (currentLine != null)
			return;

		currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

		//Set line properties
		currentLine.UsePhysics(false);
		currentLine.SetLineColor(lineColor);
		currentLine.SetPointsMinDistance(linePointsMinDistance);
		currentLine.SetLineWidth(lineWidth);

	}
	// Draw ----------------------------------------------------
	void Draw()
	{
		Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

		//Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )
		RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer);

		if (hit)
			EndDraw();
		else
			currentLine.AddPoint(mousePosition);
	}
	// End Draw ------------------------------------------------
	public void EndDraw()
	{
		if (currentLine != null)
		{
			if (currentLine.pointsCount < 2)
			{
				//If line has one point
				Destroy(currentLine.gameObject);
			}
			else
			{
				//Add the line to "CantDrawOver" layer
				currentLine.gameObject.layer = cantDrawOverLayerIndex;

				//Activate Physics on the line
				currentLine.UsePhysics(true);

				currentLine = null;
			}
		}
	}
}