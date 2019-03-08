Shader "Custom/Darkness Surface Shader"
{
    Properties
    {
        _cameraSize ("Camera Size", Float) = 8.0
        _playerLightInnerRadius ("Player Light Inner Radius", Float) = 0.25
        _playerLightOuterRadius ("Player Light Outer Radius", Float) = 0.5
        _bonfireLightInnerRadius ("Bonfire Light Inner Radius", Float) = 1.0
        _bonfireLightOuterRadius ("Bonfire Light Outer Radius", Float) = 1.75
        _playerPosition ("Player Position", Vector) = (0,4,0,0)
        _bonfirePosition ("Bonfire Position", Vector) = (4,-4,0,0)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 0

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        struct Input
        {
            float4 screenPos;
        };
        
        float _cameraSize;
        float _playerLightInnerRadius;
        float _playerLightOuterRadius;
        float _bonfireLightInnerRadius;
        float _bonfireLightOuterRadius;
        float4 _playerPosition;
        float4 _bonfirePosition;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = fixed4(0.0, 0.0, 0.0, 1.0);
            
            half distanceFromPlayer = distance(IN.screenPos.xy, _playerPosition.xy) / _cameraSize;
            half distanceFromBonfire = distance(IN.screenPos.xy, _bonfirePosition.xy) / _cameraSize;
            
            half alphaPlayer = smoothstep(_playerLightInnerRadius, _playerLightOuterRadius, distanceFromPlayer);
            half alphaBonfire = smoothstep(_bonfireLightInnerRadius, _bonfireLightOuterRadius, distanceFromBonfire);
            
            o.Albedo = c.rgb;
            o.Metallic = 0.0;
            o.Smoothness = 0.5;
            o.Alpha = alphaPlayer * alphaBonfire;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
