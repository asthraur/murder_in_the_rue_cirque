using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject exteriorScene;
    public GameObject interiorScene;
    public GameObject frontInteriorScene;

    private AudioManager audioManager;

    public Material outlineMaterial;
    public Material defaultMaterial;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().material = outlineMaterial;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().material = defaultMaterial;
    }

    public void OnMouseDown()
    {
        audioManager.PlaySFX(audioManager.door);

        if (interiorScene.activeSelf == true){
            interiorScene.SetActive(false);
            frontInteriorScene.SetActive(false);
            exteriorScene.SetActive(true);
        }

        else if (exteriorScene.activeSelf == true)
        {
            exteriorScene.SetActive(false);
            interiorScene.SetActive(true);
            frontInteriorScene.SetActive(true);
        }

    }
}
