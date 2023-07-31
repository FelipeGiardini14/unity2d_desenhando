﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
	Color corBegin = Color.black;
	Color corEnd = Color.red;

	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCollider;
	public Rigidbody2D rigidBody;

	[HideInInspector] public List<Vector2> points = new List<Vector2>();
	[HideInInspector] public int pointsCount = 0;

	//The minimum distance between line's points.
	float pointsMinDistance = 0.1f;

	//Circle collider added to each line's point
	float circleColliderRadius;

	void Update()
    {
		if (Input.GetMouseButtonUp(0))
			Destroy(gameObject, 5);

		if (GameObject.FindGameObjectsWithTag("Line").Length > 4)
			Destroy(gameObject);

		if (pointsCount > 120)
        {
			//lineRenderer.SetColors(corBegin, corEnd);
			lineRenderer.startColor = corBegin;
			lineRenderer.endColor = corEnd;
		}
		if (pointsCount > 150)
			Destroy(gameObject);
	}

	public void AddPoint(Vector2 newPoint)
	{
		//If distance between last point and new point is less than pointsMinDistance do nothing (return)
		if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
			return;

		points.Add(newPoint);
		pointsCount++;

		//Add Circle Collider to the Point
		CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
		circleCollider.offset = newPoint;
		circleCollider.radius = circleColliderRadius;

		//Line Renderer
		lineRenderer.positionCount = pointsCount;
		lineRenderer.SetPosition(pointsCount - 1, newPoint);

		//Edge Collider
		//Edge colliders accept only 2 points or more (we can't create an edge with one point :D )
		if (pointsCount > 1)
			edgeCollider.points = points.ToArray();
	}

	public Vector2 GetLastPoint()
	{
		return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
	}

	public void UsePhysics(bool usePhysics)
	{
		// isKinematic = true  means that this rigidbody is not affected by Unity's physics engine
		rigidBody.isKinematic = !usePhysics;
	}

	public void SetLineColor(Gradient colorGradient)
	{
		lineRenderer.colorGradient = colorGradient;
	}

	public void SetPointsMinDistance(float distance)
	{
		pointsMinDistance = distance;
	}

	public void SetLineWidth(float width)
	{
		lineRenderer.startWidth = width;
		lineRenderer.endWidth = width;

		circleColliderRadius = width / 1f;

		edgeCollider.edgeRadius = circleColliderRadius;
	}
}