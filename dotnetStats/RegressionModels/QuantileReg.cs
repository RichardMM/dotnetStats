
namespace dotnetStats.RegressionModels
{
    using System;
    using System.Collections.Generic;
    using Google.OrTools.LinearSolver;
    public class QuantileReg:RegressionAbstractClass
    {
        private double tau;
        public double Tau
        {
            get
            {
                return tau;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("quantile cannot be negative");
                }
                else
                {
                    tau = value;
                }
            }
        }
        /// <summary>
        /// The solver object.
        /// Users can modify it to glpk,glop or clp
        /// </summary>
        public Solver Solver { get; set; }= Solver.CreateSolver("LinearProgramming", "GLOP_LINEAR_PROGRAMMING");

        public QuantileReg(double[][] x, double[] y,double tau) : base(x,  y) {
            Tau = tau;
        }


        public RegResults Fit()
        {
            //setup objective
            Objective objective = this.Solver.Objective();

            List<Variable> variables = new List<Variable>();
            //create a variable for each error and for the number of parameters in the regression
            //splitting theta into positive and negative makes sure that we can constrain all our variables to be positive
            VariableMaker(variables, NRows, "u", objective, Tau);
            VariableMaker(variables, NRows, "v", objective, 1 - Tau);
            VariableMaker(variables, NCols, "theta_positive", objective, 0);
            VariableMaker(variables, NCols, "theta_negative", objective, 0);

            objective.SetMinimization();
            Console.WriteLine(NRows);

            Console.WriteLine(NCols);

            //get constraints
            ConstraintsMaker(variables);

            //solve
            int resultStatus = Solver.Solve();


            Console.WriteLine(Solver.Objective().Value());

            //store parameters
            double[] res = new double[NCols];
            for (int j = 0; j < NCols; ++j)
            {

                double positive_theta = variables[NRows * 2 + j].SolutionValue();
                double negative_theta = variables[(NRows * 2) + NCols + j].SolutionValue();
                res[j] = positive_theta - negative_theta;
            }





            return new RegResults(X, Y, res);
        }
        /// <summary>
        /// Helper method to create constraints for the solver
        /// </summary>
        /// <param name="variables"></param>
        private void ConstraintsMaker( List<Variable> variables)
        {
            for (int i = 0; i < NRows; i++)
            {
                Constraint c0 = this.Solver.MakeConstraint(Y[i], Y[i]);
                //u_i
                c0.SetCoefficient(variables[i], 1);
                //v_i
                c0.SetCoefficient(variables[i + NRows], -1);
                for (int j = 0; j < NCols; j++)
                {

                    //loop thru the remaining variables which each represent theta for a different x variable
                    //theta has been separated into a positive side
                    c0.SetCoefficient(variables[(NRows * 2) + j], (X[i][j]));

                    //and a negative side
                    c0.SetCoefficient(variables[(NRows * 2) + NCols + j], (-X[i][j]));

                }

            }
        }

        /// <summary>
        /// helper method Used to create variables for the Glop/clp solver
        /// </summary>
        /// <param name="list">the list holding the variables</param>
        /// <param name="count"></param>
        /// <param name="prefix">prefix for naming the variable</param>
        /// <param name="obj">the objective function</param>
        /// <param name="coeff"> coeffiecient to use for the variables created</param>
        private void VariableMaker(List<Variable> list, int count, string prefix, Objective obj, double coeff)
        {
            Variable x;
            for (int i = 0; i < count; i++)
            {
               
                x = Solver.MakeNumVar(0.0, double.PositiveInfinity, prefix + i.ToString());
              
                list.Add(x);
                obj.SetCoefficient(x, coeff);
            }
        }
    }
}
