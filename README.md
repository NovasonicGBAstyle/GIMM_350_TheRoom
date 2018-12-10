# GIMM_350_TheRoom

## Synopsis
The Room is a VR escape room experience.  As players, you must find the correct keys and enter them into the correct locks to escape the room with your lives!

The Room was built by Dope Dope Game Design (DDGD), a team of GIMM 350 students at Boise State University in the fall semester of 2018.

## Code Example
The Room was built in Unity version 2018.2.15f1.  The game uses a few different libraries.  It relies heavily on the Oculus Integration.  Some of the code was modified to fit the needs of the game.  Most of it is pretty straight forward use.  Oculus OVRPlayerControllers are the main usage from that code.  However, OVRGrabber and OVRGrabbable are also used heavily.  Many network pieces are used as well.  The network manager and network HUD are used in this code.  As far as how some of the game works, it uses the observer pattern to determine when keys have been used to unlock locks.  

## Motivation
The motivation behind the game is simple enough.  We wanted to create a VR game that allowed people to really get involved with one another.  We didn't have time to make a blockbuster title, but we still wanted to imitate some of experience you get from a blockbuster title.  Specifically, VR provides a level of immersion that other mediums simply can't compete with.  Rather than build a competitive game, we wanted to make something cooperative that people could experience together.  In fact, we wanted to people to be forced to work together.

## Tests
VR is difficult enough, and VR over a network is an extra added layer of complication.  Dr. Dan Hampikian was extremely helpful in getting this project off the ground.  He has a number of YouTube videos (links below) to get you started.  There were two particularly helpful tutorials that I want to make sure I touch on.  

VR Networking Part 1: How to Setup Multiplayer VR with Oculus and Unity (part 1 of 2) - https://www.youtube.com/watch?v=yRvfLLTkIXM&t=272sNetworked VR Inventory Part I - https://www.youtube.com/watch?v=jDMB5yFGrz4

Dr. Dan provided two different ways of generating a networked VR player.  Both have their merits, so I'll just cover the differences because there's a lot in common between the two.  In his first series, you have a fairly simple copy of the Oculus OVRPlayerController that doesn't have a lot of modification.  It's simple, easy to use, and in part 2 you can get an avatar going with animations pretty easily.  The second method uses a puppet that has some cool features as well.  It's much easier to move pieces on, and it's easier to prefab and mess with since you don't have all of the OVRPlayerController.  That is used, but not directly so it's a lot cleaner.

The second method game me a really hard time because the transforms on pickup were not quite right.  Eventually I figured out that the Y transform was just not coming across between the placement of the hands and the transform for objects being grabbed.  I have no idea why, but that's not something that happened on the other model.  Also, turning was a no go.  Items you grabbed didn't move when you turned.  Dr. Dan uses a method of holding things other than using OVRGrabbers and OVRGrabbables, but I didn't find them nearly as intuitive or easy to work with as the first method.

The first method had a problem that I could not get around.  Everything I read about getting a HUD in VR required changing the canvas to specifically use a camera that you would attach to the network player controller.  This worked just fine in the second method because you would leave the OVRPlayerController in the hierarchy, and just spawn the puppet.  But in the first version, it didn't exist, and I found no help on changing the render camera after everything had been built.  The render camera for the canvas can only be read in code, and the method people online said of setting the world camera did not work for me.  Because of this, I couldn't get a HUD with a win message or anything going.  I found this very frustrating.  So grabbing objects worked perfectly here, but I couldn't get messages to players.  None of this was very fun for me.

## Installation
So, I haven’t installed this myself outside of getting it to work myself.  I have rebuilt the project from scratch multiple times.  The only thing you should need to do is open the project in Unity, go to the asset store, and make sure you get Oculus Integration.  It’s free.  Once you download it, you will need to install it.  There may be a message about updating another Unity piece.  Do that as well if needed and you will need to restart Unity.  Have fun with the project!

## API Reference


## Tests

You should be able to run the game without any problems.  I always make sure that I have my Oculus connected before I start my computer.  Sometimes, but not always, that gives me problems.

## Contributors

Finn Scown
Mario Townes

## Known Issues

Currently the game ends abruptly on winning.  Also, players can clip through the walls and out of the room.  Keys are not kinematic, and after being grabbed and released will fly off into infinity.  This was done because either the keys needed to fly around or the locks did.  I chose the keys.  Lastly, even if the keys were set to get on the ground, the layout is too big or something and you can reach things on the ground.  Sad.

## License

N/A
