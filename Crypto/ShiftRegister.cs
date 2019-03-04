using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    class ShiftRegister
    {
        private char[] register;
        private int[] majorityBits;
        private int majorityXorBit;
        private int[] bitsForNewValue;
        public char[] Register { get { return register; } set { register = value; } }

        public ShiftRegister(int v)
        {
            register=new char[v];
            for(int i=0; i<v; i++)
            {
                register[i] = '0';
            }
            //majorityBits = new int[3];
            //majorityBits[0] = 0;
            //majorityBits[1] = 1;
            //majorityBits[2] = 2;
        }

        public char GetLastElement { get { return register[register.Count()-1];} }

        public void EmptyRegyister()
        {
            for (int i = 0; i < register.Count(); i++)
            {
                register[i] = '0';
            }
        }

        public char GetElement(int el)
        {
            return register[el];
        }

        public void SetElement(int el, char value)
        {
            register[el] = value;
        }

        public void SetMajorityBits(int[] b)
        {
            majorityBits = b;
        }

        public void SetMajorityXorBit(int b)
        {
            majorityXorBit = b;
        }

        public void SetBitsForNewValue(int[] b)
        {
            bitsForNewValue = b;
        }

        public char GetMajority()
        {
            char m = '1';
            m = XOR(m, register[majorityBits[0]]);
            m = XOR(m, register[majorityBits[1]]);
            m = XOR(m, register[majorityBits[2]]);

            return m;
        }

        public char XOR(char a, char b)
        {
            if (a == b)
                return '0';
            else
                return '1';
        }

        public char GetNewValue()
        {
            char nv = register[bitsForNewValue[0]];
            for(int i=1; i<bitsForNewValue.Count(); i++)
            {
                nv = XOR(nv, register[bitsForNewValue[i]]);
            }
            return nv;
        }

        public void Shift()
        {
            
            for (int i = register.Count() - 1; i > 0; i--)
            {
                register[i]=register[i-1];
            }

            register[0] = GetNewValue();
        }

    }
}
