using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerC : MonoBehaviour
{
    public AppleSys appleSys;
    Collider m_ObjectCollider;

    private int XMAX = 18;
    private int XMIN = -18;
    private int ZMAX = 16;
    private int ZMIN = -16;
    
    private bool haut = false;
    private bool droite = false;
    private bool bas = false;
    private bool gauche = false;

    public float Speed = 0.2f;

    
    public float TimeSpeed;

    public int snakeSize;

    public GameObject body;
    public List<GameObject> snakeMovePos;
    public List<Vector3> allBodyPos;
    public Vector3 ConcurrentPos;

    private float StartDelay = 3f;
    private bool GameOver = false;

    public GameObject uigameover;


    void Start()
    {
        uigameover.SetActive(false);
        m_ObjectCollider = GetComponent<Collider> ();
        m_ObjectCollider.isTrigger = false;
        if(StartDelay <= 0)
        {
            
            m_ObjectCollider.isTrigger = true;
        }
        
        haut = true;
        TimeSpeed = 0.2f;
        snakeSize = 3;
    
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x <XMIN || transform.position.x >XMAX || transform.position.z <ZMIN || transform.position.z > ZMAX)
        {
            Debug.Log("Game Over screen");
            
            GameOver = true;
        }
        

        StartDelay = StartDelay - 1*Time.deltaTime;
        
        
        //Gestion déplacement
        if(haut == true)
        {
        
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Rotate(eulers:new Vector3(0, -90, 0));
                gauche = true;
                haut = false;
            }

            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Rotate(eulers:new Vector3(0, 90, 0));
                droite = true;
                haut = false;
                
            }

        }

        if(bas == true)
        {
        
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Rotate(eulers:new Vector3(0, 90, 0));
                gauche = true;
                bas = false;
            }

            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Rotate(eulers:new Vector3(0, -90, 0));
                droite = true;
                bas = false;
            }

        }

        if(droite == true)
        {

            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Rotate(eulers:new Vector3(0, -90, 0));
                haut = true;
                droite = false;
                
            }

            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.Rotate(eulers:new Vector3(0, 90, 0));
                bas = true;
                droite = false;
                
            }

        }

        if(gauche == true)
        {

            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Rotate(eulers:new Vector3(0, 90, 0));
                haut = true;
                gauche = false;
                
            }

            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.Rotate(eulers:new Vector3(0, -90, 0));
                bas = true;
                gauche = false;
                
            }

        }

        if (transform.position == GameObject.FindWithTag("Body").transform.position)
        {
            Debug.Log("Game Over collision!");
        }

        


        if(Input.GetKeyDown(KeyCode.Space))
        {

            Speed = Speed * 0.5f;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {

            Speed = Speed * 2f;
        }
        
        
        
        
        if (TimeSpeed > 0)
        {
            TimeSpeed = TimeSpeed - 1f*Time.deltaTime;
            ConcurrentPos = transform.position;
            
        }
        
        if(TimeSpeed <= 0)
        {
            
            transform.Translate(Vector3.forward);
            var bodypos = Instantiate(body,ConcurrentPos, Quaternion.identity);
            bodypos.gameObject.tag = "Body";

            allBodyPos.Add(ConcurrentPos);
            snakeMovePos.Add(bodypos);
           
            if(snakeMovePos.Count > snakeSize)
            {
                
                Destroy(snakeMovePos[0]);
                snakeMovePos.Remove(snakeMovePos[0]);
                allBodyPos.Remove(allBodyPos[0]);
            }

            TimeSpeed = Speed;
            
            
        }   
    
        for(int i = 0; i < allBodyPos.Count; i++)
        {
            if(transform.position == allBodyPos[i])
            {
                Debug.Log("Game Over allbody!");
                GameOver = true;
            }
            if(allBodyPos.Count == i)
            {
                i = 0;
            }
        }


        if(GameOver == true)
        {
            uigameover.SetActive(true);
            Speed = 1000000f;
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game Over trigger!");
    }
}
