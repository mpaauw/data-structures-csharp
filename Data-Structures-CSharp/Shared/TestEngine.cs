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

        private int[] elements;

        public TestEngine(int sample, int domain)
        {
            this.SAMPLE_SIZE_UPPER_BOUND = sample;
            this.DOMAIN_UPPER_BOUND = domain;
            createArray();
            populateArray();
        }

        private void createArray()
        {
            Random rand = new Random();
            int arrSize = rand.Next(0, SAMPLE_SIZE_UPPER_BOUND);
            this.elements = new int[arrSize];
        }

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
