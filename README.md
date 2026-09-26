# DataSet.Merge and RaiseMergeFailed

Reproduces `System.Data.DataException` from `DataSet.RaiseMergeFailed` by merging two DataSets whose `Column2` differs in type (`Int32` vs `Int64`) and uniqueness constraint.

Originally published at [DataSet.Merge and RaiseMergeFailed](https://blogs.msdn.microsoft.com/thottams/2009/03/24/system-data-dataexception-and-system-data-dataset-raisemergefailed-exception/) on the MSDN `thottams` blog.

## Building

```text
csc Program.cs
Program.exe
```

## Note

This is archived sample code from a blog post written years ago. It targets the .NET Framework / Visual Studio versions of that era and is kept here for reference.

