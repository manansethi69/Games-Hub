using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject tipbox;
    private CinemachineFollowZoom cinemachineFollowZoom;
    private bool panComplete = false;
    public LayerMask camOcculusion;
    private float distanceMin = 3.5f;
    private float distanceMax = 13f;
    private SkinnedMeshRenderer playerMesh; 
    private Shader maskShader;
    private Shader standardShader;

    void Awake()
    {
        maskShader = Resources.Load<Shader>("Shaders/SimpleMask");
        standardShader = Shader.Find("Standard");
    }
    void Start()
    {
        cinemachineFollowZoom = GetComponent<CinemachineFollowZoom>();
        playerMesh = target.GetComponentInChildren<SkinnedMeshRenderer>();
        cinemachineFollowZoom.m_Width = 7.25f; // Initial Zoom Variable

    }

    void Update()
    {
        if (target && panComplete)
        {
            ChangeZoom();
            OccludeRay();
        }
    }
    private void ChangeZoom()
    {
        cinemachineFollowZoom.m_Width = Mathf.Clamp(cinemachineFollowZoom.m_Width - Input.GetAxis("Mouse ScrollWheel") * 10.0f, distanceMin, distanceMax); 
    }
    private void OccludeRay()
    {
        RaycastHit wallHit = new RaycastHit();
        if (Physics.Linecast((Vector3.up * 0.25f) + target.position, transform.position, out wallHit, camOcculusion))
        {   
            Debug.Log("Ray has hit");
            Debug.DrawLine((Vector3.up * 0.25f) + target.position, transform.position, Color.red, 0.25f);
            foreach(Material material in playerMesh.materials)
            {
                material.shader = maskShader;
            }
        }
        else
        {
            foreach(Material material in playerMesh.materials)
            {
                if(material.shader != standardShader)
                    material.shader = standardShader;
            }
        }
    }
    private void PanComplete()
    {
        panComplete = true;
        tipbox.SetActive(true);
    }
}
