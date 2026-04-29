# GDIM33 Vertical Slice
## Milestone 1 Devlog
In my state machine, to switch between the walking animation and the sprint animation, a visual script graph is used. On every frame, the graph first gets the moveState from the playerMovement script. Then, the graph checks if the moveState is equal to the MoveState.sprint. If it is false, the graph will continue to run until the condition is met. If the moveState is equal to MoveState.sprint, the graph will then trigger the transition from the walking state into the sprint state. 

![alt text](<Boostpads Collider(2).png>)

In my new breakdown, a new bubble has been added displaying the Player Animation State Machine. This bubble represents the state machine that will handle the animations of the player rig. This state machine transitinos through mutiple states that tell the player animator which bools are true and false that determine what animation is played at the time. Futhurmore, an arrow is pointing from the player bubble to the player animation state machine bubble as the playerMovement script on the player object will directly tell the state machine which state the player is in currently. 

## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
[Character and Animation assets](https://www.mixamo.com/#/)
