using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan_Controller : MonoBehaviour
{
	public float 	speed = 6f;
	private int     _direction = -1;
	
	
	[HideInInspector] public Vector3 nextPos;
	[HideInInspector] public int posY;
	[HideInInspector] public int posX;
	[HideInInspector] public PacMan_Map ourMap;
	[HideInInspector] public PacManData ourData;
	
	
	// 0 - up
	// 1 - right
	// 2 - down
	// 3 - left
	
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
	
	private bool 	IsWalkable(int dir)
	{
		MapElement mapElem = GetNextElement(dir);
		if (mapElem != null)
			if (mapElem.state != "wall" && mapElem.state != "ghost")
				return true;
		return false;
	}
	
	public void     ChangeDirection(int newDir)
	{
		if (IsWalkable(newDir))
			_direction = newDir;
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
	}
	
	
	private void 	MovePacMan(int thisDir)
	{
		if (transform.position == ourMap.entireMap[posY][posX].transform.position)
		{
			
			if (ourMap.entireMap[posY][posX].state == "exit")
				ourData.DoWin();	// When Reached Exit
			
			
			MapElement mapElem = GetNextElement(thisDir);
			if (mapElem != null)
			{
				if (mapElem.state != "wall" && mapElem.state != "ghost")
				{
					nextPos = mapElem.transform.position;
					posY = mapElem.posY;
					posX = mapElem.posX;
				}
			}
		}
		
		transform.position = Vector3.MoveTowards(transform.position,
			nextPos, speed * Time.deltaTime);		
	}
	
	private void KeyBehaviour()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
			ChangeDirection(0);
		
		if (Input.GetKeyDown(KeyCode.RightArrow))
			ChangeDirection(1);
		
		if (Input.GetKeyDown(KeyCode.DownArrow))
			ChangeDirection(2);
		
		if (Input.GetKeyDown(KeyCode.LeftArrow))
			ChangeDirection(3);	
	}
	
	private void Update()
	{
		KeyBehaviour();
		MovePacMan(_direction);
	}
}
