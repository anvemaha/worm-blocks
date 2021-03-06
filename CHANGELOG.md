# Changelog
I use changelog as a brain dump where I explain future plans and further explain commit messages. I hope it shows my enthusiasm for programming and the amount of thought and care put into the project.

# 29.12.2020
- More cleanup
    - Added Otter to the project as it is no longer supported
        - It has some warnings, but I set them to be ignored
    - Settings.cfg is now included in build
    - It's my birthday, yay! :D, random blabbering:
        - Onto more relevant matters:
            - Otter is no longer supported (discord server was closed and a note added to the website)
            - I got some code review done on the repo
                - I should add otter to the repo now that it's no longer supported and it even has a MIT license so there's no problem
                    - Should've added it to the repo from the beginning
                - Settings / config desperately needs some restructuring / cleanup
                - Overall the project needs some restructuring
                    - The way things are is not the smart way to have them and they are the way they are due to what the project was planned to be instead of what it is
                        - For example, blocks are not really needed.
                        - Worms should be able to erase themselves
                            - I'll solve both of these problems by building worms out many circles
                                - look into otter components?
                            - and instead of turning worms into blocks I'll make them gray
                    - Poolers / managers have become bloated
                    - Joining the game is confusing (unclear instructions)
                - I took notes during the review but unfortunately I've somehow managed to lose them. Heck.
                    - I think I still remember most of the stuff, mostly syntax / semantic related fixes
                    - paths should be modified to be relative instead of absolute
    - **Overall I don't think it's worth it to continue working on this project. There's a lot to fix, but I'll just take what I learned and apply it to my next project**

