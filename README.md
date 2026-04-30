# EyeJam2 "Decay"
Public Repo for EyeJam2. A gamejam around cosmic horror with the theme being "decay".

Gamejam link: https://itch.io/jam/the-eye-jam2

Link to game on itch.io: https://purplebred.itch.io/tempus-interitus

The team aimed to create a point and click adventure game based around a timeloop where the player "decays" and is getting more and more sick. Once one minute is up, the loop resets.

## Constraints
One major contraint you often have for longer game jams is that you begin to setup code and architecture before you have assets or even a complete story, this is especially true for a point and click adventure. Our writer needed time to create puzzles and story.

My approach to this problem was to try and setup my code in Unity, such that every part of implementation of art and sound is done entirely through the Unity editor in the inspector. The main feature to get this done is with the GameCondition and GameAction system. This is an example of a specification pattern and command pattern. Each object that players can interact with have a list of actions and conditions, these conditions can be created as scriptable objects and assigned to each object within Unity's inspector. Conditions can be anything from, "AlwaysTrue", checking for player's condition or what item the player is holding. The actions include many things, such as playing sounds, adding/removing items, changing rooms, etc. The list goes on.

I ended up creating 15 different GameActions that can all have different settings, but only really 4 different game conditions. Not all of those actions got used because we weren't able to get assets for some of the puzzles but they work! T_T

The huge plus side of this architecture was that it allowed me to very easily implement the puzzles and art in the second half of the game jam period. I was able to implement and test the art at the same speed I was it was getting uploaded to the shared file system by my team. In the last 24 hours of the jam, I was able to work consistently in implementation without touching a single line of code. Meaning that in a future jam, if we have a dedicated game designer, they would be able to handle implementation while I can continue working on polish and bugs.

## Key Challenges
In the final hours, we discovered issues in scene transitions due to memory leaks in static variables. Specifically the static list of interactable objects that were not cleared after all of the contents were deleted but the list itself was not cleared.