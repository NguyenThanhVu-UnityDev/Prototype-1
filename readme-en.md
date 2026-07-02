# Prototype 1

A refined C# and physics-driven 3D driving prototype built during the Unity Junior Programmer pathway. 

Unlike the basic tutorial version, this prototype has been refactored to prioritize clean code architecture (following C# conventions and Object-Oriented Programming principles), physics-based vehicle dynamics, and an enhanced user camera control system.

## What I Learned

### [Lesson 1.1 - Start Your 3D Engines](https://learn.unity.com/pathway/junior-programmer/unit/player-control/tutorial/lesson-1-1-start-your-3d-engines?version=6.0)

**New functionality**

- Project initialized and starter environment assets imported.
- Vehicle and road obstacles positioned correctly within the 3D space.
- Initial camera setup adjusted behind the vehicle.

**New concepts & skills**

- **Game view vs. Scene view:** Utilizing the Scene view for spatial layout design and the Game view for player camera checks.
- **Editor Hierarchy & Inspector workflows:** Configuring components and spatial properties on active GameObjects.
- **3D Navigation:** Mastering rotation, panning, and view focusing in three dimensions.

### [Lesson 1.2 - Pedal to the Metal](https://learn.unity.com/pathway/junior-programmer/unit/player-control/tutorial/1-2-move-the-vehicle-with-your-first-line-of-c?version=6.0)

**New functionality**

- **Physics-driven vehicle movement:** Avoided standard `Transform.Translate` positioning. Instead, implemented force-based movement in [PlayerController](Assets/Scripts/PlayerController.cs) using C# physics forces.
- **Stable environment collisions:** Integrated Rigidbody forces and Colliders to prevent vehicles from clipping/glitching through scenery assets.

**New concepts & skills**

- **Code Conventions & OOP Refactoring:** Wrote clean, decoupled code, avoiding hardcoded dependencies and adhering to coding principles (Encapsulation, Inheritance, and Single Responsibility).
- **Time.deltaTime Integration:** Factoring in frame time updates to ensure physics updates scale accurately across different machines.
- **Collider & Rigidbody Physics:** Utilizing Unity's physical engine to determine object interactions naturally.

### [Lesson 1.3 - High Speed Chase](https://learn.unity.com/pathway/junior-programmer/unit/player-control/tutorial/1-3-make-the-camera-follow-the-vehicle-with-variables?version=6.0)

**New functionality**

- **Orbiting Third-Person Camera:** Implemented a camera setup in [FollowPlayer](Assets/Scripts/FollowPlayer.cs) that orbits the vehicle smoothly in third-person space instead of tracking at a static offset.

**New concepts & skills**

- **C# Custom Accessors:** Ensuring clean variable visibility (using private fields with serialized headers or public getters) to protect data integrity.
- **Target Tracking & Interpolation:** Calculating camera offsets dynamically to follow the vehicle without rigid, snapping camera movements.

### [Lesson 1.4 - Step into the Driver's Seat](https://learn.unity.com/pathway/junior-programmer/unit/player-control/tutorial/lesson-1-4-use-user-input-to-control-the-vehicle?version=6.0)

**New functionality**

- **Input-responsive engine acceleration:** Reads vertical inputs to add torque/forces directly to the vehicle.
- **Corrected steering mechanics:** Adjusted rotational physics calculation so that steering inputs do not rotate the vehicle unless it is actively moving (avoiding rotation while standing still).

**New concepts & skills**

- **Vector Physics & Rotational Torque:** Applying forces relative to the vehicle's forward axis.
- **Unity Input Actions:** Mapping controls dynamically using horizontal/vertical axes.

## Extras & Enhancements

- **Object-Oriented Programming (OOP) Compliance:** Reorganized the starter template scripts into clean, decoupled C# components adhering to the 4 core pillars of OOP (Encapsulation, Abstraction, Inheritance, Polymorphism).
- **Rigidbody-based Physics System:** Utilizes `Rigidbody.AddForce()` for acceleration instead of directly translating coordinates. This prevents clipping through obstacles and yields a realistic driving feel.
- **Realistic Steering:** Steering angle calculations factor in current vehicle velocity. The car cannot steer or rotate on its axis unless it is physically moving.
- **Orbiting 3rd-Person Camera:** Allows the player to dynamically orbit the camera around the vehicle using custom input, delivering a more engaging perspective than the fixed-position camera in the tutorial.
