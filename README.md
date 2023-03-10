# REST_API_Test_Task
Автор - Скапинцев Никита Александрович

Задача - https://github.com/Sense-Capital/jobs/blob/main/back-task-1.md

База данных - postgreSQL

Модели:
  (Храним в бд)
- "Game" - Хранит данные игровой сессии:
  - int "Id"
  - string "CurrentSign" - Текущий ход игрока крестик\нолик, приводится к string от enum "Sign"
  - string "Field" - игровое поле "GameField" записанное в JSON
  
  (Не храним в БД, пишем в JSON и помещаем в "Game" {"Field"})
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

  (Храним в бд)
- "Outcome" - итоги игры
  - int "Id"
  - string Winner - победитель X/O
  - int GameId - id сессии
  
Контроллеры:
- "GameController"
  POST: 
  - NewGameAsync() инициализация новой игры
      Request url https://localhost:7140/api/Game/NewGame
      curl
      {
        curl -X 'POST' \
          'https://localhost:7140/api/Game/NewGame' \
          -H 'accept: */*' \
          -d ''
      }        
      Response body:
      {
        "value": {
           "id": 11,
          "currentSign": "X",
          "field": "{\"Field\":[[0,0,0],[0,0,0],[0,0,0]]}"
        },
        "formatters": [],
        "contentTypes": [],
        "declaredType": null,
        "statusCode": 200
      }
  
  - MoveAsync(Game game, int i, int j, Sign sign) Ход игрока пищем X/O, выполняется проверка победы, в случае победы создается запись в Outcomes
      Request url https://localhost:7140/api/Game/Move?i=0&j=0&sign=1
      curl
      {
        curl -X 'POST' \
          'https://localhost:7140/api/Game/Move?i=0&j=0&sign=1' \
          -H 'accept: */*' \
          -H 'Content-Type: application/json' \
          -d '{
          "id": 11,
          "currentSign": "X",
          "field": "{\"Field\":[[0,0,0],[0,0,0],[0,0,0]]}"
        }'
      }      
      Request body: 
      {
        "id": 11,
        "currentSign": "X",
        "field": "{\"Field\":[[0,0,0],[0,0,0],[0,0,0]]}"
      }

      Response body:
      {
        "value": {
          "id": 11,
          "currentSign": "O",
          "field": "{\"Field\":[[1,0,0],[0,0,0],[0,0,0]]}"
        },
        "formatters": [],
        "contentTypes": [],
        "declaredType": null,
        "statusCode": 200
      } 
  
  GET:
  - GetAsync(int id)
      Request url https://localhost:7140/api/Game/Get?id=11
      curl
      {
        curl -X 'GET' \
          'https://localhost:7140/api/Game/Get?id=11' \
          -H 'accept: */*'  
      }
      Response body
      {
        "value": {
          "id": 11,
          "currentSign": "O",
          "field": "{\"Field\":[[1,0,0],[0,0,0],[0,0,0]]}"
        },
        "formatters": [],
        "contentTypes": [],
        "declaredType": null,
        "statusCode": 200
      }
