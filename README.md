# REST_API_Test_Task
Автор - Скапинцев Никита Александрович

Задача - https://github.com/Sense-Capital/jobs/blob/main/back-task-1.md

База данных - postgreSQL

Модели:
- "Game" - Хранит данные игровой сессии:
  - int "Id"
  - string "CurrentSign" - Текущий ход игрока крестик\нолик, приводится к string от enum "Sign"
  - string "Field" - игровое поле "GameField" записанное в JSON
  
- "GameField" - Игровое поле, методы работы с полем:
  - int[][] Field
  Методы:
  - EditSign(int i, int j, Sign sign) => void
  - IsCellFree(int i, int j) => bool
  - CoonvertToJson() => string
  - GetFromJson(string json) => GameField
  - WinCheck() => bool - проверка всех вариантов победы
  - WinCheckHorizaontal() => bool
  - WinCheckVertical() => bool
  - WinCheckDioganal() => bool

- "Outcome" - итоги игры
  - 
