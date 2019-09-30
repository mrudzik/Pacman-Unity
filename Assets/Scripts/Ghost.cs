using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
	[HideInInspector] public Vector3 nextPos;
	[HideInInspector] public int posY;
	[HideInInspector] public int posX;
	[HideInInspector] public PacMan_Map ourMap;

	public float speed = 4f;
	private int 	_direction = -1;

	private MapElement GetNextElement(int dir)
	{
		MapElement nextObj = null;
		switch (dir)
		{
			case 0:
				if (posY < 1)
					break;
				nextObj = ourMap.entireMap[posY - 1][posX];
				break;
			case 1:
				if (posX > ourMap.entireMap[posY].Length - 2)
					break;
				nextObj = ourMap.entireMap[posY][posX + 1];
				break;
			case 2:
				if (posY > ourMap.entireMap.Length - 2)
					break;
				nextObj = ourMap.entireMap[posY + 1][posX];
				break;
			case 3:
				if (posX < 1)
					break;
				nextObj = ourMap.entireMap[posY][posX - 1];
				break;
		}
		if (nextObj != null)
			return nextObj;
		
		return null;
	}
	
	
	private void MoveGhost(int thisDir)
	{
		// When Reached Tile center
		if (transform.position == ourMap.entireMap[posY][posX].transform.position)
		{
			// Check if crossRoad then we will refresh path
			if (IsCrossRoad())
			{
				AnalyzeTrajectory();
			}
			
			// When we need to make a decision
			// We forced to change path
			if (path != null)
				if (path.Count > 0)
					thisDir = path.Pop();
			
			ChangeDirection(thisDir);
			
			MapElement mapElem = GetNextElement(thisDir);
			if (mapElem != null)
			{
				if (mapElem.state == "path" || mapElem.state == "pacman"
				                            || mapElem.state == "bigPath"
				                            || mapElem.state == "ghost") // Addition
				{
					nextPos = mapElem.transform.position;
					posY = mapElem.posY;
					posX = mapElem.posX;
				}
			}
//			Debug.Log("Direction -> " + _direction);
		}
		transform.position = Vector3.MoveTowards(transform.position,
			nextPos, speed * Time.deltaTime);	
	}
	

	private bool 	IsCrossRoad()
	{
		MapElement ourPos = ourMap.entireMap[posY][posX];

		return (ourPos.nodes[0].state != "wall" || ourPos.nodes[2].state != "wall")
		        && (ourPos.nodes[1].state != "wall" || ourPos.nodes[3].state != "wall");

	}
	
	private bool 	IsWalkable(int dir)
	{
		MapElement mapElem = GetNextElement(dir);
		if (mapElem != null)
			if (mapElem.state == "path" || mapElem.state == "pacman"
			                            || mapElem.state == "bigPath"
			                            || mapElem.state == "ghost") // Addition
				return true;
		return false;
	}
	
	public bool    ChangeDirection(int newDir)
	{
		if (IsWalkable(newDir))
			_direction = newDir;
		else
			return false;
		
		switch (_direction)
		{
			case 0:
				transform.rotation = Quaternion.Euler(0, 0,0); 
				break;
			case 1:
				transform.rotation = Quaternion.Euler(0, 90,0); 
				break;
			case 2:
				transform.rotation = Quaternion.Euler(0, 180,0); 
				break;
			case 3:
				transform.rotation = Quaternion.Euler(0, 270,0); 
				break;
		}

		return true;
	}

















	private int targetY;
	private int targetX;
	private Stack<int> path;
	public AISearcher ourBrains;
	
	
	private void AnalyzeTrajectory()
	{
		ourBrains.ourMap = ourMap;
		BlinkyBehaviour();
	
		path = ourBrains.WaveSearch(posY, posX, targetY, targetX);
	
//		//	Path Shower
//		foreach (var num in path)
//		{
//			Debug.Log("Log = " + num);
//		}

	}
	
	
	private void SetTarget(int newY, int newX)
	{
		targetY = newY;
		targetX = newX;
	}
	
	private void BlinkyBehaviour()
	{
		SetTarget(ourMap.currPacman.posY, ourMap.currPacman.posX);
	}
	private void Update()
	{
		
		if (path == null || path.Count == 0)
			AnalyzeTrajectory();
		
		MoveGhost(_direction);
	}
}
