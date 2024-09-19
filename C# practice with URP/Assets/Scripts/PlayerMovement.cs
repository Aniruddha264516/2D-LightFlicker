
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
 
    private float movement;

    private Animator anim;


   
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
        
        if(movement > 0.1f && Input.GetKey(KeyCode.D) )
        {
                Vector3 currentScale = transform.localScale;
            transform.localScale = new Vector3(Mathf.Abs(currentScale.x), currentScale.y, currentScale.z);
            transform.position +=  new Vector3(movement, 0, 0) * speed * Time.deltaTime;
        }

        else if(movement < -0.1f && Input.GetKey(KeyCode.A))
        {
            Vector3 currentScale = transform.localScale;
            transform.localScale = new Vector3(-Mathf.Abs(currentScale.x), currentScale.y, currentScale.z);
            transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;
        }

        anim.SetBool("Running" , movement != 0);
    }
}
