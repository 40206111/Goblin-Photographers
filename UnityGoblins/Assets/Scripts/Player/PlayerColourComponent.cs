using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MeshRenderer))]
public class PlayerColourComponent : NetworkBehaviour
{
    MeshRenderer _meshRenderer;
    InputAction _attackAction;

    [Networked, OnChangedRender(nameof(ColourChanged))] Color NetworkedColour {  get; set; }


    public override void Spawned()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        if (!HasStateAuthority) return;

        _attackAction = InputSystem.actions.FindAction("Use");
    }


    private void Update()
    {
        if (!HasStateAuthority) return;

        var attackValue = _attackAction.ReadValue<float>();
        if (attackValue > 0)
        {
            NetworkedColour = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }
    }

    private void ColourChanged()
    {
        _meshRenderer.material.color = NetworkedColour;
    }

}
