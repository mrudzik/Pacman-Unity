using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISearcher : MonoBehaviour
{
	[HideInInspector] public PacMan_Map ourMap;
	
//	public Stack<int> DFSearch(int posY, int posX, int targetY, int targetX)
//	{
//		ourMap.UnmarkAllTiles();
//		Stack<int> path = new Stack<int>();					
//		ourMap.entireMap[posY][posX].
//				AISearchPathDFS(targetY, targetX, path, -1);
//
//		return path;
//	}
	
	
	
	
	public Stack<int> WaveSearch(int posY, int posX, int targetY, int targetX)
	{
		// Clear all tiles
		ourMap.UnmarkAllTiles();
		
		// Mark Starting Tile
		MapElement tempTile = ourMap.entireMap[posY][posX];
		tempTile.waveNum = 0;
		// Safety measure
		if (tempTile.posY == targetY && tempTile.posX == targetX)
			return null;
		// Making Queue of elements that "Need To be processed"
		Queue<MapElement> toProcess = new Queue<MapElement>();
		
		bool foundFinish = false;
		bool outOfNodes = false;
		do
		{
			// Add tiles that need to be processed
			// all untouched nodes from current Tile
			for (int i = 0; i < tempTile.nodes.Length; i++)
			{
				if (tempTile.nodes[i] != null)
					if (tempTile.nodes[i].state != "wall"
						&& tempTile.nodes[i].stage == -1)
					{
						toProcess.Enqueue(tempTile.nodes[i]);
						tempTile.nodes[i].stage = 0;
					}
			}
			
			// Mark wave num on all nodes from current Tile
			for (int i = 0; i < tempTile.nodes.Length; i++)
			{
				if (tempTile.nodes[i] != null)
				{
					if (tempTile.nodes[i].state != "wall"
					    && tempTile.nodes[i].waveNum == -1)
					{
						tempTile.nodes[i].waveNum = tempTile.waveNum + 1;
					}
					else if (tempTile.nodes[i].state == "wall")
					{
						tempTile.nodes[i].waveNum = -2;
					}
				}
			}
			
			// Try to find final cell
			for (int i = 0; i < tempTile.nodes.Length; i++)
			{
				if (tempTile.nodes[i] != null)
				{
					if (tempTile.nodes[i].posY == targetY
					    && tempTile.nodes[i].posX == targetX)
					{
						foundFinish = true;
					}
				}
			}
			
			// Mark this tile as processed
			tempTile.stage = 1;
			
			if (toProcess.Count > 0)
			{
				tempTile = toProcess.Dequeue();
			}
			else
			{
				outOfNodes = true;
				foundFinish = true;
			}
//			ShowMatrix();
		} while (foundFinish == false);

//		ShowMatrix();


		if (outOfNodes)
		{
			print("Out of Nodes!!!");
			return null;
		}
		// If proper win conditions
		// We will Continue
		
		
		
		
		
		
		// Making new path for ghost
		Stack<int> path = new Stack<int>();

		MapElement finishTile = ourMap.entireMap[targetY][targetX];
		
		// Until finish Tile reaches ghost
		while (finishTile.posY != posY || finishTile.posX != posX)
		{
			MapElement nextTile = null;
			// Find shortest path
			for (int i = 0; i < finishTile.nodes.Length; i++)
			{
				// Assign next tile if not already
				if (nextTile == null && finishTile.nodes[i] != null)
				{
					if (finishTile.nodes[i].waveNum > -1)
					{
						nextTile = finishTile.nodes[i];
					}
				}
				
				// Find Tile that could be even closer
				if (nextTile != null && finishTile.nodes[i] != null)
				{
					if (finishTile.nodes[i].waveNum > -1)
					{
						if (nextTile.waveNum > finishTile.nodes[i].waveNum)
						{
							nextTile = finishTile.nodes[i];
						}
					}
					
				}	
			}
			
			if (nextTile == null)
			{
				print("Wierd path was built");
				break;
			}
			
			// Find in which direction that tile leads
			for (int i = 0; i < finishTile.nodes.Length; i++)
			{
				if (finishTile.nodes[i] != null)
				{
					if (finishTile.nodes[i] == nextTile)
					{
						// Found direction
						// Invert directions for ghost
						if (i <= 1)
							path.Push(i + 2);
						else
							path.Push(i - 2);
						
						break;
					}
				}
			}

			finishTile = nextTile;
			if (finishTile == null)
			{
				print("Wierd path build");
				break;
			}
		}
		return path;
	}
	
	
	
	
	

}
