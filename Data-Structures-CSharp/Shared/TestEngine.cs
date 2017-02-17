using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.Shared
{
    public class TestEngine
    {
        private readonly int SAMPLE_SIZE_UPPER_BOUND;

        private readonly int DOMAIN_UPPER_BOUND;

        public int[] elements { get; set; }

        /// <summary>
        /// Default constructor.
        /// Reads supplied sample size and domain upper bounds, builds an element array and fills it with data.
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="domain"></param>
        public TestEngine(int sample, int domain)
        {
            this.SAMPLE_SIZE_UPPER_BOUND = sample;
            this.DOMAIN_UPPER_BOUND = domain;
            buildArray();
            populateArray();
        }

        /// <summary>
        /// Initializes the element array to a random size based on the provided sample size upper bound.
        /// </summary>
        private void buildArray()
        {
            Random rand = new Random();
            int arrSize = rand.Next(0, SAMPLE_SIZE_UPPER_BOUND);
            this.elements = new int[arrSize];
        }

        /// <summary>
        /// Fills the element array with random positive and negative integers within the absolute value of the provided domain upper bound.
        /// </summary>
        private void populateArray()
        {
            Random rand = new Random();
            for(int i = 0; i < this.SAMPLE_SIZE_UPPER_BOUND; i++)
            {
                this.elements[i] = rand.Next((-1 * this.DOMAIN_UPPER_BOUND), this.DOMAIN_UPPER_BOUND);
            }
        }
    }
}
