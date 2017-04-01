# Ability
most of game event, effect is in here

# To Create New Ability
first create a class that extend  [Ability](Assets/Scripts/_Sources/Game/Ability/Ability.cs)  
then implement the interface for type of ability you want

## Available Ability Type

### Active
- [ITargetAbility](Assets/Scripts/_Sources/Game/Ability/ITargetAbility.cs)  
    - ability that use on target

### Passive
- [IOnDeadAbility](Assets/Scripts/_Sources/Game/Ability/IOnDead.cs)  
    - called all of this in box when hp drop to zero
- [IReviveAbility](Assets/Scripts/_Sources/Game/Ability/IReviveAbility.cs)
    - called one of this in box when hp drop to zero