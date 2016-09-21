using UnityEngine;
using System.Collections;

public class BuildCity : MonoBehaviour 
{
	public GameObject[] buildings;
	public int mapHeight = 20;
	public int mapWidth = 20;
	int buildingFootPrint = 3;
	public GameObject xStreet;
	public GameObject zStreet;
	public GameObject crossStreet;
	int[,] mapgrid;

	void Start()
	{
		mapgrid = new int[mapWidth, mapHeight];

		for (int h = 0; h < mapHeight; h++) 
		{
			for (int w = 0; w < mapWidth; w++) 
			{
				mapgrid[w,h] = (int)(Mathf.PerlinNoise (w/10.0f, h/10.0f) * 10);
			}
		}

		int x = 0;
		for(int n = 0; n < 50; n++)
		{
			for(int h = 0; h < mapHeight; h++)
			{
				mapgrid [x, h] = -1;
			}
			x += Random.Range (3, 3);
			if (x >= mapWidth)
				break;
		}

//		int z = 0;
//		for(int n = 0; n < 50; n++)
//		{
//			for(int w = 0; w < mapHeight; w++)
//			{
//				if (mapgrid [w, z] == -1) 
//				{
//					mapgrid [w, z] = -3;
//				} 
//				else 
//				{
//					mapgrid [w, z] = -2;
//				}
//			}
//			z += Random.Range (2, 20);
//			if (z >= mapHeight)
//				break;
//		}


		for (int h = 0; h < mapHeight; h++) 
		{
			for (int w = 0; w < mapWidth; w++) 
			{
				int result = mapgrid [w, h];
				Vector3 pos = new Vector3 (w * buildingFootPrint,0,h * buildingFootPrint);
				if(result == -2)
					Instantiate (crossStreet, pos, crossStreet.transform.rotation);
				else if(result == -1)
					Instantiate (zStreet, pos, crossStreet.transform.rotation);
				else if(result  < 0)
					Instantiate (xStreet, pos, crossStreet.transform.rotation);
				else if(result < 2)
					Instantiate (buildings [0], pos, Quaternion.identity);
				else if(result < 4)
					Instantiate (buildings [1], pos, Quaternion.identity);
				else if(result < 5)
					Instantiate (buildings [2], pos, Quaternion.identity);
				else if(result < 6)
					Instantiate (buildings [3], pos, Quaternion.identity);
				else if(result < 7)
					Instantiate (buildings [4], pos, Quaternion.identity);
				else if(result < 10)
					Instantiate (buildings [5], new Vector3(pos.x, pos.y + 0.1f, pos.z), new Quaternion(90,0,0,0));

			}
		}


//		for(int i = 0; i < mapHeight; i++)
//		{
//			for(int j = 0; j < mapHeight; j++)
//			{
//				print (mapgrid[i,j]);
//			}
//		}
	}
}
