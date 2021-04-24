using System;
using Xunit;
using factorsLib;

namespace factorsLibUnitTests
{
    public class factorsLibUnitTests
    {
        [Fact]
        /// <summary>
        /// Funciona para planear y testear el proceso de mi funcion GetPrimeFactors
        /// </summary>
        public void TestPrintFactors()
        {
            //Arrange: Variables que se van a utilizar para comprobar el metodo, con valores enviados y esperados 
            int numToPrimeFactors = 50; //Almacena el numero que se desea descomponer en factores primos
            string expectedAnswer = "50 : 2 x 5 x 5"; //Almacena el resultado esperado de la función
            var primeFactors = new PrimeFactors(); //Instancia para llamar al metodo perteneciente de PrimeFactors
            //Act: Variables que se van a utilizar para guardar los resultados
            string actualAnswer = primeFactors.GetPrimeFactors(numToPrimeFactors); //Almacena el resultado real de la función
            //Assert: Funcion que determina si la función cumple con lo esperado
            Assert.Equal(expectedAnswer,actualAnswer);


        }

        [Fact]

        /// <summary>
        /// Funciona para planear y testear el proceso de mi funcion IsInTheRange
        /// </summary>
        public void TestIsInTheRange()
        {
            //Arrange
            int numToPrimeFactors = 1000; //Almacena el numero que se desea analizar si esta dentro del rango
            bool expectedAnswer = true;//Almacena el resultado esperado de la función
            var primeFactors = new PrimeFactors();
            //Act
            bool actualAnswer = primeFactors.IsInTheRange(numToPrimeFactors);
            //Assert
            Assert.Equal(expectedAnswer,actualAnswer);
        }

        [Fact]
        
        /// <summary>
        /// Funciona para planear y testear el proceso de mi funcion GetPrimeFactors en caso base
        /// </summary>
        public void TestWhenIsZero()
        {
            //Arrange
            int numToPrimeFactors = 0; //Almacena el numero que se desea analizar para un caso base
            string expectedAnswer = "0 : 1";
            var primeFactors = new PrimeFactors();
            //Act
            string actualAnswer = primeFactors.GetPrimeFactors(numToPrimeFactors);
            //Assert
            Assert.Equal(expectedAnswer,actualAnswer);
        }
    }
}
