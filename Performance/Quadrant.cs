using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Quadrant : MonoBehaviour
{
    public Vector3 Center { get; private set; }
    public float Width { get; private set; }
    public float Height { get; private set; }

    private Quadrant[] children = new Quadrant[4];
    private Citizen[] citizens = new Citizen[MAX_CAP];

    [SerializeField] private Vector2 mapSize = new Vector2();

    private static bool initializedQuads = false;

    private const int MAX_CAP = 6; //max citizens per quad

    private void Start()
    {
        if (!initializedQuads) 
        {
            initializedQuads = true;

            float xSize = mapSize.x / 4;
            float zSize = mapSize.y / 4;

            for (int x= 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    Vector3 pos = new Vector3(xSize * (x+1), 0, zSize * (y+1));

                    Quadrant quad;

                    if (x == 0 && y == 0)
                    {
                        quad = this;
                        name = "Quad x0y0";
                    }
                    else
                        quad = new GameObject($"Quad x{x} y{y}").AddComponent<Quadrant>();

                    quad.InitQuadrant(pos, xSize, zSize);
                }                
            }
        }
    }

    internal void InitQuadrant(Vector3 center, float width, float height) 
    {
        transform.position = center;
        Center = center;
        Width = width;
        Height = height;
    }

    public bool CanInsertCitizen() 
    {
        for (int i = 0; i < citizens.Length; i++)
        {
            if (citizens[i] == null)
                return true;
        }
        return false;
    }

    public bool Insert(Citizen citizen)
    {
        for (int i = 0; i < citizens.Length; i++)
        {
            if (citizens[i] == null)
            {
                citizens[i] = citizen;
                return true;
            }
        }
        return false;
    }

    public bool Remove(Citizen citizen)
    {
        for (int i = 0; i < citizens.Length; i++)
        {
            if (citizens[i] == citizen)
            {
                citizens[i] = null;
                return true;
            }
        }
        return false;
    }

    public Citizen[] QueryRange(Vector2 position, float range)
    {
        // TODO: Find all citizens within range of the given position
        return null;
    }

    public void UpdatePosition(Citizen citizen)
    {
        // TODO: Move the citizen to the appropriate quadrant(s) based on its new position
    }

    private bool Contains(Vector3 position)
    {
        float halfWidth = Width / 2;
        float halfHeight = Height / 2;
        return ((position.x >= Center.x - halfWidth) && (position.x <= Center.x + halfWidth)) && ((position.z >= Center.z - halfHeight) && (position.z <= Center.z + halfHeight));
        
    }

    private void Subdivide()
    {
        // TODO: Create four children quadrants and redistribute citizens to appropriate quadrants
    }
}

