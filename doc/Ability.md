# Ability
most of game event, effect is in here

# To Create New Ability
first create a class that extend  [Ability](Assets/Scripts/_Sources/Game/Ability/Ability.cs) 
then define how ability works by implementing abstract method  

- GetTilesArea()
    - method to get tiles to show range of ability
- GetTargetEntity()
    - method to get available target on each tiles in area
    - return null if that tile can't be targeted
- OnTargetSelected()
    - event to do when player select target

to define how ability trigger passively implement the passive ability interface

## Available Ability Type

### Active
- ~~none~~

### Passive
- [IOnDeadAbility](Assets/Scripts/_Sources/Game/Ability/IOnDead.cs)  
    - called all of these ability when hp drop to zero
- [IReviveAbility](Assets/Scripts/_Sources/Game/Ability/IReviveAbility.cs)
    - called one of these ability when hp drop to zero