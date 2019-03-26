Module Module1
    'NOT PART OF PRE RELEASE BUT BOOK MEIN HAI SO :))

    'CREATE LL
    'INSERT NODES IN ORDER
    'OUTPUT NODES
    'DELETE SPECIFIC NODE


    Structure LLNode
        Dim Pointer As Integer
        Dim Data As String
    End Structure

    Const NULLPOINTER = -1
    Dim StartPointer As Integer
    Dim FreePointer As Integer
    'Linked list nodes array of size 8(0-7)
    Dim Nodes(7) As LLNode

    Sub Main()
        Call InitialiseList()
        Dim MenuChoice As Integer = 0
        While MenuChoice <> 5
            Console.WriteLine("1: to ADD A NODE.")
            Console.WriteLine("2: to OUTPUT ALL NODES IN ORDER.")
            Console.WriteLine("3: to OUTPUT LL IMPLEMENTED BY ARRAY.")
            Console.WriteLine("4: to DELETE A NODE.")
            Console.WriteLine("5: Exit")

            MenuChoice = Console.ReadLine
            Select Case MenuChoice
                Case 1 : InsertNode()
                Case 2 : OutputItems()
                Case 3 : OutputArray()
                Case 4 : DeleteNode()
                Case 5 'DO NOTHING xD
                Case Else : Console.WriteLine("Wrong Choice. Please try again")
            End Select

        End While


    End Sub

    Sub InitialiseList()

        StartPointer = NULLPOINTER
        FreePointer = 0
        'INITIALISING FREE LIST
        For count = 0 To 7
            Nodes(count).Pointer = count + 1
        Next
        Nodes(7).Pointer = NULLPOINTER

    End Sub


    Sub InsertNode()
        Console.WriteLine("Enter the node which you want to insert.")
        Dim DataInputted As String = Console.ReadLine
        Dim NewNodePtr As Integer
        Dim CurrentNodePtr As Integer
        Dim PreviousNodePtr As Integer
        If FreePointer <> NULLPOINTER Then
            'We have space so grab a node from free list :)
            NewNodePtr = FreePointer
            Nodes(NewNodePtr).Data = DataInputted
            'Set Free Pointer to next available node in free list
            FreePointer = Nodes(FreePointer).Pointer

            CurrentNodePtr = StartPointer
            While CurrentNodePtr <> NULLPOINTER
                If (Nodes(CurrentNodePtr).Data < DataInputted) Then
                    PreviousNodePtr = CurrentNodePtr
                    CurrentNodePtr = Nodes(CurrentNodePtr).Pointer
                Else
                    Exit While
                End If
            End While

            'JO CURRENT NODE HAI US SE PHELE INSERT KREIN GE NAYI NODE HAMESHA.
            If CurrentNodePtr = StartPointer Then
                'Insert the node at the start of Linked List
                Nodes(NewNodePtr).Pointer = StartPointer
                StartPointer = NewNodePtr
                Console.WriteLine("START POINTER IS:" & StartPointer)
            Else
                'Insert Node between previous node and current node.
                Nodes(NewNodePtr).Pointer = Nodes(PreviousNodePtr).Pointer
                Nodes(PreviousNodePtr).Pointer = NewNodePtr
            End If


        Else
            Console.WriteLine("No available space in free list")
        End If
    End Sub

    Sub OutputArray()
        For count = 0 To 7
            Console.WriteLine("  " & count & Space(3) & Nodes(count).Data & Space(20 - Len(Nodes(count).Data)) & Nodes(count).Pointer)
        Next
    End Sub

    Sub OutputItems()
        Console.WriteLine() 'Just a blank line to sepeate it from above outputs
        Dim CurrentNodePtr As Integer = StartPointer
        While CurrentNodePtr <> NULLPOINTER
            Console.WriteLine("  " & Nodes(CurrentNodePtr).Data)
            CurrentNodePtr = Nodes(CurrentNodePtr).Pointer
        End While
    End Sub

    Sub DeleteNode()
        Dim NodeToDelete As String
        Dim NodeFound = False
        Dim CurrentNodePtr As Integer = StartPointer
        Dim PreviousNodePtr As Integer
        Console.WriteLine("Enter the node which you want to delete.")
        NodeToDelete = Console.ReadLine

        'We check all nodes in linked by follwing each node's pointer to next node untill we find our desired item
        While CurrentNodePtr <> NULLPOINTER And NodeFound = False
            If Nodes(CurrentNodePtr).Data = NodeToDelete Then
                NodeFound = True
                If (CurrentNodePtr = StartPointer) Then
                    'This means the node we wanna delete is foudn to be at start of Linked List or in other words the first node of Linked List.
                    StartPointer = Nodes(CurrentNodePtr).Pointer
                Else
                    Nodes(PreviousNodePtr).Pointer = Nodes(CurrentNodePtr).Pointer   'VERY IMP
                End If
                'Add the deleted node to freelist
                Nodes(CurrentNodePtr).Pointer = FreePointer
                FreePointer = CurrentNodePtr
                Nodes(CurrentNodePtr).Data = "" 'set data to blank
            Else
                PreviousNodePtr = CurrentNodePtr
                CurrentNodePtr = Nodes(CurrentNodePtr).Pointer
            End If
        End While

        If (NodeFound = False) Then
            Console.WriteLine("NODE NOT FOUND")
        End If
    End Sub


End Module
