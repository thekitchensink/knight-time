using UnityEngine;
using System.Collections;

class cell
{
	public bool left;
	public bool right;
	public bool top;
	public bool bottom;

  public int group;

  public cell()
  {
  }

  public cell(bool L, bool R, bool T, bool B, int G)
  {
    left = L;
    right = R;
    top = T;
    bottom = B;
    group = G;
  }
}

public class Generation : MonoBehaviour {

    public int xDense = 4;
    public int yDense = 3;

  private cell[,] dungeon;

  private int Height;
  private int Width;

	// Use this for initialization
	void Start () {
      generateMap(10, 10);
      buildMap(-10.0f, 10.0f, 4.6f, 4.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void generateMap(int width, int height)
  {
    if (xDense <= 1) xDense = 4;
    if (yDense <= 1) yDense = 3;

    dungeon = new cell[width, height];

    this.Height = height;
    this.Width = width;
    
    //needs to be at least 3 by 3
    if (width < 3 && height < 3)
      return;
		
    //initialize everyting to null
    for (int j = 0; j < height; ++j)
    {
      for (int i = 0; i < width; ++i)
      {
         dungeon[j, i] = null;      
      }
    }

    for (int j = 0; j < height; ++j)
    {
      //generate first row
      for (int i = 0; i < width; ++i)
      {
        if(dungeon[j, i] == null)
          dungeon[j, i] = new cell( true, true, true, true, j * width + i ); 
      }

      //randomly merge adjacent sets
      for (int i = 1; i < width; ++i)
      {
        int choice = Random.Range((int)0, (int)xDense);
        if (choice == 1)
        {
          dungeon[j, i - 1].right = false;
          dungeon[j, i].left = false;

          dungeon[j, i].group = dungeon[j, i - 1].group;
        }
      }

      //at least once for each group, add extentions going down
      if(j+1 < height)
      {
        int last = -1;
        for (int i = 0; i < width; ++i)
        {
          int current = dungeon[j, i].group;
          bool has = false;
          while (!has && current != last)
          {
            for (int k = 0; (k < width); ++k)
            {
              int choice = Random.Range((int)0, (int)yDense);
              if (choice == 1 && dungeon[j, k].group == current)
              {
                //extend the bottom
                dungeon[j, k].bottom = false;

                dungeon[j + 1, k] = new cell(true, true, false, true, current);

                has = true;

                last = current;
              }
            }
          }

        }
      }


    }
	}   


  void buildMap(float topLeftX, float topLeftZ, float hallSize, float height, float floor)	
  {
    float t = topLeftX;
    float r = topLeftZ;

        for (int j = 0; j < this.Height; ++j)
        {
            for (int i = 0; i < this.Width; ++i)
            {
                //left wall.
                if (dungeon[j, i].left)
                {
                    GameObject left = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    left.GetComponent<Transform>().position = new Vector3(topLeftX - hallSize / 2, floor + height / 2.0f - 0.001f, topLeftZ);
                    left.GetComponent<Transform>().localScale = new Vector3(0.001f, height, hallSize);
                    left.GetComponent<BoxCollider>().size = new Vector3(150.0f, left.GetComponent<BoxCollider>().size.y,
                                                  left.GetComponent<BoxCollider>().size.z);
                    Material newMat = Resources.Load("dungeonwalls") as Material;
                    left.GetComponent<Renderer>().material = newMat;
                }

                if (dungeon[j, i].right)
                {
                    GameObject right = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    right.GetComponent<Transform>().position = new Vector3(topLeftX + hallSize / 2, floor + height / 2.0f - 0.001f, topLeftZ);
                    right.GetComponent<Transform>().localScale = new Vector3(0.001f, height, hallSize);
                    right.GetComponent<BoxCollider>().size = new Vector3(150.0f, right.GetComponent<BoxCollider>().size.y,
                                                  right.GetComponent<BoxCollider>().size.z);
                    Material newMat = Resources.Load("dungeonwalls") as Material;
                    right.GetComponent<Renderer>().material = newMat;
                }

                if (dungeon[j, i].bottom)
                {
                    GameObject bottom = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bottom.GetComponent<Transform>().position = new Vector3(topLeftX, floor + height / 2.0f - 0.001f, topLeftZ - hallSize / 2);
                    bottom.GetComponent<Transform>().localScale = new Vector3(hallSize, height, 0.001f);
                    bottom.GetComponent<BoxCollider>().size = new Vector3(bottom.GetComponent<BoxCollider>().size.x,
                                              bottom.GetComponent<BoxCollider>().size.y, 150.0f);
                    Material newMat = Resources.Load("dungeonwalls") as Material;
                    bottom.GetComponent<Renderer>().material = newMat;
                }

                if (dungeon[j, i].top)
                {
                    GameObject top = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    top.GetComponent<Transform>().position = new Vector3(topLeftX, floor + height / 2.0f - 0.001f, topLeftZ + hallSize / 2);
                    top.GetComponent<Transform>().localScale = new Vector3(hallSize, height, 0.001f);
                    top.GetComponent<BoxCollider>().size = new Vector3(top.GetComponent<BoxCollider>().size.x,
                                                                  top.GetComponent<BoxCollider>().size.y, 150.0f);
                    Material newMat = Resources.Load("dungeonwalls") as Material;
                    top.GetComponent<Renderer>().material = newMat;
                }
                
                GameObject theFloor = GameObject.CreatePrimitive(PrimitiveType.Cube);
                theFloor.GetComponent<Transform>().position = new Vector3(topLeftX, floor, topLeftZ);
                theFloor.GetComponent<Transform>().localScale = new Vector3( hallSize, 0.001f, hallSize);
                Material newst = Resources.Load("dungeonfloor") as Material;
                theFloor.GetComponent<Renderer>().material = newst;

                topLeftX += hallSize;

            }
            topLeftZ -= hallSize;
            topLeftX = t;
        }

    }
}
