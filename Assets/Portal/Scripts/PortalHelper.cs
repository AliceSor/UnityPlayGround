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
        public List<PortalConnection> connections;
        [HideInInspector]public Transform player;
        [HideInInspector]public Transform cameraPlayer;

        private Stack<Material> _materialsPool;
        private Stack<RenderTexture> _renderTexturePool;

        private void OnEnable()
        {
            _materialsPool = new Stack<Material>();
            _renderTexturePool = new Stack<RenderTexture>();
            connections = new List<PortalConnection>();
            SceneManager.activeSceneChanged += ClearPools;
        }
        #region Registartion

        /// <summary>
        /// Add portal to list of portal pairs.
        /// Return false if slot of portal already occupied
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newPortal"></param>
        /// <returns></returns>
        public bool RegisterPortal(string id, Portal newPortal)
        {
            foreach (PortalConnection i in connections)
            {
                if (i.id == id)
                {
                    return (i.Register(newPortal));
                }
            }
            PortalConnection con = new PortalConnection(id);
            connections.Add(con);
            return con.Register(newPortal);
        }

        public Portal GetSecondPortal(Portal portal)
        {
            foreach (PortalConnection i in connections)
            {
                if (i.id == portal.id)
                {
                    return (portal.type == PortalType.A ? i.portalB : i.portalA);
                }
            }
            return null;
        }

        #endregion

        #region Pool
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
        #endregion
    }

    [System.Serializable]
    public class PortalConnection
    {
        public Portal portalA;
        public Portal portalB;
        public string id;

        public PortalConnection(string id)
        {
            this.id = id;
        }

        public bool Register(Portal portal)
        {
            if (portal.type == PortalType.A)
            {
                if (portalA == null)
                    portalA = portal;
                else
                    return false;
            }
            else
            {
                if (portalB == null)
                    portalB = portal;
                else
                    return false;
            }
            return true;
        }
    }
}

