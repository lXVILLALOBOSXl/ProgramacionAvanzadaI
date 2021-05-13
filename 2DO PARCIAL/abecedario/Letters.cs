using System;
using System.Threading;
using static System.Console;

namespace abecedario
{
    class Letters
    {
        public Letters(string input){
            for (int i = 0; i < input.Length; i++)
            {
                
                switch (input[i])
                {
                    case 'a':
                        addLetter(a);
                        break;
                    case 'b':
                        addLetter(b);
                        break;
                    case 'c':
                        addLetter(c);
                        break;
                    case 'd':
                        addLetter(d);
                        break;
                    case 'e':
                        addLetter(e);
                        break;
                    case 'f':
                        addLetter(f);
                        break;
                    case 'g':
                        addLetter(g);
                        break;
                    case 'h':
                        addLetter(h);
                        break;
                    case 'i':
                        addLetter(iL);
                        break;
                    case 'j':
                        addLetter(j);
                        break;
                    case 'k':
                        addLetter(k);
                        break;
                    case 'l':
                        addLetter(l);
                        break;
                    case 'm':
                        addLetter(m);
                        break;
                    case 'n':
                        addLetter(n);
                        break;
                    case 'ñ':
                        addLetter(nn);
                        break;
                    case 'o':
                        addLetter(o);
                        break;
                    case 'p':
                        addLetter(p);
                        break;
                    case 'q':
                        addLetter(q);
                        break;
                    case 'r':
                        addLetter(r);
                        break;
                    case 's':
                        addLetter(s);
                        break;
                    case 't':
                        addLetter(t);
                        break;
                    case 'u':
                        addLetter(u);
                        break;
                    case 'v':
                        addLetter(v);
                        break;
                    case 'w':
                        addLetter(w);
                        break;
                    case 'x':
                        addLetter(x);
                        break;
                    case 'y':
                        addLetter(y);
                        break;
                    case 'z':
                        addLetter(z);
                        break;
                    case ' ':
                        addLetter(voidLetter);
                        break;
                    case '<':
                        addLetter(lowerTo);
                        break;
                    case '3':
                        addLetter(three);
                        break;
                    default:
                        WriteLine("caracter no reconocido aun");
                        break;
                }
            }
            print(inputConverted);
        }

        private void print(string[] inputConverted){
            foreach (var item in inputConverted)
            {
                // WriteLine(item[1]);
                for (int i = 0; i < inputConverted[0].Length; i++) //
                {
                    Write(item[i]); //
                    Thread.Sleep(10); //
                }
                WriteLine(); //
            }
        }

        private void addLetter(char[,] letter){
            for (int i = 0; i < 8; i++)
            {
                for (int x = 0; x < 5; x++)
                {
                    inputConverted[i] += letter[i,x];
                    // Write(inputConverted[i]);
                    // Thread.Sleep(200);
                }
            }
        }


        // a b c d e f g h i j k l m n ñ o p q r s t u v w x y z

        private string[] inputConverted = new string[8] {"","","","","","","",""};
        private char[,] a = new char[8,5]
        {{' ',' ','*',' ',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*','*','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '}};

        private char[,] b = new char[8,5]
        {{' ','*','*','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*','*','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*','*','*',' '}};

        private char[,] c = new char[8,5]
        {{' ',' ',' ','*',' '},
        {' ',' ','*',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ',' ','*',' '}};

        private char[,] d = new char[8,5]{
        {' ','*',' ',' ',' '},
        {' ','*','*',' ',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*','*',' ',' '},
        {' ','*',' ',' ',' '}};

        private char[,] e = new char[8,5]
        {{' ','*','*','*',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*','*','*',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*','*','*',' '}};

        private char[,] f = new char[8,5]
        {{' ','*','*','*',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*','*',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '}};

        private char[,] g = new char[8,5]
        {{' ',' ','*',' ',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ',' ',' '},
        {' ','*','*','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*','*','*',' '}};

        private char[,] h = new char[8,5]
        {{' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*','*','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '}};

        private char[,] iL = new char[8,5]
        {{' ','*','*','*',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ','*','*','*',' '}};

        private char[,] j = new char[8,5]
        {{' ','*','*','*',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ','*',' ',' ',' '}};

        private char[,] k = new char[8,5]
        {{' ','*',' ',' ',' '},
        {' ','*',' ','*',' '},
        {' ','*','*',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*','*',' ',' '},
        {' ','*',' ','*',' '}};

        private char[,] l = new char[8,5]
        {{' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*','*','*',' '}};

        private char[,] m = new char[8,5]
        {{' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*','*','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '}};

        private char[,] n = new char[8,5]
        {{' ','*','*','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '}};

        private char[,] nn = new char[8,5]
        {{' ','*','*','*',' '},
        {' ',' ',' ',' ',' '},
        {' ','*','*','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '}};

        private char[,] o = new char[8,5]
        {{' ',' ','*',' ',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ',' ','*',' ',' '}};

        private char[,] p = new char[8,5]
        {{' ',' ','*',' ',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*','*',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '}};

        private char[,] q = new char[8,5]
        {{' ',' ','*',' ',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ',' ','*','*',' '},
        {' ',' ',' ','*',' '},
        {' ',' ',' ','*',' '},
        {' ',' ',' ','*',' '}};

        private char[,] r = new char[8,5]
        {{' ',' ','*',' ',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*','*',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*','*',' ',' '},
        {' ','*',' ','*',' '}};

        private char[,] s = new char[8,5]
        {{' ',' ','*',' ',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ',' ','*',' ',' '}};

        private char[,] t = new char[8,5]
        {{' ','*','*','*',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '}};

        private char[,] u = new char[8,5]
        {{' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ',' ','*',' ',' '}};

        private char[,] v = new char[8,5]
        {{' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*','*',' ',' '},
        {' ','*',' ',' ',' '}};

        private char[,] w = new char[8,5]
        {{' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*','*','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '}};

        private char[,] x = new char[8,5]
        {{' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ',' ','*',' ',' '},
        {' ',' ',' ',' ',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '}};

        private char[,] y = new char[8,5]
        {{' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ','*',' ','*',' '},
        {' ',' ','*','*',' '},
        {' ',' ',' ','*',' '},
        {' ',' ',' ','*',' '},
        {' ',' ',' ','*',' '},
        {' ',' ',' ','*',' '}};

        private char[,] z = new char[8,5]
        {{' ','*','*','*',' '},
        {' ',' ',' ','*',' '},
        {' ',' ',' ',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*','*','*',' '}};

        private char[,] voidLetter = new char[8,5]
        {{' ',' ',' ',' ',' '},
        {' ',' ',' ',' ',' '},
        {' ',' ',' ',' ',' '},
        {' ',' ',' ',' ',' '},
        {' ',' ',' ',' ',' '},
        {' ',' ',' ',' ',' '},
        {' ',' ',' ',' ',' '},
        {' ',' ',' ',' ',' '}};

        private char[,] lowerTo = new char[8,5]
        {{' ',' ',' ',' ','*'},
        {' ',' ',' ','*',' '},
        {' ',' ','*',' ',' '},
        {' ','*',' ',' ',' '},
        {' ','*',' ',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ',' ','*',' '},
        {' ',' ',' ',' ','*'}};

        private char[,] three = new char[8,5]
        {{'*','*',' ',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ',' ','*',' '},
        {' ',' ','*',' ',' '},
        {' ',' ','*',' ',' '},
        {' ',' ',' ','*',' '},
        {' ',' ','*',' ',' '},
        {'*','*',' ',' ',' '}};


    }
}