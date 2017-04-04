# Ability
most of game event, effect is in here

# To Create New Ability
first create a class that extend  [Ability](Assets/Scripts/_Sources/Game/Ability/Ability.cs),
then implement interface for type of ability

## Available Ability Type

### Active
- [IActiveAbility](Assets/Scripts/_Sources/Game/Ability/IActiveAbility.cs)

### Passive
- [IOnDeadAbility](Assets/Scripts/_Sources/Game/Ability/IOnDead.cs)  
    - called all of these ability when hp drop to zero
- [IReviveAbility](Assets/Scripts/_Sources/Game/Ability/IReviveAbility.cs)
    - called one of these ability when hp drop to zero