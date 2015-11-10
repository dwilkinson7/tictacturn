using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{

    private int playerturn;
    private Ray ray;
    private RaycastHit rch;
    private MeshRenderer mRend;
    private Material x_mat;
    private Material o_mat;
    private Material d_mat;
    private Material[] tempmats;
    private CubeScript cubeScript;
    public bool gameOver;
    public Text victoryRedText;
    public Text victoryBlueText;
    public string state;
    private float moved;
    private float moveAmount;
    public ParticleSystem clickParticles;

    // Use this for initialization
    void Start()
    {
        moveAmount = 89;
        moved = 0;
        gameOver = false;
        playerturn = 1;
        d_mat = Resources.Load("Models/Materials/TicTacTurnBlankUVMap") as Material;
        x_mat = Resources.Load("Models/Materials/TicTacTurnSquareUVMapCross") as Material;
        o_mat = Resources.Load("Models/Materials/TicTacTurnSquareUVMapO's") as Material;
        victoryRedText.enabled = false;
        victoryBlueText.enabled = false;
        state = "stand";
        clickParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            if (playerturn == 1)
                victoryRedText.enabled = true;
            else
                victoryBlueText.enabled = true;
        }
        if (gameOver == false)
        {
            if (Input.GetMouseButtonUp(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out rch, 100))
                {
                    mRend = rch.transform.gameObject.GetComponent<MeshRenderer>();
                    clickParticles.Stop();
                    
                    if (mRend.material.name.Equals("TicTacTurnBlankUVMap (Instance)"))
                    {
                       
                        if (playerturn == 1)
                        {
                            tempmats = mRend.materials;
                            tempmats.SetValue(x_mat, 0);
                            tempmats.SetValue(x_mat, 1);
                            tempmats.SetValue(x_mat, 2);
                            tempmats.SetValue(x_mat, 3);
                            mRend.materials = tempmats;
                            cubeScript = rch.transform.gameObject.GetComponent<CubeScript>();
                            clickParticles.transform.position = rch.transform.gameObject.transform.position;
                            clickParticles.Play();
                            cubeScript.value = 1;
                            playerturn = 2;
                        }
                        else if (playerturn == 2)
                        {
                            tempmats = mRend.materials;
                            tempmats.SetValue(o_mat, 0);
                            tempmats.SetValue(o_mat, 1);
                            tempmats.SetValue(o_mat, 2);
                            tempmats.SetValue(o_mat, 3);
                            mRend.materials = tempmats;
                            cubeScript = rch.transform.gameObject.GetComponent<CubeScript>();
                            clickParticles.transform.position = rch.transform.gameObject.transform.position;
                            clickParticles.Play();
                            cubeScript.value = 2;
                            playerturn = 1;
                        }
                    }
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && state.Equals("stand"))
            state = "left";
        else if (Input.GetKeyDown(KeyCode.RightArrow) && state.Equals("stand"))
            state = "right";
        else if (Input.GetKeyDown(KeyCode.UpArrow) && state.Equals("stand"))
            state = "up";
        else if (Input.GetKeyDown(KeyCode.DownArrow) && state.Equals("stand"))
            state = "down";
    }

    public void FixedUpdate()
    {
        if (state.Equals("left"))
        {
            if (moved < moveAmount)
            {
                this.transform.RotateAround(Vector3.zero,
                    this.transform.up, 60.0f * Time.deltaTime);
                moved += (60.0f * Time.deltaTime);
            }
            else
            {
                state = "stand";
                moved = 0;
            }
            
        }
        if (state.Equals("right"))
        {
            if (moved < moveAmount)
            {
                this.transform.RotateAround(Vector3.zero,
                    this.transform.up, -60.0f * Time.deltaTime);
                moved += (60.0f * Time.deltaTime);
            }
            else
            {
                state = "stand";
                moved = 0;
            }

        }
        if (state.Equals("up"))
        {
            if (moved < moveAmount)
            {
                this.transform.RotateAround(Vector3.zero,
                    this.transform.right, 60.0f * Time.deltaTime);
                moved += (60.0f * Time.deltaTime);
            }
            else
            {
                state = "stand";
                moved = 0;
            }

        }
        if (state.Equals("down"))
        {
            if (moved < moveAmount)
            {
                this.transform.RotateAround(Vector3.zero,
                    this.transform.right, -60.0f * Time.deltaTime);
                moved += (60.0f * Time.deltaTime);
            }
            else
            {
                state = "stand";
                moved = 0;
            }

        }
    }
}
