# Scarper Out

## Authors

-   Madhava Raveendra
-   Sheshasai Sairam

## Description

Scarper Out is an interactive game where the player has to reach the end goal by navigating a randomly generated maze. The maze contains three different powerups which help the player reach the goal. The lighting powerup increases the lighting for the player, the speed powerup increases the speed of the player, and the path finding power up shows a path from the player location to the end goal. The maze also contains monsters that move towards the player if it sees the player. If a player collides with a monster then the player gets teleported to a random location in the maze.

## Features

-   Maze Generation using Recursive Backtracking <br />
-   A-Star Algorithm for Path Finding Powerup <br />
-   Particle System for Fire Effect <br />
-   Speed Powerup Increases Movement Speed <br />
-   Lighting Powerup Increases Lighting <br />

## Key Algorithms and Approaches

### Recursive Backtracking

We chose recursive backtracking for our maze generation since it allows for an easy, fast, and simple implementation for a maze generating algorithm. In this algorithm, a 2-dimensional grid of cell objects is used to indicate the position of the walls. Starting from a random point in the grid, a random adjacent cell in a cardinal direction is visited and added to a stack. If all adjacent cells have been visited then that cell is removed from the stack. This process is repeated till only the starting cell is left in the stack. While this algorithm is fast, its biggest bottleneck is that it requires a lot of memory for the stack. So for really large mazes this algorithm is inefficient, and would be a big limiting factor if we were to scale up the size of the maze.

### A-Star

We used a modified pathfinding algorithm called A\* Algorithm to implement the Path Finding PowerUp. This algorithm takes a few seconds to process the path towards the goal for the player based on the soze of the maze/map which seems to be one of the biggest drawbacks of the algorithm. On the contrary, it provides us with an efficient path for the player to reach the goal.

### Particle System

We are using Unity's built in particle system which allows us to create a random controlled spread of particles using various sprites. Specifically, we are using it to generate the subtle fire particles of the monsters which will chase the player. This fire particle system was adapted using a free asset from the Unity asset store that is referenced in the 'References" section below.

## Gameplay Design

We chose to go with a dark and horroresque theme, so most of our animations and design choices complement this. We chose to use dark materials for the maze walls and narrowed the field of view of the player to better go with the theme of the game. We also chose to animate the monsters based on the gameplay designs. Our monsters move when it sees the player and to indicate this movement we used particle systems to animate fire around the monster. Also it takes less power to render since the particle system is only on when the monster is moving towards the player. We also used A-Star to for pathfinding when the player picks up the pathfinding power up. We chose to use A-Star since it is complete and optimal. This is useful because the maze has at least one solution from the player position to the end goal which the A-Star will find since it is complete. Also since A-Star is optimal it will find the shortest path to the goal, this way the player will be able to reach the goal in the shortest amount of time.

## Execution

Use the button above to navigate to the source code. Find the 'Project Build' folder and run the executable inside.

## Controls

-   ASWD/Arrow Keys : Move Around <br />
-   Space : Jump <br />
-   Mouse : Look Around <br />
-   ESC : Pause Menu <br />

## Video

## Progress

(Initial sketch Image here)
Our initial idea was for Scarper Out was to create a maze game and have obstacles that the user will have to get past to reach the goal. We decided to make the obstacles monsters that chased and attacked the player. We also wanted to use power-ups to help the players defeat the monsters, but later on decided against it. Instead we decided to have the monsters teleport the player to a random location in the maze, and designed the powerups so that it will help the player get to the goal faster. This way it made the game more focused on solving the maze than fighting the monsters.

(Progress Image here)
Once we got the basic design for the game, we started implementation of the different elements. First we created the maze using recursive backtracking. Once the maze generation algorithms worked, we had to place nodes along the path so that we could use A-Star to find the best path to the goal. Originally we thought this was going to be easy, however since the maze algorithm only places the walls and doesn't actually create a path, we had to use the grid positions in Unity to place the nodes along the path. Once the nodes were placed we were able to adapt the A-Star algorithm (Add difficulties with A-Star). The other power-ups were fairly straightforward to implement. Also in order to make solving the maze easier we decided to add a star indicator above the end goal in order to help guide the player to the end.

## Peer Feedback

We got a lot of good suggestions to improve our game The feedback we got included:

-   Increasing the field of view
-   Adding variations to wall textures
-   Adding more power-ups
-   Adding sound effects

We decided to implement a few of them in order to improve the game. First we increased our field of view since originally it was a bit narrow and with the lighting it made it hard to navigate the maze. Second we added sound effects for footsteps, item pick-up, and background. These sound effects greatly improved the immersiveness of the game.

## State of the Art

A lot of the techniques we used were fairly new and state of the art algorithms and techniques, some of which we discussed in class. For example, in Unity we used raycasting to check if a monster can see the player. Unity's raycasting uses spatial search to check if objects will intersect. Unity casts the ray from the object to the bounding box of the collider to check for collisions.

## Future Upgrades

Our game can be extended and improved in multiple ways. The biggest improvement will be using a better pathfinding algorithm, since A-Star is very slow as the maze gets larger. Given more time we could implement faster algorithms to find a path to the goal. We could also use fewer nodes by placing the nodes in intersections of the maze. This will allow for the A-star algorithm to run faster since there will be fewer nodes to check. Improving the pathfinding will also allow for us to create larger mazes, which will then allow us to create more unique powerups and monsters to make the game more interesting.

## References/Links

-   World Materials Asset: https://assetstore.unity.com/packages/2d/textures-materials/world-materials-free-150182
-   Skybox Series Asset: https://assetstore.unity.com/packages/2d/textures-materials/sky/skybox-series-free-103633
-   Procedural fire - https://assetstore.unity.com/packages/vfx/particles/fire-explosions/procedural-fire-141496
-   Ten Power-Ups - https://assetstore.unity.com/packages/3d/props/ten-power-ups-217666
