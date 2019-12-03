using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Service
{
    public class CalculatorService
    {
        private readonly InflixToPostfixService inflixToPostfixService;
        private readonly PostfixEvaluatorService postfixEvaluatorService;

        /// <summary>
        /// This should really be injected through DI Container
        /// </summary>
        public CalculatorService()
        {
            inflixToPostfixService = new InflixToPostfixService();
            postfixEvaluatorService = new PostfixEvaluatorService();
        }
        public float? Calculate(string expression)
        {
            try
            {
                var postfix = new InflixToPostfixService().ToPostfix(expression);
                return new PostfixEvaluatorService().Evaluate(postfix);
            }
            catch  (DivideByZeroException)
            {
                Console.WriteLine("Invalid expression");
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops, something went wrong. Apologies, your expression string is not supported yet.");
                return null;
            }
        }
    }
}
