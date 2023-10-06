using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {

    private Square[] squares;

    private List<Vector3> vertices;
    private List<int> triangles;

    private Mesh mesh;

    private void Awake() {
        vertices = new List<Vector3>();
        triangles = new List<int>();
    }

    public struct Square {
        public int configuration;
        public Vector3 topLeft , topRight, bottomLeft, bottomRight,centerLeft,centerTop,centerRight,centerBottom;

        public Square(Vector3 topLeft, Vector3 topRight, Vector3 bottomLeft, Vector3 bottomRight,int configuration) {
            this.topLeft = topLeft;
            this.topRight = topRight;
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;
            this.configuration = configuration;

            this.centerLeft = (topLeft + bottomLeft) / 2;
            this.centerTop = (topLeft + topRight) / 2;
            this.centerRight = (topRight + bottomRight) / 2;
            this.centerBottom = (bottomRight + bottomLeft) / 2;
        }
    }

    public void GenerateMeshFromSquares() {
        vertices.Clear();
        triangles.Clear();
        foreach (Square square in squares) {
            switch (square.configuration) {
                case 1:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    vertices.Add(square.centerLeft);
                    vertices.Add(square.centerBottom);
                    vertices.Add(square.bottomLeft);
                    break;
                case 2:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    vertices.Add(square.centerBottom);
                    vertices.Add(square.centerRight);
                    vertices.Add(square.bottomRight);
                    break;
                case 3:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 3);
                    vertices.Add(square.centerLeft);
                    vertices.Add(square.centerRight);
                    vertices.Add(square.bottomRight);
                    vertices.Add(square.bottomLeft);
                    break;
                case 4:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    vertices.Add(square.centerTop);
                    vertices.Add(square.topRight);
                    vertices.Add(square.centerRight);
                    break;
                case 5:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 3);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 3);
                    triangles.Add(vertices.Count + 4);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 4);
                    triangles.Add(vertices.Count + 5);
                    vertices.Add(square.bottomLeft);
                    vertices.Add(square.centerLeft);
                    vertices.Add(square.centerTop);
                    vertices.Add(square.topRight);
                    vertices.Add(square.centerRight);
                    vertices.Add(square.centerBottom);
                    break;
                case 6:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 3);
                    vertices.Add(square.centerTop);
                    vertices.Add(square.topRight);
                    vertices.Add(square.bottomRight);
                    vertices.Add(square.centerBottom);
                    break;
                case 7:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 3);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 3);
                    triangles.Add(vertices.Count + 4);
                    vertices.Add(square.bottomRight);
                    vertices.Add(square.bottomLeft);
                    vertices.Add(square.centerLeft);
                    vertices.Add(square.centerTop);
                    vertices.Add(square.topRight);
                    break;
                case 8:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    vertices.Add(square.centerLeft);
                    vertices.Add(square.topLeft);
                    vertices.Add(square.centerTop);
                    break;
                case 9:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 3);
                    vertices.Add(square.topLeft);
                    vertices.Add(square.centerTop);
                    vertices.Add(square.centerBottom);
                    vertices.Add(square.bottomLeft);
                    break;
                case 10:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 3);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 3);
                    triangles.Add(vertices.Count + 4);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 4);
                    triangles.Add(vertices.Count + 5);
                    vertices.Add(square.topLeft);
                    vertices.Add(square.centerTop);
                    vertices.Add(square.centerRight);
                    vertices.Add(square.bottomRight);
                    vertices.Add(square.centerBottom);
                    vertices.Add(square.centerLeft);
                    break;
                case 11:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 3);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 3);
                    triangles.Add(vertices.Count + 4);
                    vertices.Add(square.bottomLeft);
                    vertices.Add(square.topLeft);
                    vertices.Add(square.centerTop);
                    vertices.Add(square.centerRight);
                    vertices.Add(square.bottomRight);
                    break;
                case 12:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 3);
                    vertices.Add(square.topLeft);
                    vertices.Add(square.topRight);
                    vertices.Add(square.centerRight);
                    vertices.Add(square.centerLeft);
                    break;
                case 13:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 3);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 3);
                    triangles.Add(vertices.Count + 4);
                    vertices.Add(square.topLeft);
                    vertices.Add(square.topRight);
                    vertices.Add(square.centerRight);
                    vertices.Add(square.centerBottom);
                    vertices.Add(square.bottomLeft);
                    break;
                case 14:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 3);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 3);
                    triangles.Add(vertices.Count + 4);
                    vertices.Add(square.topRight);
                    vertices.Add(square.bottomRight);
                    vertices.Add(square.centerBottom);
                    vertices.Add(square.centerLeft);
                    vertices.Add(square.topLeft);
                    break;
                case 15:
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 1);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 0);
                    triangles.Add(vertices.Count + 2);
                    triangles.Add(vertices.Count + 3);
                    vertices.Add(square.topLeft);
                    vertices.Add(square.topRight);
                    vertices.Add(square.bottomRight);
                    vertices.Add(square.bottomLeft);
                    break;
            }
        }

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }

    private int GetConfiguration(int a,int b,int c,int d) {
        return a * 8 + b * 4 + c * 2 + d;
    }

    public void AssignSquares(int width,int height, Vector3[,] positionMap, int[,] map) {
        squares = new Square[(width-1)*(height-1)];
        for (int i = 0; i < squares.Length; i++) {
            squares[i] = new Square(positionMap[0 + i% (width - 1), 1+i/(width-1)], positionMap[1 + i % (width - 1), 1+ i / (width - 1)], positionMap[0 + i % (width - 1), 0+ i / (width - 1)], positionMap[1 + i % (width - 1), 0+ i / (width - 1)], GetConfiguration(map[0 + i % (width - 1), 1+ i / (width - 1)], map[1 + i % (width - 1), 1 + i / (width - 1)], map[1 + i % (width - 1), 0+ i / (width - 1)], map[0 + i % (width - 1), 0+ i / (width - 1)]));

            //Debug.Log(i.ToString() + " " + squares[i].configuration.ToString());
        }
    }

    private void OnDrawGizmos() {
        if (squares != null) {
            /*
            foreach (Square square in squares) {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(square.topLeft, Vector3.one * .4f);
                Gizmos.DrawCube(square.topRight, Vector3.one * .4f);
                Gizmos.DrawCube(square.bottomLeft, Vector3.one * .4f);
                Gizmos.DrawCube(square.bottomRight, Vector3.one * .4f);
            }
            */
        }
    }
}
