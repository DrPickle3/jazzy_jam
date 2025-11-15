# ChatRouleMaBoule

A Unity game project built with Unity 6000.0.62f1 using the High Definition Render Pipeline (HDRP).

## Project Overview

This is a Unity game project featuring player-controlled movement mechanics. The project uses Unity's modern Input System for handling player input.

## Features

- **Player Movement**: Control a ball (Boule) using keyboard/gamepad input
- **Input System**: Uses Unity's new Input System package for flexible input handling
- **HDRP**: Built with High Definition Render Pipeline for high-quality graphics
- **Multi-input Support**: Supports keyboard, mouse, gamepad, touch, and XR controllers

## Prerequisites

- **Unity Editor**: Version 6000.0.62f1 or compatible
- **Required Packages** (automatically managed via `Packages/manifest.json`):
  - Unity Input System (1.14.2)
  - High Definition Render Pipeline (17.0.4)
  - Cinemachine (2.10.4)
  - Unity Timeline (1.8.9)
  - Unity UI Toolkit (2.0.0)

## Project Structure

```
ChatRouleMaBoule/
├── Assets/
│   ├── Scripts/
│   │   └── Player.cs          # Main player controller script
│   ├── Scenes/
│   │   ├── level_1.unity      # Main game level
│   │   ├── SampleScene.unity  # Sample/test scene
│   │   └── PrefabEditingScene.unity
│   ├── InputSystem_Actions.inputactions  # Input action definitions
│   └── SampleSceneAssets/     # Sample assets and resources
└── ProjectSettings/           # Unity project settings
```

## Getting Started

1. **Open the Project**:
   - Open Unity Hub
   - Click "Add" and select the `ChatRouleMaBoule` folder
   - Ensure Unity 6000.0.62f1 is installed
   - Open the project

2. **Run the Game**:
   - Open the scene: `Assets/Scenes/level_1.unity` or `Assets/Scenes/SampleScene.unity`
   - Press **Play** in the Unity Editor
   - Use WASD or arrow keys to move the ball

## Controls

### Player Actions

- **Move**: WASD / Arrow Keys / Gamepad Left Stick
- **Look**: Mouse / Gamepad Right Stick
- **Attack**: Left Mouse Button / Gamepad Button West (X/Square)
- **Jump**: Space / Gamepad Button South (A/Cross)
- **Sprint**: Left Shift / Gamepad Left Stick Press
- **Crouch**: C / Gamepad Button East (B/Circle)
- **Interact**: E / Gamepad Button North (Y/Triangle) - Hold
- **Previous**: 1 / Gamepad D-Pad Left
- **Next**: 2 / Gamepad D-Pad Right

## Key Scripts

### Player.cs
Located at `Assets/Scripts/Player.cs`

The main player controller that:
- Handles input using Unity's Input System
- Moves a GameObject tagged "Boule" based on player input
- Normalizes movement input for consistent speed

## Input System

The project uses Unity's Input System package. Input actions are defined in:
- `Assets/InputSystem_Actions.inputactions`

The generated C# code is in:
- `Assets/InputActions.cs` (auto-generated, do not edit manually)

## Scenes

- **level_1.unity**: Main game level
- **SampleScene.unity**: Sample/test scene with tutorial assets
- **PrefabEditingScene.unity**: Scene for editing prefabs

## Development Notes

- The project uses HDRP (High Definition Render Pipeline) - ensure your graphics card supports it
- Input System is enabled - the old Input Manager is disabled
- The Player script finds a GameObject with the tag "Boule" at runtime - ensure your scene has an object with this tag

## Troubleshooting

- **Ball not moving**: Ensure there's a GameObject with the tag "Boule" in the scene
- **Input not working**: Check that the Input System package is installed and the Input Actions asset is properly configured
- **Graphics issues**: Verify HDRP is properly set up in your project settings

## Unity Version

This project requires Unity **6000.0.62f1** (Unity 6).

## License

[Add your license information here]
