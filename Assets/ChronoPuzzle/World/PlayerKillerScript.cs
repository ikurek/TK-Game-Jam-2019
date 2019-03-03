using UnityEngine;

namespace ChronoPuzzle.World {

    public class PlayerKillerScript : MonoBehaviour
    {

        [SerializeField] private Transform PlayerTransform;
        [HideInInspector] public bool IsDead = false;
        [HideInInspector] private bool kill = false;
        private float startKillingTime;
        [SerializeField]  private float speed;
        private float delayTime = 2.0f;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (IsDead)
            {
                startKillingTime = Time.time + delayTime;
                kill = true;
                IsDead = false;
            }

            if(kill && Time.time > startKillingTime)
            { 
                transform.position = new Vector3(PlayerTransform.position.x, Mathf.Lerp(transform.position.y, PlayerTransform.position.y, Time.deltaTime * speed), transform.position.z);
            }
        
        }
    }

}
