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

Task Step breakdown
Although i do think that the task step breakdown was helpful for organinizing my thoughts in order to create my complicating factor, i do not think it was helpful actually with building the complicating factor. Since my complicating factor was movement based (fast fall and dashing), it was already vital to the core gameplay of the game, where i would add on the different features while making the intial rough draft. This made the list irrelevant at this stage of the project since i already created the foundation for the system and did not really need to break down how i would get the nessecary componets to finish the factor since most of the were already present.

Unity System
For my unity system chosen unity system, i decided to use an animator. Since the game is in first person and is hard to see the play animations, the NPC also has two animations for talking and standing idle.


## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
[Character and Animation assets](https://www.mixamo.com/#/)
