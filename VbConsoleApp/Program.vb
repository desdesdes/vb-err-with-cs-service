Imports System
Imports System.Collections.Concurrent

Module Program
    Dim _queue = New ConcurrentQueue(Of integer)()


    Sub Main(args As String())
        _queue.Enqueue(1)
        _queue.Enqueue(2)
        _queue.Enqueue(3)

        Dim t = New Threading.Thread(Sub() Poller())
        t.Start()
        Console.WriteLine("Press a key to quit!")
        Console.ReadKey()
    End Sub

    Sub Poller()
        Dim result As Integer
        While _queue.TryDequeue(result)
            try
                ProcessItem(result)
            Catch e As Exception
                Console.WriteLine($"Error processing item {result}:")
                Console.WriteLine(e.ToString())
            End Try
        End While

    End Sub

    Private Sub ProcessItem(result As Integer)
        Dim x = New VbClassLibrary1.Class1()
        x.Log(result)

        Select(result)
        Case 1
            
        Case 2
            dim y = new VbClassLibrary1.Class1()
                y.vbtrycatch()
        Case 3
        
        End Select
    End Sub
End Module
