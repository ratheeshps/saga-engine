using Automatonymous;
using messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace saga_state.machine
{
    public class RemitterStateMachine: MassTransitStateMachine<RemitterStateData>
    {
    public State Validation { get; private set; }

    public Event<IRemitterSaveEvent> RemitterSaveProcess { get; private set; }

    public RemitterStateMachine()
    {
        InstanceState(s => s.CurrentState);

        Event(() => RemitterSaveProcess, x => x.CorrelateById(m => m.Message.RemitterID));

        Initially(
            When(RemitterSaveProcess)
                .Then(context =>
                {
                    //Sending to next service
                    context.Instance.RemitterID = context.Data.RemitterID;
                    context.Instance.RemitterFirstName = context.Data.RemitterFirstName;
                    context.Instance.RemitterLastName = context.Data.RemitterLastName;
                    context.Instance.RemitterCountry = context.Data.RemitterCountry;
                    context.Instance.RemitterStatus = context.Data.RemitterStatus;
                })
                .TransitionTo(Validation)
                .Publish(context => new AmlValidationEvent(context.Instance))
                 .Finalize()
            );

        SetCompletedWhenFinalized();
    }
}
}
