using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.DemonstrateMerge();
        }

        private void DemonstrateMerge()
        {
            DataSet dataSet = new DataSet("dataSet");
            DataTable table = new DataTable("Table1");
            DataColumn idColumn = new DataColumn("Column1", Type.GetType("System.Int32"));
            idColumn.AutoIncrement = true;
            DataColumn itemColumn = new DataColumn("Column2", Type.GetType("System.Int32"));
            itemColumn.Unique = true;

            DataColumn[] keyColumn = new DataColumn[1];
            DataRow row;

            table.Columns.Add(idColumn);
            table.Columns.Add(itemColumn);
            dataSet.Tables.Add(table);

            keyColumn[0] = idColumn;
            table.PrimaryKey = keyColumn;

            for (int i = 0; i < 3; i++)
            {
                row = table.NewRow();
                row["Column2"] = i+100;
                table.Rows.Add(row);
            }

            dataSet.AcceptChanges();
            PrintValues(dataSet, "Original values");
            dataSet.EnforceConstraints = true;
            TryMerge(dataSet);
        }

        private void TryMerge(DataSet original)
        {
            DataSet dataSet = new DataSet("dataSet");
            DataTable table = new DataTable("Table1");
            DataColumn idColumn = new DataColumn("Column1", Type.GetType("System.Int32"));
            idColumn.AutoIncrement = true;
            DataColumn itemColumn = new DataColumn("Column2", Type.GetType("System.Int64"));
            itemColumn.Unique = false;

            DataColumn[] keyColumn = new DataColumn[1];
            DataRow row;

            table.Columns.Add(idColumn);
            table.Columns.Add(itemColumn);
            dataSet.Tables.Add(table);

            keyColumn[0] = idColumn;
            table.PrimaryKey = keyColumn;

            for (int i = 0; i < 3; i++)
            {
                row = table.NewRow();
                row["Column2"] = 100;
                table.Rows.Add(row);
            }

            dataSet.AcceptChanges();
            original.Merge(dataSet);
            PrintValues(original, "Merged values");
        }

        private void PrintValues(DataSet dataSet, string label)
        {
            Console.WriteLine("\n" + label);
            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine("TableName: " + table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.Write("\t table " + row[column]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
