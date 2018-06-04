using UnityEngine;
using NPBehave;

public class NPBehaveExampleHelloBlackboardsAI : MonoBehaviour
{
    private Root behaviorTree;

    void Start()
    {
        behaviorTree = new Root(

            // toggle the 'toggled' blackboard boolean flag around every 500 milliseconds
            //We mainly use Service to store & update values in the blackboards.
            new Service(15f, () => { behaviorTree.Blackboard["foo"] = !behaviorTree.Blackboard.Get<bool>("foo"); },

                new Selector
                        (

                    // Check the 'toggled' flag. Stops.IMMEDIATE_RESTART means that the Blackboard will be observed for changes 
                    // while this or any lower priority branches are executed. If the value changes, the corresponding branch will be
                    // stopped and it will be immediately jump to the branch that now matches the condition.
                            // we use BlackboardCondition or BlackboardQuery to observe the blackboard for changes 
                            //and in turn continue traversing the bahaviour tree. 
                            new BlackboardCondition
                            ("foo", Operator.IS_EQUAL, true, Stops.IMMEDIATE_RESTART,

                                // when 'toggled' is true, this branch will get executed.
                                new Sequence
                                (

                            // print out a message ...
                                  new Action(() => Debug.Log("foo")),

                            // ... and stay here until the `BlackboardValue`-node stops us because the toggled flag went false.
                                  new WaitUntilStopped()
                                )
                             ),

                    // when 'toggled' is false, we'll eventually land here
                             new Sequence
                            (
                              new Action(() => Debug.Log("bar")),
                               new WaitUntilStopped()
                             )
                        )
            )
        );
        behaviorTree.Start();

        // attach the debugger component if executed in editor (helps to debug in the inspector) 
#if UNITY_EDITOR
        Debugger debugger = (Debugger)this.gameObject.AddComponent(typeof(Debugger));
        debugger.BehaviorTree = behaviorTree;
#endif
    }
}
/*
 * if stops.self--foo bar
 * stops.both--foo bar bar bar……
 * stops.none--foo
 * stops.LOWER_PRIORITY--foo
 * stops.LOWER_PRIORITY_IMMEDIATE_RESTART--foo
 * stops.IMMEDIATE_RESTART--foo bar foo bar foo bar……
*/
