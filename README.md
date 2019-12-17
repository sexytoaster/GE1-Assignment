# GE1-Assignment
 

For my assignment I an going to make a 3D audio visualiser that will look like you are moving
through a neon kaleidoscope. In it i want to make it look like the camera is moving though a tunnel 
with particles and objects surrounding you leaving trails in different shapes. The generation
and look of the particles and shapes around you will change with the music tempo and what frequencies
are being played. A similar looking project I have found from looking through last years projects
is by [Daniel  Hederman](https://www.youtube.com/watch?v=oxqISvYzKc4&list=PL1n0B6z4e_E5qaYwUOlJ63XI2OR9ty7Bs&index=27)

Mine will have a similar idea in that it will be a tunnel and it will look like you are moving 
through it but mine will differ in the shapes it is creating and how it visualises the music etc.

## Research
[Audio Beat Detection in Unity](https://www.youtube.com/watch?v=BVhnmm1SvF0)\
[Music Visualisation Unity](https://www.youtube.com/watch?v=eTP_8NXwyNE)

## Some Inspiration
This is the album art for Tame Impalas "Currents". It served as some inspiration for the aesthetic.
![Tame Impala Currents](/images/04192b63.jpg)
## 
This is a screenshot of the project as it currently is. Looks even better in motion!
![Screenshot](/images/screenie.png)
##

## description of what the assignment does and how it works:
This program is a music visualizer made in Unity3D. What it does is spawns in rings and triangles that respond to the beat by getting bu=igger and smaller. They also respond to the different bands of the music by geting brighter and dimmer. For the triangles this lighting happens on band 3 and the rings on band 1. The skybox is the subbase, and is black when there is none and goes a lght shade of purple when there is subbase. I didnt want it to be too flashy and hard to look at so this skybox effect is subtle. It is an infinite tunnel so the camera moves through it also, and the triangles and rings behind the camera get deleted. The camera also moves based on sound. The length of the tunnel is dictated by the base, so it gets deleted and regrown so to speak when the base hits. It also changes its rotation direction whenever it is completely destroyed. At either side 2 spheres spawn in. These have had their colliders and mesh renderers disabled and are used so that trail rendereers can be attatched to them. These trails then show bands 4 and 5 in differentcolours that look quite good. I actually really liked the error texture when no terxture is attatched so one of the bands has a material closely matching this pink. I also added a sphere that tracks through the tunnel that switches direction of sway on the beat and visualises the 6th audio peer band to give the brilliance section a bit of love. All objects spawned become children of the visualizer game object.

## 

## Which parts of the assignmemnt you developed yourself vs parts that come from the examples we made on the course or that come from tutorials
the thing i took from a tutorial is the audio peer script, which is basically a bigger version of what we made in class with a bit of extra functionality. Other than that I made all the scripts and assets. 

##

## What you are most proud of about the assignment
I really like the aesthetic i achieved. It might not be for everyone but I wanted it to be based off one of my  favourite albums of all time which is Tame Impalas Currents and i think it vibes with his style of music. Also as a tribute I added in a shere tracking through the tunnel which leaves a trail and it looks a bit like the cover art for the album.

##

## Video of Assignment

[[[/images/thumbnail.jpg]]][1]
[1]http://www.youtube.com/watch?v=mSEMEWo5zCM&feature=youtu.be
