using System.Collections.Generic;
using System.Linq;
using TestApp.Model;

namespace TestApp.Abstract
{
    /// <summary>
    /// Declare list of Operators you use
    /// </summary>
    public class Operators : List<Operator>
    {
        public Operators()
        {
            Add(new MinusOperator());
            Add(new PlusOperator());
            Add(new MultiplyOperator());
            Add(new DivideOperator());
        }

        /// <summary>
        /// This is for regex purpose
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Join("|", this?.Select(x => x.Character)?.ToArray());

        /// <summary>
        /// Quickly find Operator with character symbol
        /// </summary>
        /// <param name="character">Operation symbol</param>
        /// <returns></returns>
        public Operator Find(string @character) => this.FirstOrDefault(x => x.Character.ToString() == @character);
    }
}
