# PlayerIcon
the display icon of player which is useless in game :D

### To Create New PlayerIcon
- first add new type of icon in the enum class [PlayerIcon](../Assets/Scripts/_Sources/Addition/Title/PlayerIcon.cs)
- create new data by right click > End > PlayerIcon or dupplicate from old data
    - recommend to put data in **Resources/Addition/Title/PlayerIcon/_Data/**
- config the data
- add to the TitleSetting located at **Resources/Addition/Title/Setting**
- run the test to verify data
    - check that **Test/AdditionTest/TitleTest/PlayerIconSettingTest** is passed