using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiply_2_Polynomials
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] polynomial1 = new int[4];
            int[] polynomial2 = new int[4];
            int numberOfTerms = 0;
            Random objR = new Random();
            Multiply2Polynomials objM = new Multiply2Polynomials();

            for (int i = 1; i < polynomial1.Length; i++)
            {
                polynomial1[i] = objR.Next(1, 10);
                polynomial2[i] = objR.Next(1, 10);
            }

            numberOfTerms = polynomial1.Length;

            for (int j = 0; j < (2 * polynomial1.Length) - 2; j++)
                Console.WriteLine(objM.ComputePolynomialMultiplication(polynomial1, polynomial2, numberOfTerms, 0, 0));

            Console.ReadLine();
        }
    }

    public class Multiply2Polynomials
    {
        public int[] ComputePolynomialMultiplication(int [] polynomial1, int [] polynomial2, int numberOfTerms, int indnthTermPolynomial1, int indnthTermPolynomial2)
        {
            int[] multiplication = new int[(2*numberOfTerms) - 1];

            if (numberOfTerms == 0)
            {
                multiplication[0] = polynomial1[indnthTermPolynomial1] * polynomial2[indnthTermPolynomial2];
                return multiplication;
            }
            multiplication = ComputePolynomialMultiplication(polynomial1, polynomial2, (int)numberOfTerms/2, indnthTermPolynomial1, indnthTermPolynomial2);
            multiplication = ComputePolynomialMultiplication(polynomial1, polynomial2, (int)numberOfTerms/2, indnthTermPolynomial1+(int)(numberOfTerms/2), indnthTermPolynomial2+(int)(numberOfTerms/2));

            return multiplication;
        }
    }
}
