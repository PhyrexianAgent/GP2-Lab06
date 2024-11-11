using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetWaypointsFromHolder", story: "Set [Waypoints] from [patrolPointsHolder]", category: "Action", id: "71b42a0f57ed106fcb85bf317644c018")]
public partial class SetWaypointsFromHolderAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> Waypoints;
    [SerializeReference] public BlackboardVariable<GameObject> PatrolPointsHolder;

    protected override Status OnStart()
    {
        for (int i=0; i<PatrolPointsHolder.Value.transform.childCount; i++){
            Debug.Log(PatrolPointsHolder.Value.transform.GetChild(i).position);
            Waypoints.Value.Add(PatrolPointsHolder.Value.transform.GetChild(i).gameObject);
        }
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

