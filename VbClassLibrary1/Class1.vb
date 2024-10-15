Public Class Class1
    public sub RaiseError

        Err.Raise(vbObjectError + 1117, , "Delivery date cannot be in the future.")
    End sub

    public sub SetError

        Err.Number = vbObjectError + 1117
    End sub

    public Sub Log(no as integer)
        Console.WriteLine($"Log({no}) thread:{Threading.Thread.CurrentThread.ManagedThreadId}")
        Console.WriteLine($"Log({no}) Err.Number; {Err.Number}")
        Console.WriteLine($"Log({no}) Err.GetException(); {Err.GetException()?.ToString()}")
    End Sub

    public sub vbtrycatch
        try
            Err.Number = vbObjectError + 1117

        Catch ex As Exception
            
        End Try
    End sub
End Class
