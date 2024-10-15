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
            RaiseError

        Catch ex As Exception
            throw
        End Try
    End sub

        public sub ClearErrors
            Err.Clear()
        End sub


       public sub onerrorresumenext
            on error goto errHandler
            throw new Exception("on error resume next")
            
        errHandler:
            err.raise(vbObjectError + 1117, , "Delivery date cannot be in the future.")
        End sub
End Class