# 06.11.2020
- Cleanup
    - Ran Visual Studio's automatic code cleanup
    - Fixed a typo in README.md
    - Renamed a fruits -> currentfruit in Collision.cs as it's more accurate
    - Fixed a typo in eraser documentation (exists -> exist)
    - Added unit to WormModule documentation as it's a little bit better grammatically
    - Added ? to Poolable and PoolableEntity.Active for the same reason
    - Added the word Function to Colors.Equal documentation too
    - Renamed FastMath to SimpleMath as I never measured if they are actually faster.
        - Also lite -> Simple
        - Rebuilt tests due to name change
    - Added code metrics below
    - Updated to Static/Colors.cs documentation (it wasn't updated during the name change from Help.cs -> Colors.cs)
    - About the coil whine issue mentioned several times: for some reason Otter sometimes uses nearly 100% of my GTX 1080, but the GPU whine is also present when playing Doom. I only noticed it during this project because I didn't have headphones on all the time.

## Project [code metrics](https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-values?view=vs-2019):
    
| Maintainability Index | Cyclomatic Complexity | Depth of Inheritance | Class Coupling | Lines of Source code | Lines of Executable code |
|-----------------------|-----------------------|----------------------|----------------|----------------------|--------------------------|
| 74                    | 320                   | 3                    | 48             | 2 531                | 594                      |


# 20.08.2020
- Reset, start finalizing
    - Returned to previous erasersystem and non-scalable worm modules, managed to fix it (no more crashes).
    - Time to start finalizing the project: update documentation, variable names, etc. and call it done for now.
    - I know I could've just undone the previous two days, but I like to keep everything in store just in case.

- Update documentation
    - Instead of using dates for @version I'll start to use the tag version. I didn't update frequently enough to be accurate and dates can be found on the github repo.
    - I've decided to use my name instead of handle for @author because I like it. If some future committor doesn't want to use their name, handle is just as valid.
    - I try to write documentation the way commit messages should be written. Imperative, and to the point. Sometimes I'll explain more.
    - WormGame/Static/Random.cs moved from System.Random to Otter.Utility.Rand. I thought I already had done this but I guess it got lost in some reset.
    - Renamed idea.svg -> concept.svg (original name). It's not up to date, but I think it's fun to see what the project was supposed to be.
    - Updated tests. Should probably write more, but it is what it is. The project has architectural problems (not using components, me being an inexperienced programmer) so I'm unwilling to pour more effort to it than I already have.
    - Grabbed a color palette from https://coolors.co/1a535c-4ecdc4-f7fff7-ff6b6b-ffe66d. (Some UX principle says that what is beautiful is also functional)
    - Renamed WormGame/Static/Help.cs to Colors.cs as it had accidentally gathered all kinds of stuff related to colors.
    - Figured out where the mysterious 5 comes from: when I write showfps 5 to ingame debug console, 5 gets printed.
    - **STUFF I WOULD STILL KIND OF LIKE TO DO, BUT DON'T HAVE THE TIME:**
        - Eliminate the need for defragmenting by disabling objects through their respective poolers. The manager system probably makes this rather easy.
            - So instead of checking for swaps when the pool full, just do the swap during a disable. Call it Repair() or something like that.
        - Replace object 2d array in WormGame/Core/Collision.cs with collisionobject. This would tie into collision system / pooler update: collisionObject would be a struct with two ints: type and arrayPosition.
        - Remove recursive parameter from every Disable()
        - Separate erasing system (WormGame/Entities/Eraser.cs) might not be needed and worms could erase themselves. Kind of tried something like this just before reset, but I got tired.
        - Fruit system (WormGame/Entities/Fruits.cs) could use surface instead of tilemap? This would allow using circles as graphics, but would require some kind of a queueuing system. So possibly not a good idea.
            - Alternatively implement texture packs and make fruits use textures. At some point I attempted this, but I couldn't scale textures and decided it was not worth the effort.
        - Create a separate poolable object just for testing.
        - Poolable.Add could be used for grabbing WormScene instead of passing it as a parameter from scene, but custom poolers / managers kind of break this.
        - Additional Pooler methods: Disable(), Repair() (DRY between Defragment() and Disable()) and IsFull() or something similar.
        - Contribute Help.Equal (Color check) or something similar to Otter?
        - WormScene.NearestWorm() could be optimized by using collision grid to find nearby worms and only looping through them instead of every worm.
        - Make it possible to configure the game in a way that no worms spawn and that it's easy to spawn worms to be able to reproduce bugs.
        - I'm not sure if combining Blocks, BlockSpawner and BlockModules classes under Blocks.cs was a good idea. The folder structure is cleaner and easier to navigate on github the they're kind of long.
            - Following this logic, everything inside WormGame/Pooling could be combined to Pooling.cs and moved to WormGame/Core. But I'm kind of proud of the pooling system so I want to keep it where it is.
        - Redesign everything using compontents, but that's so much effort that I'd rather just start a new project.
        - Load colors from settings.cfg as hex codes instead of defining them at WormGame/Static/Help 
        - Figure out if during debugging settings could be loaded from repo root folder instead of executable root folder.
        - Figure out how to properly release a binary and what the user has to have installed.
        - Research if it's possible to reduce GC frequency by not creating as much garbage in the first place.
        - Figure out an actual name for the project. Originally it was Worm Bricks, now it's Worm Blocks and neither of those is a good name.
            - The new color theme makes me want to call it worm blobs just for the lols but that's too much effort for a joke.


# 19.08.2020
- Reset blocks and improve collision visualizer
    - Watched a video on ECS (http://gameprogrammingpatterns.com/) and apparently using inheritance for game programming is bad and older than me. I'd like to redo the entire project using components (WHICH OTTER HAS), but I'll just try to finish it with the current design and be smarter on my next one.


# 18.08.2020
- Add eraser
    - Performance seems to be kind of spiky, but the game is fully functional!

- Reset
    - Okay there are two bugs with the current erasing system:
        - Sometimes worms flicker while moving
        - Sometimes 1x1 part of worm is left unerased
        - Worms are kind of a unholy mess of ifs and elses. I'd like to improve this.
        - There were nasty stackoverflow crashes due to blocks - eraser integration.
    - There's also another problem: eraser is all over the place, it's called from blocks, but erases worms and requires coroutines which might cause some issues.
        - Solution: make the underlying worm modules scalable, use surface for rendering and make worms erase themselves upon disable.
    - Scaled worm modules seem surprisingly stable! I thought re-integrating it would be a pain. huh
        - Blocks need to be reintegrated to to scaled modules, but first I want worms working properly.



# 17.08.2020
- Fix rendering artefacts with manual update loops
    - For some reason, even though the max framerate is limited with RTSS, setting game.FixedFramerate = false solves surface rendering artefacts
        - It's not a valid fix as I can't require users to install RTSS.
    - Somehow I managed to get massive performance gains by setting game.FixedFramerate to false and doing the updates manually. 2.8k worms rendered at 82 AVG FPS.
        - Kind of hacky? But GPU and CPU usage are around 20% so I guess I'll roll with this.
    - I think the rendering artefacts were caused by Otter sometimes skipping an update or doing them twice. Not sure.

- Improve worm eraser
    - Let the game run (940x500, 1920x1080) and the game could handle over 10 000 worms with AVG FPS of around 15! :D
        - Big takeaway: THE GAME IS CPU BOUND, RENDERING IS PRETTY HECKING LIGHTWEIGHT NOW :D
            - Or, it's much better than it used to be: My desktop has a i7-4790k and GTX 1080.
    - Scene.CreateBorders() now adds graphic straight to scene instead of using an entity.
    - WormEraser works! Really happy with it.
        - Worms aren't yet eraser on disable, so it's not done.
    - Even though rendering is done with a surface, worm modules would probably greatly benefit from being scalable.
        - Less of them needed -> less to compute, eraser would be simpler with scaled modules.
    - Game suffers from slowdowns if update and render take more than the config.refreshrate allow, but it won't exceed it so I'm willing to live with this.
    - Worm surface rendering benchmark: (200x100, 720p60, worm length 6)
        - 69,8 AVG FPS (3338 Entities, 6670 Renders) 2ms + 10ms
    - ~~Future ideas:~~
        - ~~Players don't have to be entities if graphics can be added straight to scene.~~
            - Yes they do due to input.

 - Update README.md
    - I realized I could remove game.FixedFramerate = false as I can use custom update loops even if that's set to true.
        - This way player won't be as buggy and internal framerate counter is more correct
    - GPU usage issue is back (I can hear coil whine and usage is above 50%)


# 16.08.2020
- Fix scalable worms (not smooth movement, but works properly)
    - Proper benchmark: 25,1 AVG FPS. Dun dun duuu. A huge dissapointment, meaning Surface-based approach *was* the best so far~~, but, there's a but:~~
        - ~~When a worm is going straight, it takes up *just one* render. Each turn requires one extra render during its existence, meaning worms that have made many turns take up more renders: but when that happens, in the actual game, *they turn into blocks* which are like super cheap to render. So even though the benchmark is worse than with surface, I'm sticking with for the following reason:~~
            - ~~The benchmark doesn't represent real game situations.~~
            - ~~Scalable worms are sometimes cheaper to render.~~
            - ~~Surface-based rendering approach would require *tons* of extra systems, such as some kind of a eraser system.~~
                - ~~While intriguing, I'm not really willing to attempt implementing it as I know it won't be perfect and if we dont want to pool moduleAmount of erasers, there will always be some rendering artefacts.~~
                - ~~Although I do kind of want to try to move fruits from tilemap to surface, but that's going to be later if ever.~~
        - Okay so I will probably retract everything I wrote there as I went back and checked the original worm render performance and well I have a maybe two-frame improvement even though I halved the render amount so fuck this I'll bend surface to my will.
    - Also added disable to poolers, but it's untested so it might be broken.

- Basic scalable worms
    - Collision broken
    - Sometimes worms develop tumors.
    - Preliminary benchmark: 62,8 AVG FPS, update and render both 5-6ms
        - This is the best approach even though the number will probably get worse.

- *Resetted repository* back to decouple "Decouple config from wormScene" as that's when surface worm rendering was kind of working. Manually adding any other improvements I've made since then. Why not do a full repository reset? Because I want to be able to go back to scalable worms if need be.
    - Benchmark: although there's some kind of issue with worm module usage that I solved by doubling the moduleAmount, the rendering performance is impressive: AVG 45 FPS. (2500 entities, 7500 renders) 5ms update 11ms render.
        - Maybe bring back Pooler.HasAvailable?
            - The culprit was fruits? Strange. Also had worse performance once I disabled them (30 AVG FPS)
                - There's something wrong with scenes wormsAlive tracking?
        - Time to go to bed.


# 15.08.2020
- I tried surface-based approach, but it's a failure.
    - Even though I could probably work out rendering artefacts, I can't clear worms from the surface once they've been disabled without some elaborate eraser system.
    - Switching to tilemap approach.
- Thoughts on WormModules
    - I could create a worm system where worm would have head, waypoints, and tail (end). Waypoints would be somewhat analogic to current modules.
        - It would only need one waypoint per direction change, instead of current one module per length. Also only head and tail are relevant to worms graphics so the modules in between are kind of unnecesary.
        - The thing is, if I want to be *sure* that waypoint pooler would never run out of waypoints, I'd have to init the same amount of them as modules.
            - Counterargument: there would be less runtime computation even if disabling was a little bit more complex.
        - Result: I'll try to implement waypoint system and if that fails, I'll fall back to current modules.
- Upgrading worms to work under a manager netted me a grand total of 1,7 FPS which is within the margin of error. The game is GPU bound and rendering graphic under many vs single entity doesn't seem to affect performance.

- SURFACE-BASED APPROACH IS BACK ON!
    - Tilemap rendering was implemented, but it turns out that constantly setting and clearing tiles is quite heavy.
    - So now the extra eraser system that would make the system work is not unnecessarily complex! It's the only performant approach!

- Begin work on scalable worm modules
    - Surface based approach abandoned as it's too complex and not as performant as I wished.
    - Further decouple WormScene and config
        - WormScene is not created inside config anymore.
        - Tilemap and surface are resetted by BlockManager and WormManager instead of WormScene
    - Preliminary (correct render amount, visually broken) benchmark results: 10 000 renders (3 per worm) AVG FPS 34.
        - Compared to the previous 22,3 it's a nice improvement, but smaller than I'd like.
        - Now I am wondering if scaled worm modules would be more performant to render.
            - sigh
                - at least I know the solution I'll end up with will be the best one.
    - Scaled modules vs surface
        - Surface: 34 AVG Performance, lots of extra complexity to make it work properly
        - Scaled modules: Most likely need to abandon current Worm / Module system in favor of a new one, when a worm is going straight it's more performant, need to reintegrate blocks.
    - Future plans
        - Custom module poolers for worms and blocks that don't need to be defragmented from time to time. (Disabling done through them -> defrag swap done during that)
        - Collision: replace object with struct CollisionObject which has int layer (layers already implemented) and int arrayIndex so we can access objects through their managers (poolers)
    - Currently too many if elses. Got to reduce them.


# 14.08.2020
- Improve BlockManager
    - BlockModule -> Block
        - Blocks are made out of multiple modules. First module is added to collision field so disabling works properly.
    - Block -> BlockSpawner
        - Blocks were no longer needed to hold modules together
        - BlockSpawner is not pooled as only one of them are needed
            - Technically could be inside manager, but I don't want to bloat it.
        - BlockSpawner configures modules to form blocks.
    - The benchmark I've been using has become useless. While there might be some optimizations to be done, I either need a less powerful computer to notice differences or a better benchmark
        - You get (improve) what you measure. Time to invent a new benchmark that measures worm performance.
        - This was probably a massive memory saver (didn't measure, but I'd say its in the megabytes if not tens of them) and GC seems to be running less frequently.
    - Renamed some variables in Pooler to make more sense.
    - ReferenceEquals is no longer needed at all.
    - Made console messages prettier and applied some UX design to them (bright colors take our attention)
        - Pooler messages now alternate between color and gray to make long lists readable.
            - Had to add a global variable to Help to do this. Is this the rare case where it's okay?
    - Updated Block related documentation.
    - Future plans
        - Create a benchmark that measures worm performance

- Cleanup
    - Sometimes there's a mysterious 5 printed to console.
        - Attempted fix: redownloaded otter
            - Let the game ran for a good while and no 5 in sight.
    - Optimize blockSpawner
    - Future ideas
        - As more and more entities will be under some kind of mananager, we probably can get rid of defragmenting in favor of calling entitys disable from pooler.
        - Get rid of as many static functions as possible. It's just not a good practise?
        - There are two ways to optimize worms
            - First one: surface with autoclear off. This is the most appealing as I wouldn't have to create any textures to make it look nice. There's just a lot of pitfalls and each worm will take up at least 2, likely 4 renders.
            - Second one: tilemap + 2x graphics. This would be almost twice as fast to render (little over 2 vs 4 renders per worm) but to make worms look nice I'd probably have to create some kind of a texture and I don't want to do that.
            - I hope I can get rid of worm like I got rid of blocks in favor of just modules but we'll have to see
                - Alternatively I hope I can reduce the amount of modules a worm needs
            - The doubling of wormAmount to wormCap can probably be removed if I just spawn the worm a update later. This is already a massive save.
    - Worm benchmark (200x100, worm length 6 and blockifyWorms = false and let run until no new worms spawn)
        - Update 7ms (3339 entities) Render 28ms (20 000 Renders) 22,3 AVG FPS
            - This is the unoptimized baseline benchmark against which future benchmarks will be compared against.

- Move fruits to tilemap
    - FruitManager shares the same tilemap with BlockManager through config.
    - We are going to need graphics: for now fruits are just white rectangles.
    - Weighing the choice between surface and tilemap based worms:
        - Tilemap based worms would take like 1 + 2 * wormAmount renders where surface with autoclear off based worms would take 4 * wormAmount.
            - One of the main goals is *scalability* tilemap based approach is *almost* twice as performant rendering wise.
        - Tilemap based one will require textures and figuring out what texture to use for what part of the worm can be kind of difficult.
        - Surface wouldn't require textures, but as fruits already will require, what the heck.
            - Okay I *could* make fruits use a surface instead of tilemap, but not sure I want to do it as tilemap is kind of neat.
    - ~~Next step: make wormModules scalable? Should be doable but I'm not sure how messy it will be.~~
        - ~~Worms **will** look weird for a while but this is easier to do before migrating them to a new rendering approach.~~
        - Neither one of the new worm rendering approaches will let us keep the worms looking the way they look (many circles: ooooooooooooo) but even in the original idea.svg the worms were rectangular.
    - Did some documentation updating.


# 13.08.2020
- Add BlockManager
    - Early tilemap benchmark (blocks are still entities) (200x100, worm length 6, field full of blocks)
        - Update 4ms (3705 Entities) Render 2ms (2 Renders) AVG FPS 77
            - Totally worth the effort.
    - Quick collision fix (PoolableEntity -> Object, blocks are now just objects) benchmark
        - Update 1ms (6 Entities) Render 5ms (2 Renders) AVG FPS 96
            - Vsync and/or RTSS are probably messing up the numbers now but the point is it's measurably better.
                - Non-entity poolables aren't free but they're way cheaper than entities.
            - Worms are still kind of expensive to render -> I'll have to invent a new benchmark.
    - Before we can rework collision to not use Objects (feels like a quick n dirty solution) fruits will have to be migrated to use a tilemap
        - New collision system would work something of like this:
            - New struct: CollisionObject that has int layer and Poolable object
                - Poolable object can be null if it's not relevant to make calls to it (worms only need layer)
        - Fruits probably won't need separate objects per fruit and just one tilemap will be enough.
            - I can probably get rid of Block
                - Every module could know the first one in the chain and scaling etc would be taken care of a middle manager (one object) or manager.
    - I noticed that GC is running quite frequently if the play area is not small. I hope I can improve this.


# 12.08.2020
- Cleanup
    - Moved leftBorder and topBorder from collision to config
        - Finally found out why I was having such a hard time with blockModule scaling: topBorder was in reality bottomBorder, meaning everything was upside down. I wonder how I made it work regardless of that.
    - Collision
        - UnknowEntityException
            - I didn't like having Exception("Unknown entity") everywhere so I did this.
            - I included it in the same file as it's quite small
        - We now have names for different types of collidables. Functionally the same, but the code is more readable.
            - We probably will have to integrate it more thightly to layers once we have entity managers using tilemaps.
    - Pooling
        - Pooler
            - Sorted methods to alphabetical order.
            - Defragment method no longer virtual as inherting will not be supported.
                - I scrapped the original idea for custom poolers to avoid unnecessary complexity and to have less code to maintain.
                    - Going with entity managers (see blockManager) instead.
        - Poolables
            - Removed identifiers as ReferenceEquals was enough.
            - PoolablesEntity
                - Removed Color because not every entity needs it and ones that do override it anyway.
                - Add method is no longer virtual (never should have been)
                    - I always thought override was overwrite but turns out it's not
                        - huh

- Fix block crash and faulty object disabling
    - The root cause for the crashes were that I didn't set blocks firstModule to null when disabling it, because of that after every block had been used one they would spawn incorrectly as part of their spawning logic relies on firstModule being null.
        - I fixed it as part of improving pooling system, we now use base() more often and id is readonly as it was supposed to be.
            - Removed HasAvailability as it was only used by Block and it's not as relevant as it used to be.
            - Renamed Pooler: Sort() -> Defragment() and Poolable(s): Enable -> Active.
                - Also Active = false is now the same as Disable().
                    - Moving worms to a tilemap-module hybrid (graphics owned by worm, not modules) will remove the need for Poolable.Active to be virtual.
            - Also fixed a faulty edge-case logic (line 142 EnableIndex == endIndex is also true when the pool only has one object available)
            - Rewrote the documentation in a way that it uses common programming concepts instead of concepts I've created. (poolable -> object)
            - Player enabling is less hacky.
            - I'll have to see if I can get rid of Id once blocks have been moved to a tilemap based system.
    - Renamed Mathf -> FastMath
        - Got rid of unnecessary functions.


# 11.08.2020
- Add collision visualization toggle
    - Brought back concept.svg
        - It doesn't really reflect current goals or mechanics but it's fun & cute!
    - Debug research:
        - The stack overflow is caused some weird cyclical references between two (multiple?) blockModules. This only seems to happen after sorting has happened which shouldn't be the case.
            - Sorting the module pool seems to mess things up. Or / and restarting. I'm going to go bed now and hopefully fix this mess during the day.
            - Block pooler also runs out of blocks.
        - The system just seems to break more and more the more I investigate.
            - I swear this was working just fine at some point, I have no idea what happened.


# 10.08.2020
- Simplify worm GraphicFollow
    - I player around with Otters surfaces (autoclear off) and during that found that manipulating worm position AND graphic positions were kind of laggy during direction changes, so now I only manipulate graphic positions.
        - Due to this, worm.Position cannot be used properly anymore.
            - But to the point: I could render worm of *any length* with only three renders (head, tail, eraser), but manually clearing old graphics opened a can of worms with framerate related stuff so for now I've decided to revert those changes.
                - It would work flawlessly with Game.FixedFramerate = false, but since worm movement isn't framerate-independent, it's not a viable fix.
                    - I could restrict the framerate with RTSS as I did before for the GPU usage issue, but that's too hacky. Maybe turning VSync on from GPU control panel could be enough? (untested)
                    - I also one other way of optimizing worm rendering (worm using modules as needed & scaling them on-the-fly) so that's why I didn't pursue this further yet.
                    - This way could still be valid if I could untie worm speed from framerate.
                        - Although I fear that opens a whole another jar of worms with floating point and division inaccuracies.
                            - I've said it before and I'll say it again: this is an educational project and doing stuff the wrong way to figure out & being confident in the right way is okay even if it takes a ton of time.
    - This is something I might revert later on, we'll see.
- Remove wormWarning
    - To further simplify things. It's easy enough to re-implement later on.
    - More unrelated thoughts:
        - If I went with the Surface with no autoclear approach to worm rendering, I probably should Implement a separate eraser system which could use the current block scaler for erasing disappearing blocks and worms.
            - This approach would probably cause lots of unnecessary complexity but I still kind of want to explore it as there are nice performance gains to be had.

- Cleanup
    - File organization (GameObject -> Entity, Entity/Block, Entity/Worm)
    - Pooling
        - Renamed PoolableObject -> Poolable
        - Pooler
            - Got rid of unnecessary #if DEBUG statements
            - Apply DRY to Reset method
            - Changed Sort from private -> public virtual to prepare for moving blocks to tilemap (custom Pooler)
        - Known issues: Blocks sometimes don't spawn (near the end) and BlockModules cause stack overflows. Committing in broken state and returning to master branch with the same config to see if these issues existed back then.
            - I'm back from master branch and these stack overflows also exist there. How have I not noticed these before?


# 09.08.2020
- Update documentation
    - Merge to master
    - How to make the game better:
        - Tested tilemaps, they can use colors and only take up one entity and one render. This is the way to implement blocks
        - Dived further into otter examples, found surfaces. Surfaces don't have to clear before rendering: meaning that they are probably the way to implement worm rendering.
            - We'll still need one module per worm length, but we don't need a render per worm length as we'll only render the worm head and clear at the end. Meaning that worm of any length will only take up two or three renders.
        - With the aformentioned improvements to rendering, I hope I can achieve even more massive scale. (going from thousands to tens of thousands)
        - Also began work on the budgeting tool UWP app. It's kind of confusing, but there are a lot of parallels to JavaFX development.
            - For now the repo is private as I still have lots of things to figure out, hopefully it will be completed before next summer.
                - I would really like to continue working on this worm game.


# 30.07.2020
- Add restart
    - Press R to restart.
    - Due to this Players are now poolable entities.
        - Don't really benefit from pooling but restarting is easier.
    - Poolers can now be Reset.
        - Disables all entities and sets EnablingIndex to 0.


# 29.07.2020
- Remove block visualizer
    - Not required anymore as the system is pretty much set in stone and if need be can be brought back to life from previous commits.
    - Other stuff:
        - Also updated previous commit in changelog
        - Researched if I could use native resolution by default, didn't find an easy way, added 800x600 minimum resolution safeguard.
        - Tested four gamepad and a keyboard player simultaneously. Works well!

- Fix blockModule collision on disable
    - Other stuff:
        - Adjust controls
            - Joining and posessing now share the same button.
            - It's no longer possible to leave the game once joined.
        - Clean up Config
        - Update documentation
        - Somehow managed to improve framerate dramatically?
            - I suspect config cleanup (some pooler probably had too many poolables) but hey I'll take it.
                - Benchmark (200x100, worm length 6, all blocks):
                    - Desktop (i7-4790k, GTX 1080): AVG FPS: 48,0, Update 6ms, Render 9ms (3701 Entities, 5466 Renders)
                    - Laptop (Surface Laptop 3):    AVG FPS: 11,1, Update 14ms, Render 50ms (3700 Entities, 5480 Renders)
                        - Please note that update and render are not reliable metrics as they fluctuate a lot, but they can tell about the load between CPU / GPU
                        - I have now realised that the entity based approach I took was dumb performance-wise. Blocks would probably be way more performant as a tilemap (it's some Otter thing, haven't tried it).
                            - Things to do to improve performance:
                                - Change blocks to master entity model (previously referred to as triplet entity)
                                    - Either after doing or skipping that, change it to tilemap. (Some Otter thing, need to research).
                                - Change worms to use scalable rectangles instead of multiple circles.
                            - Things I want to do:
                                - Score counter with particle system (blocks explode when disabled)
                                - Intro animation
                            - Things I need to do:
                                - Test multiple players (I have four xbox controllers, just haven't bothered to hook them up)


# 28.07.2020
- Improve BlockModule merging
    - System is now at the level of best (see old / okay / best comparison from yesterday)
    - Benchmark (200x100 field filled with blockified worms at the length of 6)
        - okay: 25,8 AVG, Update 12ms, Render 12ms.
        - best: 28,0 AVG, Update 11ms, Render 10ms.
    - Best also further decreases our renderers amount from okays ~7 300 to ~5 500.
        - There's ~3 700 entities and ~5 500 meaning that the average block uses 1,48 which when compared to old systems 6 is great!
        - The improvements aren't as dramatic as from old to okay, but I'm really happy:
            - Performance is increased by 81%! (Compared to old system, 15,4 * 1,81 = 27,874).
                - Compared to okay the performance is improved by 6%.
            - The code is clean, I finally understand how graphic origins and positions work (beware worms).
            - It might be a bit CPU-heavier than previous systems (for loops and recursion) but they're used smartly and it improves performance more than it decreases it.
    - Sidenote: keyboard is now the fifth player. I'm going on a trip and I don't want to carry a controller with me so ¯\\_(ツ)_/¯
        - It's not recommended to use the keyboard as playing with it sucks. It doesn't have any kind of input queuing and I can't bother to implement one so it will miss individual keystrokes, but it's usable if you hold the desired direction key instead of tapping it.
    - Next step: clean up the code, merge to master, continue work on new features.
        - Further optimization: transform block system from modular entity to a triplet entity (blocks -> block -> blockModule) this way blocks can be PoolableObjects instead of PoolableEntities. Of course PoolableObjects aren't free, but I'm still expecting improved Update performance (currently 11ms).
            - This would drop the entity amount (at the benchmark situtation) from ~3 700 to 2. Definitely worth pursuing.


# 27.07.2020
- Add BlockModule merging (broken)

              (Current)
        Old     Okay    Best
                  
        5x6 1   3x4 1   1x1 1
        x   x   x   x   x   x
        4x3x2   2x2x1   1x1x1
                                                   
        x = worm connection, [number] = blockModule (doesn't necessarily respect worm connections)
    - Currently the okay system is broken. It cannot produce 1x1 blocks.
    - Benchmark comparison (200x100 field filled with worms the length of 6 turned into blocks)
        - old:  15,4 AVG FPS, Update 18ms, Render 27ms.
        - okay: 27,0 AVG FPS, Update 11ms, Render 11ms.
    - That's a 75% improvement! (15,4 * 1,75 = 26,95).
    - The system is worth the effort.

- Fix blockModule merging (disabling breaks collision)
    - It's done! The system works well and I fully understand how it works.
        - Collision after disabling is still broken: previously I used to set / unset collision with blockModule positions, but now that they dont map 1:1 cells we need something more sophisticated.
    - Benchmarks
        - okay (broken):    27,0 AVG, Update 11ms, Render 11ms.
        - okay (fixed):     25,8 AVG, Update 12ms, Render 12ms.
    - The performance from broken to fixed is pretty much what I expected. Broken was more performant because it couldn't spawn 1x1 blocks.
    - The okay system **more than halved** our renderers amount (20 001 -> ~7 300) when a 200x100 field is filled with blocks.
    - Ramble about variables and project length:
        - On the programming courses I took we were told that memory is cheap, but reserving space from memory is not.
            - To keep the game performant, I try to avoid as many new() calls during runtime as possible. (Hello, pooling system.) I also try to avoid local variables but those are probably a non-issue.
        - The game seems performant and even though during times it's a pain in the ass to avoid new() calls I'd like to think it forces me to write better, more performant code.
        - Initially I estimated the project to take a month. Which was realistic, I just got carried away with things and properly studying otter probably would've saved me like a week of work.
            - My next project is not a game and I had a goal of starting it *this month*, but now the goal for that is starting it *during next month*.
                - It's a budgeting tool and originally I was thinking of Java + JavaFX and SQLite as that's what we did during Programming 2, but now I'm thinking of WinForms or WPF and C# + SQL (SQLite?)


# 24.07.2020
- Add spawn animation for worms (WormWarning)
- Update configuration file loading
- ~~Added settings.cfg from bin path to git, pretty sure that actual binaries won't be included.~~
    - ~~Just so there's no duplicates.~~
- Bunch of smaller fixes and improvements here and there
- When pooling entities they no longer have to be manually added later on
- Began work on optimizing block rendering:
    - Currently block consists of multiple 1x1 modules: this can be optimized by scaling the modules so they can be 3x1, 1x5 etc.
        - Benchmark with the old system: 200x100 field filled with blocks: 15,4 AVG, Update 18ms, Render 27ms.
- Found a possible bug: wormPercentage doesn't work properly? Although might be limited by pool. Anyway not critical.


# 23.07.2020
- Fix BlockModule overusage by fixing worms Grow -method
    - The root cause was the way how worms grow when they eat fruits.
        - The worm would kind of eat the fruit before it had really even eaten it (the fruit is consumed when the worm detects it's about to move on top of it)
            - The worm also grew instantly (currentLength was increased) when it detected that.
        - Now the worm has overlapping parts when it has moved onto the fruits position, but currentLength is increased naturally.
            - Also Grow method in now used when we spawn the worm, we got rid of a nice amount of code.


# 19.07.2020
- New direction for game mechanics
    - When worms gets stuck, it turns into a brick
    - If two same-color bricks are next to each other, they disappear.
    - Player / Ghost no longer posesses with color, but rather the ghost now stays on top of worms head.
    - Game sustains x amount of worms at all times.
    - Not all of this will get done today, but I like it better and it turns a problem (worms getting stuck) into a feature! :D
    - Also bricks are now modular entities.
- Clean up player class
    - Also did a bunch other stuff but uh oh
    - Renamed project to worm-blocks from worm-bricks
        - Updated README.md
- Investigating bugs
    - Probably changed a bunch of stuff, but most importantly made nicer debug messages for pooling. :-)
        - This isn't a good look. Perhaps I could later on update here what I actually changed? ("we'll fix it in prod") lol like that's going to happen.
    - The bugs are hard to debug as, well I don't really have the means to reproduce them in the exact same manner every time.
        - Sometimes worms have tumors, probably due to WormModules not being reset properly between recycles.
            - This shouldn't be the root cause anymore as I applied some dumb safeguards.
        - Sometimes blocks spawn outside of the play area. I suspect worms turning into blocks before they have fully ramped up (they have overlapping parts)
            - BlockModule pooler keeps going empty before it should, probably due to overlapping BlockModules due to the thing explained in the line above
            

# 18.07.2020
- Fix worm entity model
    - Okay so now the multi-object entity model (architecture? idk) is properly implemented to worms and with the test scenario of 200x100 field, worm length of 3 and density of 3 the framerate is in the low 50s (the same as with single entity model), so it really is the best of both worlds!
    - Now the worms can be however long we want like in snake and while one long worm is not as impressive as thousands of smaller worms, it's nice.
- Fix fruit spawning and configuration scaling issues
    - Fruits sometimes spawned inside worms.
    - Field size didn't work with uneven dimensions.
    - Collision visualizer no longer obstructs other console writes.
    - Implemented safeguards to configuration variables.
        - Refresh rate has to be evenly dividable by wormSpeed, if not we subtract wormSpeed by one until it is.
            - Worms move slightly off grid otherwise
        - Minimum field size is 2x2
    - Fixed wormUpdate (wormscene.wormCounter) floating point inaccuracy error with Mathf.FastRound
        - It created a new problem:
            - wormCounter value of 17.625 would get rounded up to 18, which would desync the worms from the grid.
                - Fixed it by changing the +/- value of FastRound from 0.5 to 0.01 which is more than enough since I only use it to deal with floating point inaccuracy.
            - Did the bold move of changing wormCounter check from >= to == so problems would arise more cleary.
                - In theory we shouldn't have any issues thanks to configuration safeguards. But I'm not a perfect programmer.
- Update documentation
    - Nothing special, went through everything and hopefully updated everything that needed updating.
    - I now refer to multi-object entity model as modular entities.


# 16.07.2020
- Fix fruit spawning
    - Fruits were spawning on top each other, fixed that and now we don't get "ghost fruits" anymore.
- EVOLUTION OF WORMS: *multi-entity entity*, *single-entity* and the hopefully final, best of both worlds: **multi-object entity** (modular entity)
    - Worm used to be made out of WormEntities, but now it will be made out of WormParts, which are not Otter2d entities and thus shouldn't be as performance-heavy.
        - This requires bringing back the old, flexible **pooling system** which makes it possible to pool non-entity objects.
            - Also I was proud of it so I want to keep it and this is a great excuse for that
            - Also now that it has been brought back, I'm happy with the WormGame.GameObject namescape name, before it only contained Entities but I can't call it that due to conflicts with Otter (d'oh)
    - I can replace maxWormLength with minWormLength, because WormPart amount is just width * height and WormAmount is that amount divided by minWormLength.
        - Also it's no fun that worms have a max length.
    - Even though *single-entity* model is good enough for bricks, I'm thinking of bringing them over to *multi-object entity* model once it has been proven to be great with worms, because embracing the modular nature of entities produces cleaner code. Right now with *single-entity* model Brick.cs is awfully bloated, constantly compensated with ifs and probably heavier than it needs to be because of all the (unnecessary) for loops it has to make the code manageable.


# 15.07.2020
- Hello! I've been negleting updating changelog and working on a bunch of boring stuff, here's a little status update:
    - Configuration can now be loaded from a file (settings.cfg), the file has to be in the same folder as the executable.
        - The application is riddled with hidden bugs right now, most emerging from different configurations.
    - Read a book! It's called 14 Habits of Highly Productive Developers and well now I know I really should be testing and measuring more.
        - Going to add tests everywhere I can and merge to master soon.
        - Although I'm not even a junior developer yet and I'm trying to improve so perhaps I can be forgiven for my bad habits at this stage.
    - I've fully switched over to single-entity model, as it's WAY MORE PERFORMANT than the old model.
        - Spending some time reading the documentation is a really good idea, future me.
        - I decided to do this so I could simplify the pooling system, but now the project doesn't show my usage of generics as much :(
            - See <https://github.com/anvemaha/worm-blocks/tree/6e8e8e0794b29cb76de68f59b70f1b3c006bb2ae/WormGame/Pooling>
    - I checked out Otter2ds' discord server and I don't seem to be the only one having a GPU usage issue lol.
        - Apparently Otter is using whatever the OS gives it.
        - Otter (SFML?) might have memory leaks? Apparently shutting down the application by pressing escape skips some important destructors.
            - Haven't noticed it myself.
                - It's fixed?
    - Soon I'm going to have to abandon this project to move on to my next summer project (Java + SQLite personal budgeting program)
        - There's still some features I want to finish, but whatever happens I'll start the new project this month.
            - Complete bricks (really messy)
            - Separate Player.cs to Ghost.cs and Player.cs
            - Make the game "playable" with multiple players
                - Playable in quotes because it's not even close to a game I'd release.
            - Look into some basic texture pack system.
            - Iron out any know issues (excluding GPU usage because that's beyond what I have the skills for)
            - Leave the project in an maintainable state (add missing documentation, improve current documentation and add tests)
                - Also maybe do some doodles about how different class are interlinked so I have a better mental model and perhaps could spot some issues.
    - Controls.cs is dead again. It wasn't flexible enough and the current dumb system is good enough.


# 08.07.2020
- Been working on making worms move smooth, which led to me accidentally improving collision and pooling and overall code structure.
    - Big commits (bad) but once I hammer the last bugs with worms we have a really solid foundation to build on.
    - Also updated documentation here and there because the bug is really weird and I've been avoiding fixing it.
- Poolers can now pool all kinds of things! No more just entities but non-entity objects too!
- Fixed collision field floating point inaccuracy, renamed a bunch of methods and wrote better documentation.
- GPU usage issue is not solved? Sometimes it's fine, sometimes not. Maybe I'm doing something weird with pooling that causes it?
- Been focusing on making code readable and avoiding code structures that I don't have to compensate for all the time.
- Also wrote some tests, but I should write more. It's not really TDD if you write the tests after the code works.


# 05.07.2020
- Upgraded Otter to 1.0 from 0.9.
    - GPU usage issue seems to be resolved.
- Brought Controls.cs back to life to be used with bricks
    - Bricks have a weird bug I can't debug where sometimes they only partially rotate when moving horizontally


# 01.07.2020
- Trying to do less massive commits, getting into the good habit of small commits.
    - Pretty sure my professor said during a lecture that small commits are a good practise.
- Improve collision visualizer
    - Use Console.Top and Console.Left to avoid freeze from Console.Clear()
- Add indexing to worms
    - I can now refer to worms body parts with an indexer, achieving cleaner code
- Fix collision system inaccuracy
    - I was using current position (tweened) instead of target position
- Rename project folder
    - Delete old project folder
        - I had to do a separate commit because I forgot to delete it lol
    - I just wanted to get rid of WBGame because it reminds me of Warner Bros and rocksteadys Arkham games
        - It's probably not a good practise rename entire folders, but at least I know to pick better ones from the start in future projects
- Delete CONTEXT.md
    - Changelog is all I need, plus I have some designs on actual papers.
- Fix worm indexer
    - I had confused enumerator and indexer, now I know which is which.
- Divide Helper to Mathf and Random
    - To make the code more readable
    - Also fixed FastAbs()
- Update documentation
    - Goal is to fix any known bugs and merge to master sometime soon.
    - I've noticed I've (by accident) pushed non-compiling code into the dev branch.
        - Just a note to myself to be more careful
- Cleanup **MERGE TO MASTER**
    - Woo! Finally documented all the code and merged it to master. TOMORROW I CAN FINALLY START WORKING ON NEW STUFF!
- Add tests to Mathf


# 30.06.2020
- Cleaned up the new collision system, it still has bugs but it shouldn't crash.
    - I'm going to commit now because I have other things that need my attention and the commit is probably already way too massive
        - I should get into the habit of smaller commits, as afaik that's the best practise and especially important when working with a team


# 29.06.2020
- ~~Interestingly 100% GPU usage (coil whine) without RTSS is no longer an issue. Not sure what caused it or what fixed it.~~
    - I guess now that the game has something to calculate it's not running insanely fast.
    - I should try to reproduce it and open an issue on the Otter2d repo?
    - I'll keep task manager open just in case
        - **GPU usage still is around 50 % which still is way too high, I enabled RTSS again and the usage is now below 10% and no coil whine.**
- I think I finally figured out how to move entities at the a constant speed no matter the framerate
    - Thank you Game.MeasureTimeInFrames = false;
- ~~Began work on ~~Field~~ Chunks (I would've called it Grid but Otter already has something called Grid)~~
    - ~~I'd also like to note that I'd prefer the name PlayArea, but it's too long and Area isn't nice.~~
    - ~~It just made sense to combine Field and ChunkManager~~
    - This became the new collision system, see below.
- Updated Pooler documentation
    - Pooler got updated yesterday; it now uses defragmenter and should be way more performant at large scales
- Deleted CONTROLS.md as they're now documented well enough in the Player class
- Renamed PLANNING.md to CONTEXT.md that I'll use as a brain dump from time to time
- Renamed methods in Worm so that they better reflect what they do
- Merged Manager to WormScene
- **New collision system**
    - Ditch multiple small chunks in favor of one big chunk that I'll refer to from now on as field.
    - I'll treat null values as empty, let's see if I'll regret this
    - The system has to constantly convert floats to ints and it hurts just a little bit, but it's probably fine.
        - I tried approach where Poolables had extra fields called GridX and GridY which would've been the worms position on the grid as ints and I would convert ints to floats when updating the position, but everything got really messy and confusing.


# 28.06.2020
- Thoughts:
    - I've been working on an entity based tetris blocks and while I probably could make it work, I'm worried it won't be very performant..
    - Took a closer look at Otter examples and surprisingly it has tilemaps which are exactly what I wanted.
        - I could make the tetris part of the game use tilemaps and probably most of the difficult code I written probably would work with minimal changes, I don't know.
        - I mean if I'm moving to tilemaps, why not also use it for worms?
        - I'd like to stick with the entity based approach I've chosen just for the sake of exercise and learning why it might be a bad idea.
        - Tilemap would solve all of my collision issues and I don't really have a use for infinite playfield that the entity based approach allows.
            - I should ditch the current (very basic) collision system in favor of chunk based approach.
                - One chunk would probably be like 8*8, every chunk would know its neighbours and the entities it contains
                    - It would probably have an array of poolables or I remember reading that Notch really regretted minecraft treating air blocks as null values maybe rather an int array and the integers in that would represent indexes in the chunks Poolable array
                    - I will probably get rid of tweening for the worm body parts to keep things simple.
                    - Player ghosts would operate outside of chunk system because they don't have collision.
                        - But they will still know the chunk they're in so they can posess worms efficiently
                    - Chunk system will probably have its own manager just to keep the current manager from getting bloated.
                    - I think worms will still stay intact as is and the chunk system will hook into from where collision is currently done.
                        - Although worm (head) has to know the chunk it is in to access the collision system but otherwise nothing
                - It will probably have some overhead, but will scale WAY better than the current system.
                    - And scalability is what I want. It's way more impressive to show A TON OF WORMS on the screen simultaneously rather than just a few with crappy controls
    - I should keep changelog more up-to-date with my changes, I've implemented lot of stuff I haven't really mentioned here and it's not a good look.
    - Before I can really start working on chunk collision I'll have to implement some kind of grid helper so I don't always have to do the math everywhere when I want to put something on the 'grid'
    
- TL;DR: No to tilemaps, embrace entities, pursue scalability with a chunk based collision system


# 27.06.2020
- I'm facing a problem:
    - The new pooling system although is very nice to access elsewhere, has all kinds of nasty side effects. I need back the poolables because entities have to be able to disable themselves because otherwise I'm going to have to compensate WAY TOO MUCH for that in other ways.
    - I'm going to remove lot of the documentation and go through everything step by step and make sure the foundation is solid for future work.
    - I'm dying to work on the teris part of the game
        - I'll probably do the special case for blocks / bunches in the pooler because that's just a more solid foundation
    - I create a new Vector2 array inside Blockify, I'll get rid of it.
    - Manager is kind of bloated?
    - Pooler can't have Poolables accessible via Indexer because it's hacky.
        - I'm going to have to implement ghosts avoid using Indexer


# 26.06.2020
- Okay so, starting to work on the tetris part of the game and some thoughts:
    - Because I really want to use pooling so I can avoid any lag spikes at runtime (new is the enemy), I'm kind of locked into using recursion with blocks. With worms it made sense, but with blocks it feels hacky.
        - I could build some special case into the pooler but that kind of breaks the generic nature of the pooler.
        - I'll try doing things the recursive way.


# 24.06.2020
- Pooler now uses two Lists instead of single array.
    - Now we don't have to if(poolable.enabled) at every point
    - Code might be messy right now
- Removed Poolables (now we just pool Entities)

- Plans for the next coding session: start implementing block rotation / controls, see if any problems arise with the current queuing system.


# 22.06.2020
- Solved the movement queue problem, I was using current position instead of target position when calculating the next target position for the worm


# 21.06.2020
- What got done from yesterdays notes:
    - Head.cs renamed to Worm.cs and it's no longer bloated.
    - Still no grid system but I really like the idea of infinite playspace although it seems to require smart design I'm not sure I'm capable of
    - We have a manager now! It's kind of bloated, but currently don't know how to divide it into nicer bits
        - Look into: does player, worm and manager handle stuff that only belongs to them?
    - Still using the same tweening, I don't want to mess with framerate stuff
        - Although body parts can no longer move diagonally (as much) thanks to Manager.WormUpdate()
    - We have a queuing system for controls! I tried to optimize it but also made it easier to debug by using chars instead of ints and it's probably not as lightweight as I would like it to be.
        - I know "premature optimization is root of all evil" but I was already having performance problems, although in hindsight were caused by the collision system
    - Haven't touched ghosts. They might turn out to be a can of worms performance-wise :s

- Notes for the future:
    - Current collision system is computationally too heavy. Sometimes worms don't execute all moves from their movement queue (controls).
    - The problem is that it's going through so many invidual objects, a few ideas to improve:
        - Divide the game area to some sort of chunks because an individual worm only really needs to be concerned about the worms nearby
            - I don't know how to do this efficiently (should research)
        - Use the collision system provided by Otter? Don't know if it really fits here
        - Make poolers so that we don't go through all pooled objects with foreach, but rather the ones that are enabled
            - this would involve using lists and don't know if that actually even improves things that much. It would be messier inside but probably nicer on the outside
        - Pooler for non-entity objects. Right now I'd need it for blocks.
- Not too happy with the way I have named the new things I've added, I'll think about them later on
- Now I'm going to clean up, document and add tests where it makes sense.
- Did some design work (in my head :s) on the blocks (see block.cs and leader.cs)
    - Idea was to use the same data structure as worms but I can use a better one if I can initialize the manager with a max worm length
    - Group of blocks would be called Bunch. Bunch can tell if the blocks can fall by one and just moves the blocks where they're needed.
    - Once the bunch has hit the bottom, it's no longer needed, BUT the blocks would stay on the game area
        - Putting a pin on this I need to figure out other stuff first
- Extreme Programming all the way lol (not sure if it makes sense here because I am the customer and the developer)
- My comments probably have a lot of spelling errors


# 20.06.2020
- Been doing miscallennous work, time for a more major rework
    - Head.cs has gotten bloated and takes care of a lot of stuff that really should be handled by some sort of a manager
    - Currently no grid system exists and the play area is basically infinite
        - Something has to be setup and that could be handled by the aformentioned manager
    - Some sort of global constants like framerate and grid size, worm/brick + grid size should also be done
        - It will get increasingly difficult to retrofit those even though I know they have to be done at some point
        - Instead of the current tweening for the worms bodyparts that allows worms to move diagonally when moving fast enough I think I could bake some sort of a curve to an array when initilazing the game if I know the framerate.
            - We're going to need some sort of queuing for the keystrokes so the game still feels responsive but we're also going to need a less frequent update loop (maybe achieved with coroutines in the WormGame.cs or Manager class?) where the positions are updated.
                - I'm kind of worried that the collisions system I currently have in place doesn't scale too well although I think I could perhaps optimize it by dividing it to some sort of chunks, but premature optimization is the root of all evil so I'll put a pin in that.
            - We'll worry about making things suitable for variable framerate later on
    - I'm pretty happy with the pooling system. Even though the line to spawn something is a bit complicated, I like it.
        - We can simplify spawning by having a separate method for it in the manager class (that's how you're supposed to do it with OOP?)
    - At some point I'm going to have to worry about how to implement the ghosts, but that seems easy enough to retrofit so I'll push that aside for now
- Apparently I'm now using changelog as some sort of a blog. Deal with it.


# 15.06.2020
- Designing new systems (collision, movement) and how they interact
- Improved pooling system


# 14.06.2020
- Basic generic entity pooling done
- Worms now have their body parts in pools
- **NOTE**: I know I'm probably using too much inheritance and the smart way to do things would be the component system that Otter has. I checked it out and it seems awesome, BUT I'm going to go down the inheritance rabbit hole to see how much problems it's going to cause. Kind of like how I learned that rewriting git history in a branch already pushed to remote is a really bad idea by having tried it. **The goal is to become a better programmer and not to make a game.**


# 12.06.2020
- Basic WormGame done
- Different scenes are in different files 
- Began work on AreaGame (Grid) and Pooling
    - **NOTE:** The names I pick for things seem to often overlap with some premade Otter stuff. Probably if I just wanted to make a game I'd have to do much less work, but the point is not to learn Otter but rather learn keyboard shortcuts (web browser, windows, visual studio), git commands / github, markdown, windows terminal and get some practise in OOP.


# 11.06.2020
- Visual Studio, Otter, ComTest setup done
- MIT license
- Otter\Utility\Debugger.cs line 128 changed Key.Tilde -> Key.Home so I can use the Otter in-game debug console (finnish keyboards don't really have a tilde)
- Known issue: nearly 100% GPU usage, as a temp fix I'll limit the framerate with RTSS