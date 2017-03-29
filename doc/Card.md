# Card
game action object  

## To Create New Card Type
1. add enum in [Card.cs](Assets/Scripts/_Sources/Game/Card/Card.cs)
2. create blueprint with name Card_enum where **enum** is enum name define in (1)
    - blueprints guide [read](#card-blueprint)
3. add to [GameSetting](Assets/Resources/Game/Core/_Setting/GameSetting.asset) in inspector under CardSetting/DeckSetting/Deck

## Card Blueprint
**ResourceComponent**
- SpritePath = path to ability image
- BasePrefabsPath = "Game/Card/_Prefabs/Card_MiniSize"

**AbilityComponent**
- AbilityClassName = namespace.classname of ability class
- Ability = null (this will be auto generate from class name)




