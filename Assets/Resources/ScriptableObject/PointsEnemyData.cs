using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyPositions", menuName = "ScriptableObject/PointPosotion/Enemies")]
public class PointsEnemyData : ScriptableObject
{

    [SerializeField] private List<Transform> _positions;
    public List<Transform> Positions => _positions;

}
