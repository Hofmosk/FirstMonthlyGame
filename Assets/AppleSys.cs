using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSys : MonoBehaviour
{
    public PlayerC playerC;
    
    public int grow = 0;
    private Vector3 ApplePos;
    private float Cooldown = 1f;
    private bool eat;
    public int score=0;
    private int Speedup = 0;

    private Vector3 CanIGo;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = (new Vector3(Random.Range(-17, 17),0.5f ,Random.Range(-15, 15)));
        eat = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        ApplePos = transform.position;
        
        CanIGo = (new Vector3(Random.Range(-17, 17),0.5f ,Random.Range(-15, 15)));
        
        if(playerC.transform.position == ApplePos)
        {
            if(Cooldown <= 0)
            {
                playerC.snakeSize ++;
                score ++;
                Speedup ++;
                eat = true;
                Cooldown = playerC.Speed * 0.3f;
                
            }
        }
        Cooldown = Cooldown - (1f * Time.deltaTime);
        
        if(eat == true)
        {
                      
            if(CanIGo != ApplePos && GameObject.FindWithTag("Body").transform.position != ApplePos)
            {
                transform.position = CanIGo;
                eat = false;
            }
            
        }

        if(Speedup == 5)
        {
            playerC.Speed = playerC.Speed * 0.90f;
            Speedup = 0;
        }
        
    }

}
