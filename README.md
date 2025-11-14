# Unity Multiplayer Template - Testing Guide

## What This Project Does

This is a **Unity multiplayer game template** built with Unity Netcode for GameObjects (NGO). It demonstrates a simple multiplayer match system with the following features:

### Core Functionality:
1. **Metagame Menu**: Main menu where players can start matches
2. **Match System**: Players join matches with a 60-second countdown timer
3. **Win Condition**: Players can click a "Win" button to end the match early
4. **Match Recap**: Shows results after a match ends
5. **Multiplayer Support**: 
   - Host mode (single player with bots or local multiplayer)
   - Client mode (connect to a server)
   - Dedicated server mode
   - Unity Gaming Services matchmaking integration

### Game Flow:
1. Start at the **MetagameScene** (main menu)
2. Choose to start a single-player match or use matchmaking
3. When enough players connect (default: 2), the match begins
4. A 60-second countdown timer starts
5. Players can click "Win" to end the match early
6. If the timer expires, the match ends in a draw
7. Match recap screen shows the winner
8. Return to the main menu

## How to Test the Project

### Prerequisites:
- Unity Editor (check `ProjectSettings/ProjectVersion.txt` for the required version)
- Unity Netcode for GameObjects package (should be in Packages)
- Unity Gaming Services packages (for matchmaking features)

### Testing Methods:

#### Method 1: Single Player Mode (Easiest)
1. Open the project in Unity Editor
2. Open the scene: `Assets/Scenes/MetagameScene.unity`
3. Press **Play** in the Unity Editor
4. In the main menu, click the **"Start Single Player"** button
5. The game will start in Host mode with bots (if MaxPlayers > 1)
6. You'll see the match view with a countdown timer and a "Win" button
7. Click "Win" to test the win condition, or wait for the timer to expire

#### Method 2: Local Multiplayer (Two Players)
1. **First Instance (Host)**:
   - Open Unity Editor
   - Open `MetagameScene.unity`
   - Press Play
   - Click "Start Single Player" (this starts as Host)

2. **Second Instance (Client)**:
   - Open a second Unity Editor instance (or use Unity's Multiplayer Play Mode)
   - Open the same project
   - Open `MetagameScene.unity`
   - Before pressing Play, configure the client:
     - Go to `Window > Multiplayer > Bootstrapper` (if available)
     - Or create/edit `StartupConfiguration.json` in the project root with:
       ```json
       {
         "OverrideMultiplayerRole": "True",
         "StartAsHost": "False",
         "StartAsServer": "False",
         "StartAsClient": "True",
         "MaxPlayers": "2",
         "Port": "9797",
         "EnableBots": "False",
         "AllowReconnection": "False",
         "ServerIP": "127.0.0.1",
         "AutoConnect": "True"
       }
       ```
   - Press Play - it should auto-connect to the host

#### Method 3: Using Configuration File
The project uses `StartupConfiguration.json` for configuration. The default is located at:
- `Assets/Resources/DefaultConfigurations/StartupConfiguration.json`

You can create a `StartupConfiguration.json` in the project root to override settings:

**For Host Mode:**
```json
{
  "OverrideMultiplayerRole": "True",
  "StartAsHost": "True",
  "StartAsServer": "False",
  "StartAsClient": "False",
  "MaxPlayers": "2",
  "Port": "9797",
  "EnableBots": "True",
  "AllowReconnection": "False",
  "ServerIP": "127.0.0.1",
  "AutoConnect": "True"
}
```

**For Client Mode:**
```json
{
  "OverrideMultiplayerRole": "True",
  "StartAsHost": "False",
  "StartAsServer": "False",
  "StartAsClient": "True",
  "MaxPlayers": "2",
  "Port": "9797",
  "EnableBots": "False",
  "AllowReconnection": "False",
  "ServerIP": "127.0.0.1",
  "AutoConnect": "True"
}
```

**For Dedicated Server:**
```json
{
  "OverrideMultiplayerRole": "True",
  "StartAsHost": "False",
  "StartAsServer": "True",
  "StartAsClient": "False",
  "MaxPlayers": "2",
  "Port": "9797",
  "EnableBots": "False",
  "AllowReconnection": "False",
  "ServerIP": "127.0.0.1",
  "AutoConnect": "True"
}
```

### Testing Checklist:
- [ ] Single player mode starts correctly
- [ ] Match countdown timer displays and counts down from 60 seconds
- [ ] "Win" button ends the match early
- [ ] Match recap screen shows after match ends
- [ ] Can return to main menu after match
- [ ] Two players can connect and play together
- [ ] Bots spawn correctly when enabled

### Key Files to Understand:
- `Assets/Scripts/Runtime/Game/Controllers/GameController.cs` - Main game logic
- `Assets/Scripts/Runtime/Game/Controllers/MatchController.cs` - Match UI handling
- `Assets/Scripts/Runtime/Shared/CustomNetworkManager.cs` - Network setup
- `Assets/Scripts/Runtime/Metagame/Controllers/MainMenuController.cs` - Menu navigation
- `Assets/Scenes/MetagameScene.unity` - Main scene to play

### Troubleshooting:
- **Can't connect**: Check that the port (default 9797) is not blocked by firewall
- **Bots not spawning**: Ensure `EnableBots` is set to `"True"` in configuration
- **Auto-connect not working**: Set `AutoConnect` to `"True"` in configuration
- **Match doesn't start**: Ensure `MaxPlayers` number of players/bots are connected

### Notes:
- This is a **template project** - the actual gameplay is minimal (just a timer and win button)
- The project structure follows MVC (Model-View-Controller) pattern
- Uses Unity's UI Toolkit for the user interface
- Integrates with Unity Gaming Services for cloud matchmaking (requires Unity account setup)

