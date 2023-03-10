using System.Text.Json;
using System.Text.Json.Serialization;

namespace REST_API_Test_Task.Models
{
    [Serializable]
    public enum Sign { None = 0, X = 1, O = 2 }

    [Serializable]
    public class GameField
    {
        public Sign[][] Field { get; set; }

        public GameField()
        {
            Field = new Sign[3][]
            {
                new Sign[3] {Sign.None, Sign.None, Sign.None },
                new Sign[3] {Sign.None, Sign.None, Sign.None },
                new Sign[3] {Sign.None, Sign.None, Sign.None }
            };
        }

        public void EditSign(int i, int j, Sign sign)
        {
            if (IsCellFree(i, j))
                Field[i][j] = sign;
        }

        public bool IsCellFree(int i, int j)
        {
            if (Field[i][j] == Sign.None)
                return true;
            else
                return false;
        }

        public string CoonvertToJson()
        {
            string result = JsonSerializer.Serialize(this);

            return result;
        }

        public static GameField GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<GameField>(json);
        }

        public bool WinCheck()
        {
            if (WinCheckDioganal() || WinCheckHorizaontal() || WinCheckVertical())
                return true;
            
            return false;
        }

        public bool WinCheckHorizaontal()
        {
            for (int i = 0; i < Field.Length; i++)
            {
                int counter = 0;
                Sign sign = Field[i][0];
                if (sign == Sign.None)
                    continue;

                for (int j = 1; j < Field.Length; j++)
                {
                    if (Field[i][j] == sign)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                        break;
                    }
                }

                if (counter == 2)
                {
                    return true;
                }
            }

            return false;
        }

        public bool WinCheckVertical()
        {
            for (int i = 0; i < Field.Length; i++)
            {
                int counter = 0;
                Sign sign = Field[0][i];
                if (sign == Sign.None)
                    continue;

                for (int j = 1; j < Field.Length; j++)
                {
                    if (Field[j][i] == sign)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                        break;
                    }
                }

                if (counter == 2)
                {
                    return true;
                }

            }

            return false;
        }

        public bool WinCheckDioganal()
        {
            if (Field[1][1] == Sign.None) return false;

            if (Field[0][0] == Field[1][1] && Field[2][2] == Field[1][1])
                return true;
            if (Field[2][0] == Field[1][1] && Field[0][2] == Field[1][1])
                return true;

            return false;
        }
    }
}
