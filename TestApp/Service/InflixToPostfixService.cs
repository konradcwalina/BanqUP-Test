using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TestApp.Abstract;
using TestApp.Enums;
using TestApp.Extensions;
using TestApp.Model;

namespace TestApp.Service
{
    public class InflixToPostfixService
    {
        private readonly Operators Operators;

        public InflixToPostfixService()
        {
            Operators = new Operators();
        }

        /// <summary>
        /// Converts string expretion to Postfix collection
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IList<Token> ToPostfix(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression)) return null;
            expression = expression.Replace(" ", "");

            if (!Regex.IsMatch(expression, @"^[0-9+\-*\/\(\)]*$")) return null;

            IList<Token> postfix = new List<Token>();
            var opStack = new Stack<Operator>();


            var values = new List<string>();
            int pos = 0;
            foreach (Match m in Regex.Matches(expression, $"[{Operators.ToString()}]"))
            {
                var strToken = expression.Substring(pos, m.Index - pos);

                (postfix, opStack) = AddToken(postfix, opStack, strToken);
                (postfix, opStack) = AddToken(postfix, opStack, m.Value);

                pos = m.Index + m.Length;
            }

            (postfix, opStack) = AddToken(postfix, opStack, expression.Substring(pos));

            while (opStack.Any())
            {
                postfix.Add(opStack.Pop().ToToken());
            }
            return postfix;
        }


        /// Add a token candidate to  token or operation list
        /// </summary>
        /// <param name="postfix">Current list of postfix tokens</param>
        /// <param name="opStack">List of Operations</param>
        /// <param name="token">Token Candidate</param>
        /// <returns></returns>
        private (IList<Token>, Stack<Operator>) AddToken(IList<Token> postfix, Stack<Operator> opStack, string token)
        {

            if (string.IsNullOrEmpty(token))
            {
                postfix.Add(new ValueToken() { Value = 0 });
            }

            else if (float.TryParse(token, out float valToken))
            {
                postfix.Add(new ValueToken() { Value = valToken });
            }
            else if (!opStack.Any())
            {
                opStack.Push(Operators.Find(token));
            }
            else
            {
                var keepPushing = true;
                var currentOperator = Operators.Find(token);
                while (keepPushing)
                {
                    if (!opStack.Any())
                    {
                        opStack.Push(Operators.Find(token));
                        keepPushing = false;
                    }
                    else if (opStack.First().Precedense < currentOperator.Precedense)
                    {
                        opStack.Push(currentOperator);
                        keepPushing = false;
                    }
                    else
                    {
                        var @operator = opStack.Pop();
                        postfix.Add(@operator.ToToken());
                    }
                }

            }
            return (postfix, opStack);
        }
    }
}
