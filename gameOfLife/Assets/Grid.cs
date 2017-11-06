using System.Collections;
using UnityEngine;

public class Grid : MonoBehaviour
{

    [SerializeField]
    public int x;
    public int y;

    public GameObject[,] gridArray;

    public GameObject cube;
    public CubesColor cubeColor;
    private int aliveNeighbours;
    private bool on;

    void Start ()
    {
        x += 1;
        y += 1;
        gridArray = new GameObject[x, y];

        for (int j = 1; j < x; j++)
        {
            for (int i = 1; i < y; i++)
            {
                gridArray[i, j] = (GameObject)Instantiate(cube, new Vector2(i + i/100f, j + j/100f), Quaternion.identity);
                gridArray[i, j].name = "Pos " + i + ", " + j;
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            on = !on;
            StartCoroutine(Iterate());
        }
       
    }

    private IEnumerator Iterate()
    {
        while (on)
        {
            for (int i = 1; i < x; i++)
            {
                for (int j = 1; j < y; j++)
                {
                    aliveNeighbours = GetAliveNeighbourCount(i, j);
                    if (aliveNeighbours == 3)
                    {
                        gridArray[i, j].GetComponent<CubesColor>().aboutActive = true;//life
                    }
                    else if (aliveNeighbours != 2)
                    {
                        gridArray[i, j].GetComponent<CubesColor>().aboutActive = false;//death
                    }
                }
            }
            for (int i = 1; i < x; i++)
            {
                for (int j = 1; j < y; j++)
                {
                    gridArray[i, j].GetComponent<CubesColor>().SetReady();
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

    int GetAliveNeighbourCount(int xIndex, int yIndex)
    {
        int aliveNeighbours = 0;
        for (int g = -1; g <= 1; g++)
        {
            if(g == -1 && xIndex == 1) { continue; }
            if(g == 1 && xIndex == (x-1)) { continue; }
            for (int h = -1; h <= 1; h++)
            {
                if (h == -1 && yIndex == 1) { continue; }
                if (h == 1 && yIndex == (y-1)) { continue; }
                if (g == 0 && h == 0) { continue; }

                if (gridArray[xIndex + g, yIndex + h].GetComponent<CubesColor>().active)
                {
                    aliveNeighbours += 1;
                }
            }
        }
        return aliveNeighbours;
    }
}
