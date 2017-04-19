# Ability
most of game event, effect is in here

# To Create New Ability
first create a class that extend  [Ability](../Assets/Scripts/_Sources/Card/Ability/Ability.cs),
then implement interface for type of ability

## Available Ability Type

### Active
- [ActiveAbility<TTarget>](../Assets/Scripts/_Sources/Card/Ability/ActiveAbility.cs)
    - active ability on target of type TTarget (:IEntity)
- [SelfActiveAbility](../Assets/Scripts/_Sources/Card/Ability/SelfActiveAbility.cs)
	- active ability on self

### Passive
- [IOnDeadAbility](../Assets/Scripts/_Sources/Card/Ability/IOnDeadAbility.cs)  
    - called all of these ability when hp drop to zero
- [IReviveAbility](../Assets/Scripts/_Sources/Card/Ability/IReviveAbility.cs)
    - called one of these ability when hp drop to zero

### Extra
- [IDiscardAbility](../Assets/Scripts/_Sources/Card/Ability/IDiscardCardAbility.cs)
    - ability that need to discard a number of card to use