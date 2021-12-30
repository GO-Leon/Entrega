using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessModifier : MonoBehaviour
{
    private PostProcessVolume volume;
    private Bloom _bloom;
    [SerializeField] private float bloomIntensity;
    // Start is called before the first frame update
    void Awake()
    {
        volume = GetComponent<PostProcessVolume>();
    }
    void Start()
    {
        volume.profile.TryGetSettings(out _bloom);
        _bloom.intensity.value = bloomIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
