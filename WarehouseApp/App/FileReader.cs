using StockImporter;
using StockImporter.Interfaces;
using System;
using System.Collections;
using System.IO;
using WarehouseApp.Domain.Contracts;

namespace WarehouseApp.App
{
    public class FileReader<T> : IFileReader<T>
        where T : AbstractWarehouse
    {
        string _filePath;
        private IParser<T> _parser;
        private char[] _skipRowTags;

        public FileReader(string path)
        {
            _filePath = path;
        }

        public FileReader(string path, params char[] skipRowTags)
            : this(path)
        {
            _skipRowTags = skipRowTags;
        }
        public void ReadData()
        {
            if (File.Exists(_filePath))
            {
                using (StreamReader sr = File.OpenText(_filePath))
                {
                    string s = String.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (_skipRowTags != null && ((IList)_skipRowTags).Contains(s[0]))
                        {
                            continue;
                        }

                        _parser.Parse(s);
                    }
                }
            }
        }

        public IParser<T> SetParser(IParser<T> parser)
        {
            return _parser = parser;
        }


    }
}
