
# TimeShooter

This is a my 1st proper personal project on Unity 2D development. The goal of this project is to create a game with a basic gameloop.



## The Game

This game is called TimeShooter. In the game, the player is alloted 2 minutes of time. In this time, the player must run away from enemies while shooting at them to get gems

The Game is all about lasting as long as possible. When the Enemy touches the player, they lose time from their clock. They also lose time when getting hit by their own bullets.

In this game, there is a shop that allows the player to do 4 things: 

- Buy Bullets to kill the enemies
- Increase the Spawn Rate of the enemies
- Buy more time on their counter
- Attain "Insanity", a game mechanic to buff the player


## Game Design

This game revolves around time. The player is punished if they fail no not maintain their time with loss. 

In this game, the player must balance the amount of gems they have, and the time remaining. Not all enemies drop gems either, and each enemy needs to be shot twice to be killed.

If the player ever has 0 gems and less than 2 minutes of time left, they are effectively worse off than the start of the game.

The only way to progress in the game is by the player spending gems to increase spawn rates of the enemies, so that they can earn more gems to buy bullets and time

Insanity is merely an increase in movement speed and bullet speed. at this time, increasing score is the only goal left
## Game Mechanics

- I wrote all the scripts in the Game
- The player and camera controller were also custom written by Me
- I used NavMesh to create the enemies. The obstructions in the environment regenerate each time the player exits the shop

Controls:

- Left click to move in that direction
- Right click to shoot in that direction
- Middle mouse Button to use an eagle eye view
