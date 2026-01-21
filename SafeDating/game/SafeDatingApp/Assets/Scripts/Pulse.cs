using UnityEngine;

public class Pulse : MonoBehaviour
{
    public Material[] emissions;
    public float pulseRange;
    public float pulseSpeed = 1f;
    public GameObject character; 

    private Material[] defaultMaterials;
    private Renderer renderer;
    private bool isAnswered = false;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultMaterials = renderer.materials;
        pulseRange = Camera.main.farClipPlane;
        character = GameObject.FindGameObjectWithTag("Player");
        SetEmission();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, character.transform.position) < pulseRange && !isAnswered)
        {
            for(int i = 0; i < renderer.materials.Length; i++){
                renderer.materials[i].SetColor("_EmissionColor", Color.Lerp(Color.black, emissions[i].GetColor("_EmissionColor"), Mathf.PingPong(Time.time * pulseSpeed, 1)));
            }
        }
        else
        {
            if(renderer.materials[0] != defaultMaterials[0]){
                SetDefaultMaterial();
            }
        }
    }

    public void TurnOnPulse()
    {
        isAnswered = false;
        SetEmission();
    }

    public void TurnOffPulse()
    {
        isAnswered = true;
    }

    public void SetEmission(){
        Material[] temp = new Material[renderer.materials.Length];
        for(int i = 0; i < renderer.materials.Length; i++){
            temp[i] = emissions[i];
        }
        renderer.materials = temp;
    }

    private void SetDefaultMaterial(){
        for(int i = 0; i < renderer.materials.Length; i++){
            renderer.materials = defaultMaterials;
        }
    }
}
