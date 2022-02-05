using System;
using System.Diagnostics;

namespace ClassicSpaceInvaders
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {

            //TestInts();    
            //TestFloats();
            //TestStrings();
            //TestCommands();

            using (var game = new ClassicSpaceInvaders())
                game.Run();
        }


        static void TestInts()
        {
            Int32 num1 = 1;
            Int32 num2 = 7;
            Int32 num3;

            num1 = 2;
            num3 = 0;

            num3 = num1 + num2;
            num3 = num1 - num2;

            num1 = 6;
            num2 = 2;
            num3 = num1 / num2;
            num3 = num1 * num2;

        }

        static void TestFloats()
        {
            float fNum1 = 1.0f;
            float fNum2 = 2.5f;
            float fNum3 = 0.0f;

            fNum3 = fNum1 + fNum2;
            fNum3 = fNum1 - fNum2;

            fNum1 = 0.4f;
            fNum2 = 0.2f;
            fNum3 = fNum1 / fNum2;

            fNum3 = fNum1 * fNum2;

        }

        static void TestStrings()
        {
            Int32   num1            = 12345;
            float   fnum2           = 0.54321f;
            String  displayNumber;

            displayNumber = "Value num1 = " + num1 + " and fnum2 = " + fnum2; 

            Debug.WriteLine( displayNumber );

        }

        static void TestCommands()
        {
            // for loop....
            //    Assign         Condition    Increment
            for (Int32 Index = 0; Index < 10; Index++)
            {
                Debug.WriteLine( "Index  = " + Index );

                //    Checks for even numbers
                if ( (Index & 1) == 0 )
                {
                    Debug.WriteLine( Index + " is an even number " );
                }
                else
                {
                    Debug.WriteLine( Index + " is an odd number " );
                }

                if ( Index != 1 )
                {
                    Debug.WriteLine( Index + " is not 1 " );
                }
                if ( Index > 5 )
                {
                    Debug.WriteLine( Index + " is greater than 5" );
                }
                if ( Index < 2 )
                {
                    Debug.WriteLine( Index + " is less than 2" );
                }


            }

            for (Int32 Index = 10; Index > 0; Index--)
            {
                Debug.WriteLine( "Index  = " + Index );
                switch ( Index )
                {
                    case 10:
                    {
                        Debug.WriteLine( "Ten" );
                        break;
                    }
                    case 9:
                    {
                        Debug.WriteLine( "Nine" );
                        break;
                    }
                    case 8:
                    {
                        Debug.WriteLine( "Eight" );
                        break;
                    }
                    case 7:
                    {
                        Debug.WriteLine( "Seven" );
                        break;
                    }
                    case 6:
                    {
                        Debug.WriteLine( "Six" );
                        break;
                    }
                    case 5:
                    {
                        Debug.WriteLine( "Five" );
                        break;
                    }
                    case 4:
                    {
                        Debug.WriteLine( "four" );
                        break;
                    }
                    case 3:
                    {
                        Debug.WriteLine( "Three" );
                        break;
                    }
                    case 2:
                    {
                        Debug.WriteLine( "Two" );
                        break;
                    }
                    case 1:
                    {
                        Debug.WriteLine( "one" );
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }


            }

        }


    }
}
