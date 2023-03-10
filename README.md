# REST_API_Test_Task
Автор - Скапинцев Никита Александрович

Задача - https://github.com/Sense-Capital/jobs/blob/main/back-task-1.md

База данных - postgreSQL

Модели:
- "Game" - Хранит данные игровой сессии:
  - integer "Id"
  - text "CurrentSign" - Текущий ход игрока крестик\нолик, приводится к string от enum "Sign"
  - text "Field" - игровое поле "GameField" записанное d JSON
  
- 
