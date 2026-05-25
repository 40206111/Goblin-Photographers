using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MeshRenderer))]
public class PlayerColourComponent : NetworkBehaviour
{
    MeshRenderer _meshRenderer;

    [Networked, OnChangedRender(nameof(ColourChanged))] public Color NetworkedColour {  get; set; }


    public override void Spawned()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        
        if (HasStateAuthority)
        {
            NetworkedColour = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }

        ColourChanged();
    }


    private void Update()
    {
        if (!HasStateAuthority) return;
    }

    private void ColourChanged()
    {
        _meshRenderer.material.color = NetworkedColour;
    }

}
