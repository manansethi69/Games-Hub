using UnityEngine;

public class BuildingHighlight : MonoBehaviour
{
    public float interactDistance = 3f;
    public Material highlightedMaterial;
    private Material originalMaterial;
    private Renderer buildingRenderer;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        buildingRenderer = GetComponent<Renderer>();
        originalMaterial = buildingRenderer.material;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < interactDistance)
        {
            buildingRenderer.material = highlightedMaterial;
        }
        else
        {
            buildingRenderer.material = originalMaterial;
        }
    }
}

