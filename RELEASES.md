# Release notes

# Version 5.0.0
Version 5.0 is a complete re-write of the state machine. It makes large use of multicast delegates to pre-evaulate the steps required to perform state transitions. This leads to considerable performance benefits no evaluations are made relating to the structure of the model at runtime as it does not change at runtime.

# Version 5.2.0
Renamed IContext to IActiveStateConfiguration

Renamed Context to StateMachineInstance

Renamed ContextBase to StateMachineInstanceBase

Removed XContext and XContextBase

Added Create... extension methods to main classes to faciltate simpler model building.

Changed StateMachine to inherit from State 

Added a visitor pattern implementation

Moved the bootstrapping to use the visitor