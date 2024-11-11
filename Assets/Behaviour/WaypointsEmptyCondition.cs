using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "WaypointsEmpty", story: "Is [Waypoints] Empty", category: "Conditions", id: "6fdeef783749c08fc6c1f5d6039903ec")]
public partial class WaypointsEmptyCondition : Condition
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> Waypoints;

    public override bool IsTrue()
    {
        return Waypoints.Value.Count <= 0;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
