# 🎮 MoveIo Game

### Arena Survival Game | Unity | C# | AI Navigation

MoveIo is an arena-based survival game developed using Unity, where players compete against AI-controlled opponents to become the last character standing.

Players navigate the arena, eliminate enemies, collect power-ups, and strengthen their characters as the game progresses.

The project features AI navigation, character state management, projectile-based combat, character progression, and dynamic gameplay mechanics.

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Key Features](#-key-features)
- [Player System](#-player-system)
- [AI Bot System](#-ai-bot-system)
- [Weapon System](#-weapon-system)
- [Level and Progression](#-level-and-progression)
- [Game State Management](#-game-state-management)
- [Gameplay Flow](#-gameplay-flow)
- [Technologies](#-technologies)

---

## 📖 Overview

MoveIo is a survival game where the objective is simple: **defeat opponents and become the last survivor in the arena.**

The game combines character movement, AI-controlled enemies, weapon mechanics, and a progression system.

As characters eliminate opponents and earn points, their size and attack range increase, making them stronger throughout the match.

### Game Objectives

- Survive against AI-controlled opponents.
- Eliminate enemies to earn points.
- Increase character size and attack range.
- Collect power-ups to activate special attacks.
- Become the last surviving character to win.

---

## ✨ Key Features

| Feature | Description |
|---------|-------------|
| Joystick Movement | Control character movement using a virtual joystick. |
| AI Navigation | AI-controlled bots navigate the arena using Unity NavMesh Agent. |
| Combat System | Characters attack enemies within their attack range. |
| Target Detection | Visual indicators identify enemies within attack range. |
| Weapon Mechanics | Characters throw weapons using a projectile-based system. |
| Character Progression | Character size and attack range increase based on accumulated points. |
| Special Abilities | Collect gift boxes to activate ultimate attacks. |
| Bot Management | Manage active bots and respawning throughout gameplay. |
| Dynamic Obstacles | Obstacles become transparent when characters approach them. |
| Game State Management | Manage gameplay transitions using predefined game states. |

---

## 🕹️ Player System

The player controls a character using a virtual joystick to navigate the arena and engage in combat.

### Movement and Combat

- **Joystick Movement:** Players move freely around the arena.
- **Attack Conditions:** Characters must stop moving before entering the Attack state.
- **Attack Range Indicator:** The player's attack range is displayed during gameplay.
- **Target Detection:** When an enemy enters the player's attack range, a targeting indicator appears beneath the enemy.
- **Special Attacks:** Players can activate ultimate abilities through collectible power-ups.

### Player States

The player follows six predefined states:

| State | Description |
|-------|-------------|
| `Idle` | Character remains stationary. |
| `Run` | Character moves around the arena. |
| `Attack` | Character performs a standard attack. |
| `Ulti` | Character performs a special attack. |
| `Die` | Character is eliminated from the match. |
| `Win` | Character becomes the last survivor. |

---

## 🤖 AI Bot System

AI-controlled bots serve as opponents throughout the game.

Bots use Unity's **NavMesh Agent** to navigate the environment and interact with other characters.

### Bot Features

- Navigate the arena using NavMesh Agent.
- Transition between movement and combat states.
- Stop moving before initiating an attack.
- Engage opponents during gameplay.
- Operate without displaying their attack range.

### Bot States

| State | Description |
|-------|-------------|
| `Idle` | Bot remains stationary. |
| `Run` | Bot navigates the arena. |
| `Attack` | Bot attacks an opponent. |
| `Ulti` | Bot performs a special attack. |
| `Die` | Bot is eliminated. |

---

## ⚔️ Weapon System

MoveIo features a weapon system that separates equipped weapons from projectiles.

### Weapon Types

**1. Equipped Weapon**

The weapon attached to the character's hand before an attack.

**2. Projectile**

A projectile generated when the character throws their weapon.

### Attack Mechanism

When a character initiates an attack:

1. The character enters the `Attack` state.
2. A projectile is spawned.
3. The projectile travels toward the target.
4. The equipped weapon disappears from the character's hand.

This system visually represents weapon throwing during combat.

---

## 📈 Level and Progression

The game includes a character progression system based on accumulated points.

### Score System

Characters earn points during gameplay.

When a character reaches a predefined score milestone:

- Character size increases.
- Attack range increases.
- The character becomes stronger as the match progresses.

### Special Abilities

Gift boxes are distributed throughout the arena.

Collecting these boxes allows characters to activate special attacks through the `Ulti` state.

### Bot Management

The game manages:

- The number of active bots currently present in the arena.
- The total number of bots available during gameplay.
- Bot respawning to maintain the intended gameplay flow.

### Dynamic Obstacles

The arena contains environmental obstacles.

When a character approaches an obstacle, it becomes transparent to improve visibility.

---

## 🎯 Game State Management

MoveIo uses predefined game states to control the overall gameplay flow.

### Available Game States

| State | Description |
|-------|-------------|
| `MainMenu` | Displays the main menu when the game starts. |
| `GamePlay` | Activates gameplay when the player selects Play. |
| `GameEnd` | Triggered when the player is eliminated. |
| `GameWin` | Triggered when the player becomes the last surviving character. |

### State Transitions

```text
                ┌───────────────┐
                │   Main Menu   │
                └───────┬───────┘
                        │
                   Press Play
                        │
                        ▼
                ┌───────────────┐
                │   Gameplay    │
                └───────┬───────┘
                        │
                ┌───────┴───────┐
                │               │
                ▼               ▼
        ┌─────────────┐  ┌─────────────┐
        │  Game Over  │  │   Victory   │
        │ Player Dies │  │ Last Alive  │
        └─────────────┘  └─────────────┘
```

---

## 🔄 Gameplay Flow

The gameplay follows these steps:

**1. Start Game**

The game launches into the main menu.

**2. Enter Arena**

The player selects Play to begin the match.

**3. Explore and Fight**

The player navigates the arena and engages AI-controlled opponents.

**4. Earn Points**

Eliminating opponents allows characters to accumulate points.

**5. Character Progression**

Reaching score milestones increases character size and attack range.

**6. Collect Power-Ups**

Players can collect gift boxes to activate special abilities.

**7. End Game**

The match ends when one of the following conditions is met:

- **Game Over:** The player is eliminated.
- **Victory:** The player is the last surviving character.

---

## 🛠️ Technologies

| Technology | Purpose |
|------------|---------|
| Unity | Game development engine |
| C# | Game logic and scripting |
| NavMesh Agent | AI navigation and pathfinding |
| Finite State Machine (FSM) | Character behavior and game state management |

---

## 📌 Project Highlights

This project demonstrates the implementation of several fundamental game development concepts:

- Character movement and combat mechanics.
- AI navigation using Unity NavMesh.
- State-based character behavior.
- Projectile and weapon management.
- Character progression and scoring systems.
- Game flow and state transitions.
- Dynamic environmental interactions.

---

## 📄 License

No license has been specified for this project.

---

**MoveIo Game — Built with Unity**
