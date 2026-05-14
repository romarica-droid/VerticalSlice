# GDIM33 Vertical Slice
## Milestone 1 Devlog
In my state machine, to switch between the walking animation and the sprint animation, a visual script graph is used. On every frame, the graph first gets the moveState from the playerMovement script. Then, the graph checks if the moveState is equal to the MoveState.sprint. If it is false, the graph will continue to run until the condition is met. If the moveState is equal to MoveState.sprint, the graph will then trigger the transition from the walking state into the sprint state. 

![alt text](<Boostpads Collider(2).png>)

In my new breakdown, a new bubble has been added displaying the Player Animation State Machine. This bubble represents the state machine that will handle the animations of the player rig. This state machine transitinos through mutiple states that tell the player animator which bools are true and false that determine what animation is played at the time. Futhurmore, an arrow is pointing from the player bubble to the player animation state machine bubble as the playerMovement script on the player object will directly tell the state machine which state the player is in currently. 

## Milestone 2 Devlog
Complicating factor: 
1. When the player presses R, the player dashes
    1. Get the rigidbody of the player rigidbody object
    2. Detect when the player presses the R key
    3. Apply a force that pushes the player forward
2. When the player dashes, the player has to waits 5 seconds for the next one
    1. Create an inemurator that will make a temporary countdown when called
    2. Detect when the player presses the R key
    3. uses the time inemurator to temparoraly disable the players dash, then reactivate it 
3. When the player holds f in the air, the player will descend faster
    1. Get the rigidbody of the player object
    2. Detect when the player presses the F key
    3. Apply a y force that pushes the player rigidbody down 

## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
[Character and Animation assets](https://www.mixamo.com/#/)
