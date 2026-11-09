using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControlSettingsSo", menuName = "My Menu/PlayerControlSettingsSo")]
public class PlayerControlSettingsSo : ScriptableObject
{

    [Header("Movement")]
    [Range(1f,10f)]
    [Tooltip("Player movement speed in units/s")]
    public float MoveSpeed = 5f;

    public bool InvertLook = false;


    [Header("Appearance")]
     public Color PlayerColor = Color.green;


    [Header("Description")]
    [TextArea(2,6)]
    public string desc = "Loren ipsum";





}
