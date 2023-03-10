using REST_API_Test_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class GameFieldTests
    {
        [Fact]
        public void HorizontalTest()
        {
            GameField gameField = new GameField();
            gameField.Field = new Sign[3][]
            {
                new Sign[3] {Sign.O, Sign.O, Sign.O },
                new Sign[3] {Sign.None, Sign.None, Sign.None },
                new Sign[3] {Sign.None, Sign.None, Sign.None }
            };

            Assert.True(gameField.WinCheckHorizaontal());
        }

        [Fact]
        public void HorizontalTest2()
        {
            GameField gameField = new GameField();
            gameField.Field = new Sign[3][]
            {
                new Sign[3] {Sign.O, Sign.O, Sign.None },
                new Sign[3] {Sign.X, Sign.X, Sign.None },
                new Sign[3] {Sign.None, Sign.None, Sign.None }
            };

            Assert.False(gameField.WinCheckHorizaontal());
        }

        [Fact]
        public void HorizontalTest3()
        {
            GameField gameField = new GameField();
            gameField.Field = new Sign[3][]
            {
                new Sign[3] {Sign.O, Sign.X, Sign.O },
                new Sign[3] {Sign.X, Sign.X, Sign.O },
                new Sign[3] {Sign.X, Sign.O, Sign.X }
            };

            Assert.False(gameField.WinCheckHorizaontal());
        }

        [Fact]
        public void HorizontalTest4()
        {
            GameField gameField = new GameField();
            gameField.Field = new Sign[3][]
            {
                new Sign[3] {Sign.X, Sign.X, Sign.None },
                new Sign[3] {Sign.O, Sign.O, Sign.None },
                new Sign[3] {Sign.None, Sign.None, Sign.O }
            };

            Assert.False(gameField.WinCheckHorizaontal());
        }

        [Fact]
        public void VerticalTest()
        {
            GameField gameField = new GameField();
            gameField.Field = new Sign[3][]
            {
                new Sign[3] {Sign.O, Sign.O, Sign.O },
                new Sign[3] {Sign.None, Sign.None, Sign.None },
                new Sign[3] {Sign.None, Sign.None, Sign.None }
            };
        
            Assert.False(gameField.WinCheckVertical());
        }
        
        [Fact]
        public void VerticalTest2()
        {
            GameField gameField = new GameField();
            gameField.Field = new Sign[3][]
            {
                new Sign[3] {Sign.O, Sign.O, Sign.None },
                new Sign[3] {Sign.X, Sign.X, Sign.None },
                new Sign[3] {Sign.None, Sign.None, Sign.None }
            };
        
            Assert.False(gameField.WinCheckHorizaontal());
        }

        [Fact]
        public void VerticalTest3()
        {
            GameField gameField = new GameField();
            gameField.Field = new Sign[3][]
            {
                new Sign[3] {Sign.O, Sign.X, Sign.None },
                new Sign[3] {Sign.X, Sign.X, Sign.O },
                new Sign[3] {Sign.None, Sign.X, Sign.None }
            };

            Assert.True(gameField.WinCheckVertical());
        }

        [Fact]
        public void DioganalTest()
        {
            GameField gameField = new GameField();
            gameField.Field = new Sign[3][]
            {
                new Sign[3] {Sign.X, Sign.X, Sign.None },
                new Sign[3] {Sign.O, Sign.O, Sign.None },
                new Sign[3] {Sign.None, Sign.None, Sign.O }
            };

            Assert.False(gameField.WinCheckDioganal());
        }

        [Fact]
        public void DioganalTest2()
        {
            GameField gameField = new GameField();
            gameField.Field = new Sign[3][]
            {
                new Sign[3] {Sign.O, Sign.X, Sign.X },
                new Sign[3] {Sign.O, Sign.O, Sign.None },
                new Sign[3] {Sign.X, Sign.None, Sign.O }
            };

            Assert.True(gameField.WinCheckDioganal());
        }
    }
}
