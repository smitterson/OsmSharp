﻿// OsmSharp - OpenStreetMap (OSM) SDK
// Copyright (C) 2013 Abelshausen Ben
// 
// This file is part of OsmSharp.
// 
// OsmSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// OsmSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with OsmSharp. If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OsmSharp.Math.AI.Genetic.Operations;
using OsmSharp.Math.AI.Genetic.Solvers;
using OsmSharp.Math.AI.Genetic;
using OsmSharp.Math.TSP;
using OsmSharp.Math.TSP.Genetic.Solver;
using OsmSharp.Math.TSP.Genetic.Solver.Operations.Helpers;

namespace OsmSharp.Math.TSP.Genetic.Solver.Operations.CrossOver
{
    /// <summary>
    /// A best placement operation.
    /// </summary>
    public class BestPlacementCrossOverOperation :
        ICrossOverOperation<List<int>, GeneticProblem, Fitness>
    {
        /// <summary>
        /// Creates a new best placement operation.
        /// </summary>
        public BestPlacementCrossOverOperation()
        {

        }

        /// <summary>
        /// Returns the name of this operation.
        /// </summary>
        public string Name
        {
            get
            {
                return "AI";
            }
        }

        #region ICrossOverOperation<int,Problem> Members

        /// <summary>
        /// Applies this crossover operation.
        /// </summary>
        /// <param name="solver"></param>
        /// <param name="parent1"></param>
        /// <param name="parent2"></param>
        /// <returns></returns>
        public Individual<List<int>, GeneticProblem, Fitness>
            CrossOver(Solver<List<int>, GeneticProblem, Fitness> solver,
            Individual<List<int>, GeneticProblem, Fitness> parent1,
            Individual<List<int>, GeneticProblem, Fitness> parent2)
        {
            // take a random piece.
            int idx1 = 0;
            int idx2 = 0;
            while (idx2 - idx1 == 0)
            {
                idx1 = solver.Random.Next(parent1.Genomes.Count - 1) + 1;
                idx2 = solver.Random.Next(parent2.Genomes.Count - 1) + 1;
                if (idx1 > idx2)
                {
                    int temp = idx1;
                    idx1 = idx2;
                    idx2 = temp;
                }
            }

            // if the genome range is big take it from the best individual.
            Individual<List<int>, GeneticProblem, Fitness> source =
                (parent1 as Individual<List<int>, GeneticProblem, Fitness>);
            Individual<List<int>, GeneticProblem, Fitness> target =
                (parent2 as Individual<List<int>, GeneticProblem, Fitness>);

            if (idx2 - idx1 < parent1.Genomes.Count / 2)
            { // the range is small; take the worste genomes.
                if (source.Fitness.CompareTo(target.Fitness) > 0)
                {
                    Individual<List<int>, GeneticProblem, Fitness> temp = source;
                    source = target;
                    target = temp;
                }
                else
                {
                    // do nothing.
                }
            }
            else
            { // the range is big; take the good genomes.
                if (source.Fitness.CompareTo(target.Fitness) > 0)
                {
                    // do nothing.
                }
                else
                {
                    Individual<List<int>, GeneticProblem, Fitness> temp = source;
                    source = target;
                    target = temp;
                }
            }
            List<int> source_piece = source.Genomes.GetRange(idx1, idx2 - idx1);
            List<int> new_genome = target.Genomes.GetRange(0, target.Genomes.Count);

            // insert the piece into the worst individual.
            // remove nodes in the source_piece.
            foreach (int source_node in source_piece)
            {
                new_genome.Remove(source_node);
            }

            // insert the source_piece at the best location.
            List<int> best_genome = null;
            Fitness best_fitness = null;
            //Fitness best_distance = null;

            for (int idx = 0; idx <= new_genome.Count; idx++)
            {
                // create temp genome.
                List<int> temp_genome = new List<int>(new_genome);
                if (idx < new_genome.Count)
                {
                    temp_genome.InsertRange(idx, source_piece);
                }
                else
                {
                    temp_genome.AddRange(source_piece);
                }

                // calculate weight.
                Fitness temp_fitness = solver.FitnessCalculator.Fitness(solver.Problem, temp_genome);
                //Fitness temp_distance = null;

                // select or not.
                if (temp_fitness.CompareTo(best_fitness) > 0)
                {
                    //temp_distance = solver.FitnessCalculator.Fitness(solver.Problem, temp_genome);
                    //best_distance = temp_distance;
                    best_fitness = temp_fitness;
                    best_genome = temp_genome;
                }
            }

            //new_genome.InsertRange(idx1, source_piece);

            Individual individual = new Individual(new List<int>(best_genome));
            return individual;
        }

        #endregion
    }
}
