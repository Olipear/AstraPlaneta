# AstraPlaneta
Simple space exploration game

I developed my game in unity, principally it is portfolio piece, and tech demo. The major element of my game is the procedural solar system generator which I based off 'Star Gen'. I adapted, and stripped down this library to suit the game's needs. The major part which I added in consisted of several functions to determine a planet's habitability, which is a core mechanic of my game. I tried to keep the equations as realistic as possible, for example the atmosphere is breathable based on both the pressure and oxygen content. At low pressure high oxygen content can be tolerated, but at higher pressures oxygen becomes toxic. This level of realism aimed to add educational value to the game.

Since removed from the Play store because it had low downloads and I didn't want to support it with updates. 

The apk and an exe are on this repo, since the game was designed for mobiles it will not work correctly unless you can connect a gyro-enabled device for a controller. The device gyro is used for camera control, making the game sudo-VR-ish. 


[The original launch trailer is here.](https://www.youtube.com/watch?v=Cx0PQZmxuKU)


![colony ship](/screenshots/colony-ship.png)
A screenshot of the colony ship model with it's little shuttle.

![map table](/screenshots/map-table.png)
The map table

![information screen](/screenshots/information-screen.png)
The information screen trying to show far too much!

[This is a video breakdown of the procedural planet textures used in the game.](https://youtu.be/GKbdD22UnuI)
