using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Portal
{
    [CreateAssetMenu(fileName = "PortalHelper", menuName = "Custom/PortalHelper")]
    public class PortalHelper : ScriptableObject
    {
        public Material originMaterial;
        [HideInInspector]public Transform player;
        [HideInInspector]public Transform cameraPlayer;

        private Stack<Material> _materialsPool;
        private Stack<RenderTexture> _renderTexturePool;

        private void OnEnable()
        {
            _materialsPool = new Stack<Material>();
            _renderTexturePool = new Stack<RenderTexture>();
            SceneManager.activeSceneChanged += ClearPools;
        }

        public Material GetMaterial()
        {
            if (_materialsPool.Count < 1)
            {
                return (new Material(originMaterial));
            }
            else
                return _materialsPool.Pop();
        }

        public RenderTexture GetRenderTexture()
        {
            if(_renderTexturePool.Count < 1)
            {
                return (new RenderTexture(Screen.width, Screen.height, 24));
            }
            else
            {
                RenderTexture tmp = _renderTexturePool.Pop();
                tmp.Create();
                return tmp;
            }
            
        }

        public void ReturnMaterial(Material material)
        {
            _materialsPool.Push(material);
        }

        public void ReturnRenderTexture(RenderTexture rTexture)
        {
            rTexture.Release();
            _renderTexturePool.Push(rTexture);
        }

        public void ClearPools(Scene s, Scene s1)
        {
            Debug.Log("Active scene changed, clearing pools");

            RenderTexture tmp;

            while (_materialsPool.Count > 0)
            {
                Destroy(_materialsPool.Pop());
            }
            while (_renderTexturePool.Count > 0)
            {
                tmp =_renderTexturePool.Pop();
                tmp.Release();
                Destroy(tmp);
            }
        }
    }
}

