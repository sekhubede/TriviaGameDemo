using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLibrary
{
    public class TriviaItem
    {
        public string Question { get; set; }
        public bool Answer { get; set; }

        public TriviaItem(string TriviQuestion, bool TriviaAnswer) 
        {
            this.Question = TriviQuestion;
            this.Answer = TriviaAnswer;
        }

        public bool CheckAnswer(bool answer)
        {
            bool result = false;
            if (answer == Answer)
            {
               result= true;
            }    
            return result; 
        }
    }
}
