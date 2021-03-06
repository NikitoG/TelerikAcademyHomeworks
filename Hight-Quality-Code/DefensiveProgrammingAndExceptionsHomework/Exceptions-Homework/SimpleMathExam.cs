﻿namespace Exceptions_Homework
{
    using System;

    public class SimpleMathExam : Exam
    {
        private int problemSolved;
        
        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemSolved;
            }

            private set
            {
                if (value < 0 || value > 2)
                {
                    throw new ArgumentOutOfRangeException("Problem solved must be in a range between a 0 and 2!");
                }

                this.problemSolved = value;
            }
        }

        public override ExamResult Check()
        {
            if (this.ProblemsSolved == 0)
            {
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            }
            else if (this.ProblemsSolved == 1)
            {
                return new ExamResult(4, 2, 6, "Average result.");
            }
            else if (this.ProblemsSolved == 2)
            {
                return new ExamResult(6, 2, 6, "Excellent result: everything is done.");
            }

            return new ExamResult(2, 2, 6, "Invalid number of problems solved!");
        }
    }
}