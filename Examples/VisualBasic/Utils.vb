Imports System.IO

Namespace Aspose
    Namespace Cells
        Namespace Examples

            Public Class Utils
                Shared Function GetDataDir(ByRef t As Type) As String
                    Dim c As String = t.FullName
                    c = c.Replace("VisualBasic.Aspose.Cells.Examples.", "")
                    c = c.Replace(".", Path.DirectorySeparatorChar)
                    Dim p As String = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data", c))
                    p += Path.DirectorySeparatorChar
                    If Directory.Exists(p) Then
                        Console.WriteLine("Using Data Dir {0}", p)
                    Else
                        Directory.CreateDirectory(p)
                        Console.WriteLine("Created Data Dir {0}", p)
                    End If
                    Return p
                End Function
                Shared Sub Main()
                    Console.WriteLine("To run an example, go to 'Project Properties' and select a 'Startup Object'.")
                    Console.WriteLine("Press any key to continue...")
                    Console.ReadKey()
                End Sub
            End Class

        End Namespace
    End Namespace
End Namespace
