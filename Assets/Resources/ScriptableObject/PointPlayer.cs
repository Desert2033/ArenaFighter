using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPositions", menuName = "ScriptableObject/PointPosotion/Player")]
public class PointPlayer : ScriptableObject
{

    [SerializeField] private Transform _position;
    public Transform Positions => _position;

}
