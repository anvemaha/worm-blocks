# Worm game
Educational project. I learned a lot about what to avoid when making a game. It's more of a simulation you can interact with rather than an actual game.
- It's scalable, thousands of worms can be simulated on-screen (depending on hardware, settings and desired framerate).
- [Pooler.cs](WormGame/Pooling/Pooler.cs) has generics, [Blocks.cs](WormGame/Entities/Blocks.cs) BlockSpawner has recursion and there's also [tests.](WormGameTest/)
- See [CHANGELOG.md](CHANGELOG.md) for a more in-depth look on the development process.
- Over 2 500 lines of code (documentation included).
## Benchmarks
| 200x100 grid, worm length 6  | 3333 worms   | Filled with blocks |
|------------------------------|--------------|--------------------|
| i7-4790k and GTX 1080, 144Hz | 37,6 AVG FPS | 90,9 AVG FPS       |
| Ryzen 5 3550U, 60Hz          | 12,4 AVG FPS | 52,6 AVG FPS       |
## Video
[![YouTube video](https://img.youtube.com/vi/QqxTP1VZjGs/0.jpg)](https://www.youtube.com/watch?v=QqxTP1VZjGs "Worm Blocks v0.5")

# Game mechanics
- Field
    - Fruits and worms spawn on it
- Players
    - Can posess worms
    - Up to five (4x gamepad + keyboard)
        - Gamepad: left stick to move, right bumper to posess and join
        - Keyboard: WASD to move, space to posess and join
- Worms
    - Go straight until they hit something
    - Controlled like snake in the snake game
    - Grow longer by eating fruits
    - Turn into blocks when stuck
- Blocks
    - Can't move
    - Disappear if next to another block of the same color.
   
# Setup
- Open the .sln file, should work out of the box.

# Tools
- C# + [Otter](http://otter2d.com/)
- Visual Studio Community 2019
- [ComTest](https://trac.cc.jyu.fi/projects/comtest/wiki/ComTestInEnglish) (not required to run tests)
