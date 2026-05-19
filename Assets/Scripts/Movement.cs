using UnityEngine.InputSystem;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
   [SerializeField] InputAction thrust;
   [SerializeField] InputAction rotate;
   [SerializeField] float thrustPower = 5f;
   [SerializeField] AudioClip mainEngineSound;
   
   Rigidbody rb;

   AudioSource audioSource;

   private void Start() 
   {
       rb = GetComponent<Rigidbody>(); 
       audioSource = GetComponent<AudioSource>();
   }
   private void OnEnable() 
   {
        thrust.Enable();
        rotate.Enable();
   }



   private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotate();

    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * Time.fixedDeltaTime * thrustPower * 100);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngineSound);
            }
                
            
        }
        else
            {
                audioSource.Stop();
            }
    }

    private void ProcessRotate()
    {
        float rotateInput = rotate.ReadValue<float>();
        if(rotateInput < 0){
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward*Time.fixedDeltaTime*100);
            rb.freezeRotation = false;
        }
        else if(rotateInput > 0){
            rb.freezeRotation = true;
            transform.Rotate(Vector3.back*Time.fixedDeltaTime*100);
            rb.freezeRotation = false;
        }
    }
}
