using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;
    public GameObject cube6;
    public GameObject cube7;
    public GameObject cube8;
    public GameObject cube9;

    private int[,] squares = new int[3,3];
    GameScript gameScript;
    // Use this for initialization
	void Start () {
        gameScript = FindObjectOfType<Camera>().GetComponent<GameScript>();
        squares[0, 0] = cube1.GetComponent<CubeScript>().value;
        squares[0, 1] = cube2.GetComponent<CubeScript>().value;
        squares[0, 2] = cube3.GetComponent<CubeScript>().value;
        squares[1, 0] = cube4.GetComponent<CubeScript>().value;
        squares[1, 1] = cube5.GetComponent<CubeScript>().value;
        squares[1, 2] = cube6.GetComponent<CubeScript>().value;
        squares[2, 0] = cube7.GetComponent<CubeScript>().value;
        squares[2, 1] = cube8.GetComponent<CubeScript>().value;
        squares[2, 2] = cube9.GetComponent<CubeScript>().value;
    }
	
	// Update is called once per frame
	void Update () {
        squares[0, 0] = cube1.GetComponent<CubeScript>().value;
        squares[0, 1] = cube2.GetComponent<CubeScript>().value;
        squares[0, 2] = cube3.GetComponent<CubeScript>().value;
        squares[1, 0] = cube4.GetComponent<CubeScript>().value;
        squares[1, 1] = cube5.GetComponent<CubeScript>().value;
        squares[1, 2] = cube6.GetComponent<CubeScript>().value;
        squares[2, 0] = cube7.GetComponent<CubeScript>().value;
        squares[2, 1] = cube8.GetComponent<CubeScript>().value;
        squares[2, 2] = cube9.GetComponent<CubeScript>().value;


        if (squares[0,0] == squares[0,1] && squares[0,1] == squares[0,2] && squares[0,0] != 0)
            gameScript.gameOver = true;
        else if(squares[1, 0] == squares[1, 1] && squares[1, 1] == squares[1, 2] && squares[1, 0] != 0)
            gameScript.gameOver = true;
        else if (squares[2, 0] == squares[2, 1] && squares[2, 1] == squares[2, 2] && squares[2, 0] != 0)
            gameScript.gameOver = true;
        else if (squares[0, 0] == squares[1, 0] && squares[1, 0] == squares[2, 0] && squares[0, 0] != 0)
            gameScript.gameOver = true;
        else if (squares[0, 1] == squares[1, 1] && squares[1, 1] == squares[2, 1] && squares[0, 1] != 0)
            gameScript.gameOver = true;
        else if (squares[0, 2] == squares[1, 2] && squares[1, 2] == squares[2, 2] && squares[0, 2] != 0)
            gameScript.gameOver = true;
        else if (squares[0, 0] == squares[1, 1] && squares[1, 1] == squares[2, 2] && squares[0, 0] != 0)
            gameScript.gameOver = true;
        else if (squares[0, 2] == squares[1, 1] && squares[1, 1] == squares[2, 0] && squares[0, 2] != 0)
            gameScript.gameOver = true;
    }
}
