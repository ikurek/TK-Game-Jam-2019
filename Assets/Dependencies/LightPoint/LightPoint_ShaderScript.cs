using UnityEngine;

    public class LightPoint_ShaderScript : MonoBehaviour
    {

        [SerializeField] Material material;

        public Transform target;
        public Transform target2;
        public float size = -1f;//Bigger if more on negative
    public float size1 = 0.38f;
    public float size2 = 0.11f;
        
//        [SerializeField] private float timeScale;
//        [SerializeField] private float transformTimeScale = 0.05f;
//        [SerializeField] private float transformScale = 0.5f;
        
        // Start is called before the first frame update
        void Start()
        {
//            if(material.HasProperty("Vector1_E3E22DBC"))
//                material.SetFloat("Vector1_E3E22DBC", timeScale);            
//            
//            if(material.HasProperty("Vector2_5B8641B"))
//                material.SetFloat("Vector2_5B8641B", transformScale);
//            
//            if(material.HasProperty("Vector1_A435599C"))
//                material.SetFloat("Vector1_A435599C", transformTimeScale);
        }

        public void setSizeOfPointLight(float new_size)
        {
            size = new_size;
        }
        
        // Update is called once per frame
        void Update()
        {
        if (material.HasProperty("Vector2_5FF431E9"))
            material.SetVector("Vector2_5FF431E9", target2.position);

        if (material.HasProperty("Vector2_3E6974E6"))
            material.SetVector("Vector2_3E6974E6", target.position);

        if (material.HasProperty("Vector1_DECBA3D6"))
                material.SetFloat("Vector1_DECBA3D6", size);

        if (material.HasProperty("Vector1_11A619D5"))
            material.SetFloat("Vector1_11A619D5", size1);

        if (material.HasProperty("Vector1_40D93AA6"))
            material.SetFloat("Vector1_40D93AA6", size2);
    }
    }
