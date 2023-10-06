using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MapGenerator : MonoBehaviour {
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float scale;
    [SerializeField] private float randomThreshold;

    private int[,] map;
    private int[,] borderedMap;
    
    private Vector3[,] positionMap;

    private int borderWidth = 5;

    private void Start() {
        GenerateMap();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            GenerateMap();
        }
    }

    private void GenerateMap() {
        map = new int[width, height];
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {

                if (i == 0 || i == width - 1 || j == 0 || j == height -1) {
                    map[i, j] = 1;
                } else {
                    int randomInt = Random.Range(0, 101);
                    map[i,j] = randomInt < randomThreshold ? 1 : 0;
                }
            }
        }

        borderedMap = new int[(width + 2 * borderWidth), (height + 2 * borderWidth)];
        for (int i = 0; i < width + 2 * borderWidth; i++) {
            for (int j = 0; j < height + 2 * borderWidth; j++) {

                if (i < borderWidth || i > width || j < borderWidth || j > height) {
                    borderedMap[i, j] = 1;
                } else {
                    borderedMap[i, j] = map[i-borderWidth, j-borderWidth];
                }
            }
        }

        positionMap = new Vector3[width+ 2*borderWidth, height + 2*borderWidth];
        for (int i = 0; i < width+2*borderWidth; i++) {
            for (int j = 0; j < height+2*borderWidth; j++) {
                positionMap[i,j] = new Vector3((-(width+2 * borderWidth) * scale / 2) + (i * scale) + (scale / 2), 0, (-(height+2 * borderWidth) * scale / 2) + (j * scale) + (scale / 2));
            }
        }

        SmoothMap();

        MeshGenerator meshGenerator = GetComponent<MeshGenerator>();
        meshGenerator.AssignSquares(width + 2 * borderWidth, height + 2 * borderWidth, positionMap, borderedMap);

        meshGenerator.GenerateMeshFromSquares();
    }

    private int GetNeighbourWallCount(int x,int y) {
        int count = 0;
        for (int i = x - 1; i <= x + 1; i++) {
            for (int j = y - 1; j <= y + 1; j++) {
                if (i == x && j == y) continue;
                if (i < 0 || i > (width + (2 * borderWidth)) - 1 || j < 0 || j > (height + (2 * borderWidth)) - 1) {
                    count++;
                    continue;
                }
                if (borderedMap[i,j] == 1) count++;
            }
        }
        return count;
    }

    private void SmoothMap() {
        for (int k = 0; k < 5; k++) {
            for (int i = 0; i < (width + (2 * borderWidth)); i++) {
                for (int j = 0; j < ((height + 2 * borderWidth)); j++) {
                    if (GetNeighbourWallCount(i, j) > 4) {
                        borderedMap[i,j] = 1;
                    } else if (GetNeighbourWallCount(i, j) < 4) {
                        borderedMap[i,j] = 0;
                    }
                }
            }
        }
    }


    private void OnDrawGizmos() {
        if (map != null) {
            /*
            for (int i = 0; i < width + 2*borderWidth; i++) {
                for (int j = 0; j < height + 2*borderWidth; j++) {
                    Gizmos.color = borderedMap[i, j] == 1 ? Color.black : Color.white;
                    Vector3 position = new Vector3((-(width+ 2*borderWidth) * scale / 2) + (i*scale) + (scale / 2), 0, (-(height + 2*borderWidth) * scale / 2) + (j*scale) + (scale / 2));
                    Gizmos.DrawCube(position, Vector3.one);
                }
            }
            */
        }
    }
}
