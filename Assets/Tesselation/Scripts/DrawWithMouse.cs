using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour {

	public Camera cam;
	public Shader shader;

	private RenderTexture _splatMap;
	private Material _snowMat, _drawMat;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		_drawMat = new Material(shader);
		_drawMat.SetVector("_Color", Color.red);

		_snowMat = GetComponent<MeshRenderer>().sharedMaterial;
		_splatMap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat);
		_snowMat.SetTexture("_Splat" ,_splatMap);
	}

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			RaycastHit _hit;

			if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out _hit))
			{
				_drawMat.SetVector("_Coordinate", new Vector4(_hit.textureCoord.x, _hit.textureCoord.y, 0, 0));
				RenderTexture tmp = RenderTexture.GetTemporary(_splatMap.width, _splatMap.height, 0, RenderTextureFormat.ARGBFloat);
				Graphics.Blit(_splatMap, tmp);
				Graphics.Blit(tmp, _splatMap, _drawMat);
				RenderTexture.ReleaseTemporary(tmp);
			}
		}
	}

	/// <summary>
	/// OnGUI is called for rendering and handling GUI events.
	/// This function can be called multiple times per frame (one call per event).
	/// </summary>
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, 256, 256), _splatMap, ScaleMode.ScaleToFit, false, 1);
	}
}
