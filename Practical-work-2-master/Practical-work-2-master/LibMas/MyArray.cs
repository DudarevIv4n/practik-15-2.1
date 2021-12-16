using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMas
{
    public class MyArray
    {
        public MyArray(int length)
        {
            _array = new int[length];
        }

        private readonly Random _random = new Random();
        private int[] _array;
        public int Length => _array.Length;

        public void Initialize(int min = -30, int max = 31)
        {
            for (int i = 0; i < Length; i++)
            {
                _array[i] = _random.Next(min, max);
            }
        }

        public void Save(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(Length);

                for (int i = 0; i < Length; i++)
                {
                    writer.WriteLine(_array[i]);
                }
            }
        }

        public void Open(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                _array = new int[int.Parse(reader.ReadLine())];

                for (int i = 0; i < Length; i++)
                {
                    _array[i] = int.Parse(reader.ReadLine());
                }
            }
        }

        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < _array.Length; i++)
            {
                res.Columns.Add("col" + (i + 1));
            }
            var row = res.NewRow();
            for (int i = 0; i < Length; i++)
            {
                row[i] = _array[i];
            }
            res.Rows.Add(row);
            return res;
        }

        public int this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public void Clear()
        {
            Initialize(0, 0);
        }
    }
}
