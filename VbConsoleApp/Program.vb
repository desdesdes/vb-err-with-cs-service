Imports System

Module Program
    dim runme = true

    sub Main(args As String()) 
        dim t = new Threading.Thread(Sub() Runner())
        t.Start()
        Console.ReadKey()
    End sub

    sub Runner
        try
            Runner1
        Catch ex As Exception

        End Try
        Log(5)
    End sub

    sub Runner1
        Log(0)
        try
            Log(1)
            'RaiseError
            SetError
        Catch ex As Exception
            Log(2)
            'throw
        finally
            Log(3)
        End Try
        Log(4)
    End sub

    Sub Log(no as integer)
        Console.WriteLine($"Log({no}) thread:{Threading.Thread.CurrentThread.ManagedThreadId}")
        Console.WriteLine($"Log({no}) Err.Number; {Err.Number}")
        Console.WriteLine($"Log({no}) Err.GetException(); {Err.GetException()?.ToString()}")
    End Sub

    sub RaiseError

        Err.Raise(vbObjectError + 1117, , "Delivery date cannot be in the future.")
    End sub

    sub SetError

        Err.Number = vbObjectError + 1117
    End sub
End Module
