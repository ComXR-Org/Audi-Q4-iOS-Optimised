using UnityEngine;
using System.Collections;
using UnityEngine.XR;
using UnityEngine.UI;
//using UnityEngine.Rendering.PostProcessing;
namespace VRStandardAssets.Examples
{
    public class ExampleRenderScale : MonoBehaviour
    {
        
        [SerializeField] private float m_RenderScale = 1f;
        //PostProcessLayer ppl;
        //The render scale. Higher numbers = better quality, but trades performance

   

        void Start()
        {
            XRSettings.eyeTextureResolutionScale = m_RenderScale;
            //ppl = GetComponent<PostProcessLayer>();

            
        }
        public void SetFXAA()
        {
            //ppl.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
        }
        public void SetAAToNone()
        {
            //ppl.antialiasingMode = PostProcessLayer.Antialiasing.None;
        }
        public void SetTXAA()
        {
            //ppl.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
        }
        public void SetRenderScale(float quality)
        {
            m_RenderScale = quality;
            XRSettings.eyeTextureResolutionScale = m_RenderScale;
        }
        public  void IncRenderScale()
        {
            m_RenderScale += 0.025f;
            XRSettings.eyeTextureResolutionScale = m_RenderScale;
        }
       public void DecRenderScale()
        {
            m_RenderScale -= 0.025f;
            XRSettings.eyeTextureResolutionScale = m_RenderScale;
        }
        public float GetEyeTRScale()
        {
            return m_RenderScale;
        }


    }
}