' Enumerable Class
' Tests of Enumerable class static members, processing objects that implement IEnumerable(Of T)
' Mostly used by Linq, but otherwise very useful
'
' 2008-08-21    PV
' 2012-02-25    PV  VS2010
' 2021-09-20    PV  VS2022; Net6

Imports System.Console
Imports System.Runtime.CompilerServices
Imports System.Text

Module Module1

    Sub Main()
        TestConcat()
        TestRangeRepeat()
        TestWhere()
        TestFirstLast()
        TestMinMax()
        TestSetOperations()
        TestAggregate()
        TestAll()
        TestAny()
        TestCast()
        TestOfType()
        TestContains()
        TestCount()
        TestDistinct()
        TestOrderBy()
        TestGroupBy()
        TestJoin()
        TestGroupJoin()
        TestReverse()
        TestSelect()
        TestToX()
        TestCrible()
    End Sub

    ' Quick helpers to print an enumeration
    <Extension()>
    Public Sub Write(Of TSource)(Source As IEnumerable(Of TSource))
        For Each element As TSource In Source
            Console.Write(element)
            Console.Write(" "c)
        Next
    End Sub

    <Extension()>
    Public Sub MyWriteLine(Of TSource)(Source As IEnumerable(Of TSource))
        Write(Source)
        WriteLine()
    End Sub

    ' Simple concatenation of two IEnumerable(Of T)
    ' Does not eliminate duplicates, use Union for that purpose
    Sub TestConcat()
        Dim t1 As String() = {"amber", "blue", "cyan"}
        Dim t2 As String() = {"green", "orange", "blue"}

        Dim l As IEnumerable(Of String) = Enumerable.Concat(t1, t2)

        WriteLine()
        MyWriteLine("Concat ------------------")
        Console.Write("t1: ")
        t1.MyWriteLine()
        Console.Write("t2: ")
        t2.MyWriteLine()
        Console.Write("Enumerable.Concat(t1, t2): ")
        l.MyWriteLine()
    End Sub

    ' Range: Creates an IEnumerable(Of Integer) using start, count
    ' Repeat: Repeats any value
    Sub TestRangeRepeat()
        Dim l1 As IEnumerable(Of Integer) = Enumerable.Range(-4, 10)
        Dim l2 As IEnumerable(Of String) = Enumerable.Repeat("hello", 4)

        WriteLine()
        MyWriteLine("Range and Repeat --------")
        Console.Write("Enumerable.Range(-4, 10): ")
        l1.MyWriteLine()
        Console.Write("Enumerable.Repeat(""hello"", 4): ")
        l2.MyWriteLine()
    End Sub

    ' Filters an IEnumerable(Of T) using a predicate (a function that returns a boolean, true=keep element, false=discard it)
    Sub TestWhere()
        ' Create a list of strings.
        Dim fruits As New List(Of String)(New String() _
                                {"apple", "passionfruit", "banana", "mango",
                                 "orange", "blueberry", "grape", "strawberry"})

        ' Restrict the results to those strings whose length is less than six.
        Dim query As IEnumerable(Of String) = fruits.Where(Function(fruit) fruit.Length < 6)

        WriteLine()
        MyWriteLine("Where -------------------")
        Console.Write("fruits: ")
        fruits.MyWriteLine()
        Console.Write("fruits.Where(Function(fruit) fruit.Length<6): ")
        query.MyWriteLine()

        ' A filter predicate can use element index
        Dim OddIndexFruits As Func(Of String, Integer, Boolean) = Function(fruit, index) (index And 1) = 1
        Console.Write("fruits having an odd index: ")
        fruits.Where(OddIndexFruits).MyWriteLine()

    End Sub

    ' Simply returns the first or the last element of IEnumerable(Of T)
    Sub TestFirstLast()
        Dim dates = New Date() {#2/26/1965#, #2/8/1969#, #1/1/2000#}

        WriteLine()
        MyWriteLine("First and Last ----------")
        Console.Write("dates: ")
        dates.MyWriteLine()
        Console.Write("dates.First: ")
        WriteLine(dates.First)
        Console.Write("dates.Lastt: ")
        WriteLine(dates.Last)

        Dim emptyDates = Array.Empty(Of Date)()

        Console.Write("emptyDates: ")
        emptyDates.MyWriteLine()
        Console.Write("emptydates.FirstOrDefault: ")
        WriteLine(emptyDates.FirstOrDefault)
    End Sub

    ' Extract minimum or maximum from an IEnumerable(Of T)
    ' Needs IComparable(Of T) or IComparable
    Sub TestMinMax()
        Dim ts() As String = {"one", "upon", "a", "time", "in", "a", "far", "away", "kingdom"}

        WriteLine()
        MyWriteLine("Min and Max -------------")
        Console.Write("ts: ")
        ts.MyWriteLine()
        Console.Write("Enumerable.Min(ts): ")
        MyWriteLine(Enumerable.Min(ts))
        Console.Write("ts.Max: ")
        MyWriteLine(ts.Max)
        Console.Write("ts.Max(Function(s) s.Length): ")
        WriteLine(ts.Max(Function(s) s.Length))

        ' Create an array of Pet objects.
        Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8},
                             New Pet With {.Name = "Boots", .Age = 4},
                             New Pet With {.Name = "Whiskers", .Age = 1}}

        ' Find the "maximum" pet according to the custom CompareTo() implementation.
        Dim max As Pet = pets.Max()
        Console.Write("pets: ")
        pets.MyWriteLine()
        Console.Write("pets.max: ")
        WriteLine(pets.Max)
    End Sub

    ' This class implements IComparable
    ' and has a custom 'CompareTo' implementation.
    Class Pet
        Implements IComparable(Of Pet)

        Public Name As String
        Public Age As Integer

        ''' <summary>Compares Pet objects by the sum of their age and name length.</summary>
        ''' <param name="other">The Pet to compare this Pet to.</param>
        ''' <returns>-1 if this Pet's sum is 'less' than the other Pet, 0 if they are equal,
        ''' or 1 if this Pet's sum is 'greater' than the other Pet.</returns>
        Function CompareTo(other As Pet) As Integer _
            Implements IComparable(Of Pet).CompareTo

            If (other.Age + other.Name.Length > Me.Age + Me.Name.Length) Then
                Return -1
            ElseIf (other.Age + other.Name.Length = Me.Age + Me.Name.Length) Then
                Return 0
            Else
                Return 1
            End If
        End Function

        Public Overrides Function ToString() As String
            Return Name & ":" & Age.ToString
        End Function

    End Class

    ' Standard set operations applied to IEnumerable(Of T)
    ' Uses the default equality comparer
    Sub TestSetOperations()
        Dim t1 = New Integer() {2, 4, 6, 8, 10, 12, 14, 16, 18}
        Dim t2 = New Integer() {3, 6, 9, 12, 15, 18}

        WriteLine()
        MyWriteLine("Set operations ----------")
        Console.Write("t1: ")
        t1.MyWriteLine()
        Console.Write("t2: ")
        t2.MyWriteLine()
        Console.Write("Enumerable.Union(t1, t2): ")
        Enumerable.Union(t1, t2).MyWriteLine()
        Console.Write("Enumerable.Intersect(t1, t2): ")
        Enumerable.Intersect(t1, t2).MyWriteLine()
        Console.Write("Enumerable.Except(t1, t2): ")
        Enumerable.Except(t1, t2).MyWriteLine()
    End Sub

    ' Runs an aggregation function Func(Of TSource, TSource, TSource) on each element of a sequence
    ' Limit: aggreate value must be the same type as an element of the sequence
    ' Note: on first call of aggregation function, aggregated contains the value of the first element,
    ' and element is the second element of the sequence
    Sub TestAggregate()
        Dim sentence As String = "This is a sentence to reverse words"
        Dim words As IEnumerable(Of String) = sentence.Split(" "c)
        Dim s As String = words.Aggregate(AddressOf ProcessWord)

        WriteLine()
        MyWriteLine("Aggregate ---------------")
        Console.Write("words: ")
        words.MyWriteLine()
        Console.Write("words.Aggregate(AddressOf ProcessWord): ")
        MyWriteLine(s)
    End Sub

    Function ProcessWord(aggregated As String, element As String) As String
        If aggregated = "" Then
            Return element
        Else
            Return element & " " & aggregated
        End If
    End Function

    ' Test a boolean function on all elements of a sequence
    Sub TestAll()
        Dim tabInt() As Integer = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97}
        Dim allPrimes As Boolean = tabInt.All(AddressOf IsPrime)
        Dim allLessThan50 As Boolean = tabInt.All(Function(n) n < 50)

        WriteLine()
        MyWriteLine("TestAll -----------------")
        Console.Write("tabInt: ")
        tabInt.MyWriteLine()
        MyWriteLine("AllPrimes: " & allPrimes.ToString)
        MyWriteLine("AllLessThan50: " & allLessThan50.ToString)
    End Sub

    ' Returns True if lngNumber is a prime
    ' Divides by odd nubers from 3 to lngNummber square root
    Private Function IsPrime(lngNumber As Long) As Boolean
        If lngNumber <= 2 Then Return True ' Returns 1 and 2 as prime...
        If lngNumber Mod 2 = 0 Then Return False
        For n As Long = 3 To CLng(Math.Sqrt(lngNumber)) Step 2
            If lngNumber Mod n = 0 Then Return False
        Next
        Return True
    End Function

    ' With no argument, simply returns True if the list contains at list one element (= isEmpty)
    ' With an argument, returns True if the function is at least true for one element
    Sub TestAny()
        Dim l As IEnumerable(Of Object) = Array.Empty(Of Object)()
        Dim t As Integer() = {51, 51, 52, 53, 54, 55, 56, 57, 58, 59}

        WriteLine()
        MyWriteLine("TestAny -----------------")
        Console.Write("l: ")
        l.MyWriteLine()
        Console.Write("l.Any(): ")
        WriteLine(l.Any())
        Console.Write("t: ")
        t.MyWriteLine()
        Console.Write("t.Any(AddressOf IsPrime): ")
        WriteLine(t.Any(AddressOf IsPrime))
    End Sub

    ' Transforms an IEnumerable(Of X) into IEnumerable(Of T)
    ' Throws an exception if an element is not convertible, see OfType(Of T) to get elements of type T with no error
    Sub TestCast()
        Dim t As Object() = New Object() {"Hello", "world"}
        Dim l As IEnumerable(Of String) = t.Cast(Of String)()

        WriteLine()
        MyWriteLine("Cast --------------------")
        Console.Write("t As Object(): ")
        t.MyWriteLine()
        Console.Write("t.Cast(Of String)(): ")
        l.MyWriteLine()
    End Sub

    ' Returns a sublist based on type
    ' In this example, 8.2, 15@ (decimal), CType(6, Short) and CType(7, Byte) are NOT returned
    ' In object example, a Puppy is returned by OfType(Of Dog)
    Sub TestOfType()
        Dim t As Object() = New Object() {"Hello", 12, False, 5, #8/25/2008#, 8.2, 15@, New StringBuilder, CType(6, Short), CType(7, Byte)}
        Dim li As IEnumerable(Of Integer) = t.OfType(Of Integer)()

        Dim ld As New List(Of Dog) From {
            New Dog("Titus"),
            New Dog("Athos"),
            New Puppy("Baltik")
        }

        WriteLine()
        MyWriteLine("OfType ------------------")
        Console.Write("t As Object(): ")
        t.MyWriteLine()
        Console.Write("t.OfType(Of Integer)(): ")
        li.MyWriteLine()

        Console.Write("ld: ")
        ld.MyWriteLine()
        Console.Write("ld.OfType(Of Dog): ")
        ld.OfType(Of Dog)().MyWriteLine()
        Console.Write("ld.OfType(Of Puppy): ")
        ld.OfType(Of Puppy)().MyWriteLine()
    End Sub

    Class Dog
        Private ReadOnly _name As String

        Public Sub New(name As String)
            _name = name
        End Sub

        Public Overrides Function ToString() As String
            Return _name
        End Function

    End Class

    Class Puppy : Inherits Dog

        Public Sub New(name As String)
            MyBase.New(name)
        End Sub

    End Class

    ' Tests whether a sequence contains a given element
    ' Can provide a specific comparer
    Sub TestContains()
        Dim colors As String() = {"red", "green", "blue"}

        WriteLine()
        MyWriteLine("Contains ----------------")
        Console.Write("colors: ")
        colors.MyWriteLine()
        Console.Write("colors.Contains(""Red""): ")
        WriteLine(colors.Contains("Red"))
        Console.Write("colors.Contains(""Red"", StringComparer.InvariantCultureIgnoreCase): ")
        WriteLine(colors.Contains("Red", StringComparer.InvariantCultureIgnoreCase))
    End Sub

    ' No argument, counts elements in a sequence.
    ' Note: not to be confused with count property of List(Of T) for instance, since it needs to run through the enumerator to compute the number of elements
    ' Can be used to determine how many elements of a sequence match a given predicate
    Sub TestCount()
        Dim l As IEnumerable(Of Integer) = Enumerable.Range(2, 99)

        WriteLine()
        MyWriteLine("Count -------------------")
        Console.Write("l: ")
        l.MyWriteLine()
        Console.Write("l.Count(): ")
        WriteLine(l.Count)
        Console.Write("l.Count(AddressOf IsPrime): ")
        WriteLine(l.Count(AddressOf IsPrime))
    End Sub

    ' Returns distinct values of a sequence
    Sub TestDistinct()
        Dim lc As New List(Of String)

        ' Main colors of Flags of European Union members
        lc.AddRange(New String() {"red", "white"})              ' Austria
        lc.AddRange(New String() {"black", "yellow", "red"})    ' Belgium
        lc.AddRange(New String() {"white", "green", "red"})     ' Bulgaria
        lc.AddRange(New String() {"white", "orange", "green"})  ' Cyprus
        lc.AddRange(New String() {"blue", "red", "white"})      ' Czech Republic
        lc.AddRange(New String() {"red", "white"})              ' Denmark
        lc.AddRange(New String() {"white", "blue", "black"})    ' Estonia
        lc.AddRange(New String() {"white", "blue"})             ' Finland
        lc.AddRange(New String() {"blue", "white", "red"})      ' France
        lc.AddRange(New String() {"black", "red", "yellow"})    ' Germany
        lc.AddRange(New String() {"white", "blue"})             ' Greece
        lc.AddRange(New String() {"red", "white", "green"})     ' Hungary
        lc.AddRange(New String() {"green", "white", "orange"})  ' Ireland
        lc.AddRange(New String() {"green", "white", "red"})     ' Italy
        lc.AddRange(New String() {"red", "white"})              ' Latvia
        lc.AddRange(New String() {"orange", "green", "red"})    ' Lithuania
        lc.AddRange(New String() {"red", "white", "blue"})      ' Luxembourg
        lc.AddRange(New String() {"red", "white"})              ' Malta
        lc.AddRange(New String() {"red", "white", "blue"})      ' Netherlands
        lc.AddRange(New String() {"white", "red"})              ' Poland
        lc.AddRange(New String() {"red", "green"})              ' Portugal
        lc.AddRange(New String() {"blue", "yellow", "red"})     ' Romania
        lc.AddRange(New String() {"white", "blue", "red"})      ' Slovakia
        lc.AddRange(New String() {"white", "blue", "red"})      ' Slovenia
        lc.AddRange(New String() {"red", "yellow"})             ' Spain
        lc.AddRange(New String() {"blue", "yellow"})            ' Sweden
        lc.AddRange(New String() {"blue", "white", "red"})      ' United Kingdom

        WriteLine()
        MyWriteLine("Distinct ----------------")
        Console.Write("lc: ")
        lc.MyWriteLine()
        Console.Write("lc.Distinct(): ")
        lc.Distinct.MyWriteLine()
    End Sub

    ' Sorts a sequence using a provided function that returns an integer rank for each element of the series
    ' Note: there is no overload that would use CompareTo of IComparable(Of T) such as the one used by Max()
    Sub TestOrderBy()
        Dim li As Integer() = {5, 2, 3, 8, 1, 9, 4, 11, 6, -1, 7, 0}
        Dim ts() As String = {"one", "upon", "a", "time", "in", "a", "far", "away", "kingdom"}

        WriteLine()
        MyWriteLine("OrderBy -----------------")
        Console.Write("li: ")
        li.MyWriteLine()
        Console.Write("li.OrderByDescending(Function(i) i): ")
        li.OrderByDescending(Function(i) i).MyWriteLine()
        Console.Write("ts: ")
        ts.MyWriteLine()
        Console.Write("li.OrderBy(Function(s) s.length): ")
        ts.OrderBy(Function(s) s.Length).MyWriteLine()
    End Sub

    Structure TornadoEvent
        Public startingDate As Date
        Public eventName As String
    End Structure

    ' Groups the elements of a sequence according to a specified key selector function
    Sub TestGroupBy()
        ' Data from http://www.ezl.com/~fireball/Disaster15.htm
        Dim tt As TornadoEvent() = {
        New TornadoEvent With {.startingDate = #5/7/1840#, .eventName = "The Great Natchez Tornado"},
        New TornadoEvent With {.startingDate = #2/19/1884#, .eventName = "The Great Southern Tornado Outbreak"},
        New TornadoEvent With {.startingDate = #3/27/1890#, .eventName = "The Louisville/KY Outbreak"},
        New TornadoEvent With {.startingDate = #5/27/1896#, .eventName = "St. Louis Outbreak"},
        New TornadoEvent With {.startingDate = #6/12/1899#, .eventName = "New Richmond Tornado"},
        New TornadoEvent With {.startingDate = #4/23/1908#, .eventName = "The Dixie Outbreak"},
        New TornadoEvent With {.startingDate = #3/23/1913#, .eventName = "Devastating tornadoes across east/northeast and west Iowa"},
        New TornadoEvent With {.startingDate = #4/20/1920#, .eventName = "Mississippi and Alabama 7 killer tornadoes"},
        New TornadoEvent With {.startingDate = #3/18/1925#, .eventName = "Tri-State Tornado"},
        New TornadoEvent With {.startingDate = #4/12/1927#, .eventName = "Rock Springs/Tex"},
        New TornadoEvent With {.startingDate = #5/8/1927#, .eventName = "Poplar Bluff Outbreak"},
        New TornadoEvent With {.startingDate = #9/29/1927#, .eventName = "St. Louis/Mo"},
        New TornadoEvent With {.startingDate = #5/6/1930#, .eventName = "Hill/Navarro/Ellis Co./Tex"},
        New TornadoEvent With {.startingDate = #3/21/1932#, .eventName = "10 violent tornadoes which smashed through Alabama/Georgia/and Tennessee"},
        New TornadoEvent With {.startingDate = #4/5/1936#, .eventName = "Tupelo-Gainesville Outbreak"},
        New TornadoEvent With {.startingDate = #9/29/1938#, .eventName = "Charleston/S.C."},
        New TornadoEvent With {.startingDate = #3/16/1942#, .eventName = "Central to NE Miss."},
        New TornadoEvent With {.startingDate = #3/27/1942#, .eventName = "Rogers & #5/es Co./Okla."},
        New TornadoEvent With {.startingDate = #6/23/1944#, .eventName = "A series of tornadoes hit Pennsylvania/Ohio/West Virginia/and Maryland"},
        New TornadoEvent With {.startingDate = #3/12/1945#, .eventName = "Okla.-Ark."},
        New TornadoEvent With {.startingDate = #4/9/1947#, .eventName = "A family of tornadoes swept through Texas/Oklahoma/and Kansas."},
        New TornadoEvent With {.startingDate = #3/19/1948#, .eventName = "A tornado touched down in North Alton/Illinois"},
        New TornadoEvent With {.startingDate = #1/3/1949#, .eventName = "La. & Ark."},
        New TornadoEvent With {.startingDate = #3/21/1952#, .eventName = "Tornadoes slashed over Arkansas/Mississippi/Missouri/and Tennessee"},
        New TornadoEvent With {.startingDate = #5/11/1953#, .eventName = "The Waco Tornado"},
        New TornadoEvent With {.startingDate = #6/8/1953#, .eventName = "The Flint Tornado/The Worcester Tornado"},
        New TornadoEvent With {.startingDate = #12/5/1953#, .eventName = "Vicksburg/Miss."},
        New TornadoEvent With {.startingDate = #5/25/1955#, .eventName = "The Udall/Kansas Tornado"},
        New TornadoEvent With {.startingDate = #5/20/1957#, .eventName = "Kan./Mo."},
        New TornadoEvent With {.startingDate = #6/4/1958#, .eventName = "Northwestern Wisconsin"},
        New TornadoEvent With {.startingDate = #2/10/1959#, .eventName = "St. Louis/Mo."},
        New TornadoEvent With {.startingDate = #5/5/1960#, .eventName = "SE Oklahoma/Arkansas"},
        New TornadoEvent With {.startingDate = #4/11/1965#, .eventName = "Palm Sunday Outbreak"},
        New TornadoEvent With {.startingDate = #3/3/1966#, .eventName = "Jackson/Miss."},
        New TornadoEvent With {.startingDate = #3/3/1966#, .eventName = "Mississippi/Alabama"},
        New TornadoEvent With {.startingDate = #1/24/1967#, .eventName = "St. Louis County"},
        New TornadoEvent With {.startingDate = #3/21/1967#, .eventName = "Ill./Mich"},
        New TornadoEvent With {.startingDate = #5/15/1968#, .eventName = "Midwest"},
        New TornadoEvent With {.startingDate = #1/23/1969#, .eventName = "Mississippi"},
        New TornadoEvent With {.startingDate = #2/21/1971#, .eventName = "The Mississippi Delta Outbreak"},
        New TornadoEvent With {.startingDate = #5/26/1973#, .eventName = "South/Midwest (series)"},
        New TornadoEvent With {.startingDate = #4/3/1974#, .eventName = "Super Outbreak 148 tornadoes over 13 states in the South and Midwest!"},
        New TornadoEvent With {.startingDate = #4/4/1977#, .eventName = "Ala./Miss./Ga."},
        New TornadoEvent With {.startingDate = #4/10/1979#, .eventName = "The Wichita Falls Tornado"},
        New TornadoEvent With {.startingDate = #6/3/1980#, .eventName = "Grand Island/Neb. (series)"},
        New TornadoEvent With {.startingDate = #3/2/1982#, .eventName = "South/Midwest (series)"},
        New TornadoEvent With {.startingDate = #5/29/1982#, .eventName = "So. Ill."},
        New TornadoEvent With {.startingDate = #5/18/1983#, .eventName = "Tex."},
        New TornadoEvent With {.startingDate = #3/28/1984#, .eventName = "The Carolina Outbreak"},
        New TornadoEvent With {.startingDate = #3/21/1984#, .eventName = "Mississippi"},
        New TornadoEvent With {.startingDate = #4/26/1984#, .eventName = "Series Okla. to Minn."},
        New TornadoEvent With {.startingDate = #5/31/1985#, .eventName = "Pennsylvania-Ohio Outbreak"},
        New TornadoEvent With {.startingDate = #5/22/1987#, .eventName = "Saragosa/Tex."},
        New TornadoEvent With {.startingDate = #11/15/1989#, .eventName = "Huntsville/Ala."},
        New TornadoEvent With {.startingDate = #11/16/1989#, .eventName = "Newburgh/N.Y."},
        New TornadoEvent With {.startingDate = #6/2/1990#, .eventName = "Midwest/Great Lakes"},
        New TornadoEvent With {.startingDate = #8/28/1990#, .eventName = "N. Ill."},
        New TornadoEvent With {.startingDate = #4/26/1991#, .eventName = "Andover Outbreak"},
        New TornadoEvent With {.startingDate = #11/21/1992#, .eventName = "The Widespread Outbreak"},
        New TornadoEvent With {.startingDate = #3/27/1994#, .eventName = "Palm Sunday Outbreak"},
        New TornadoEvent With {.startingDate = #4/8/1998#, .eventName = "Western Jefferson County/Alabama."},
        New TornadoEvent With {.startingDate = #5/3/1999#, .eventName = "70 large tornadoes swept though Texas/Oklahoma and Kansas."},
        New TornadoEvent With {.startingDate = #12/16/2000#, .eventName = "Tuscaloosa/Alabama"},
        New TornadoEvent With {.startingDate = #11/12/2002#, .eventName = "from Louisiana to Pennsylvania"},
        New TornadoEvent With {.startingDate = #5/5/2003#, .eventName = "Kansas/Missouri and Tennessee"}
        }

        WriteLine()
        MyWriteLine("GroupBy -----------------")
        Dim lgroups As IEnumerable(Of IGrouping(Of Integer, TornadoEvent)) = tt.GroupBy(Function(te As TornadoEvent) Month(te.startingDate))
        Dim lgroupsSortedByMonth As IEnumerable(Of IGrouping(Of Integer, TornadoEvent)) = lgroups.OrderBy(Function(g As IGrouping(Of Integer, TornadoEvent)) g.Key)
        For Each mois As IGrouping(Of Integer, TornadoEvent) In lgroupsSortedByMonth
            MyWriteLine("Month " & mois.Key.ToString & ": " & mois.Count.ToString & " event(s)")
        Next
    End Sub

    Structure Person
        Public Name As String
    End Structure

    Structure Animal
        Public Name As String
        Public Owner As Person
    End Structure

    ' Correlates the elements of two sequences based on matching keys using the default equality comparer to compare keys
    Sub TestJoin()
        Dim magnus As New Person With {.Name = "Hedlund, Magnus"}
        Dim terry As New Person With {.Name = "Adams, Terry"}
        Dim charlotte As New Person With {.Name = "Weiss, Charlotte"}

        Dim barley As New Animal With {.Name = "Barley", .Owner = terry}
        Dim boots As New Animal With {.Name = "Boots", .Owner = terry}
        Dim whiskers As New Animal With {.Name = "Whiskers", .Owner = charlotte}
        Dim daisy As New Animal With {.Name = "Daisy", .Owner = magnus}

        Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte})
        Dim animals As New List(Of Animal)(New Animal() {barley, boots, whiskers, daisy})

        ' Create a list of Person-Animal pairs, where each element is an
        ' anonymous type that contains a Animal's name and the name of the
        ' Person that owns the Animal.
        ' Join is used as as extension of IEnumerable(of People)
        ' TOuter = Person, outer = people
        ' TInner = Animal, inner = animals
        ' outerKeySelector As Func(Of TOuter, TKey) = Function(person) person, so TKey = Person
        ' innerKeySelector As Func(Of TInner, TKey) = Function(Animal) Animal.Owner
        ' resultSelector As Func(Of TOuter, TInner, TResult)
        ' With minimal typing:
        Dim query =
            people.Join(animals,
                        Function(person) person,
                        Function(animal) animal.Owner,
                        Function(person, Animal) New With {.OwnerName = person.Name, .Animal = Animal.Name})

        ' With complete typing:
        Dim query2 As IEnumerable(Of OwnerAnimal) =
            people.Join _
                (animals,
                Function(person As Person) person,
                Function(animal As Animal) animal.Owner,
                Function(person As Person, animal As Animal) New OwnerAnimal With {.OwnerName = person.Name, .AnimalName = animal.Name})

        WriteLine()
        MyWriteLine("Join --------------------")
        For Each obj In query2
            MyWriteLine(obj.OwnerName & ": " & obj.AnimalName)
        Next
    End Sub

    Structure OwnerAnimal
        Public OwnerName As String
        Public AnimalName As String
    End Structure

    Sub TestGroupJoin()
        Dim magnus As New Person With {.Name = "Hedlund, Magnus"}
        Dim terry As New Person With {.Name = "Adams, Terry"}
        Dim charlotte As New Person With {.Name = "Weiss, Charlotte"}

        Dim barley As New Animal With {.Name = "Barley", .Owner = terry}
        Dim boots As New Animal With {.Name = "Boots", .Owner = terry}
        Dim whiskers As New Animal With {.Name = "Whiskers", .Owner = charlotte}
        Dim daisy As New Animal With {.Name = "Daisy", .Owner = magnus}

        Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte})
        Dim Animals As New List(Of Animal)(New Animal() {barley, boots, whiskers, daisy})

        ' Create a collection where each element is an anonymous type
        ' that contains a Person's name and a collection of names of
        ' the Animals that are owned by them.
        Dim query =
            people.GroupJoin(Animals,
                       Function(person) person,
                       Function(Animal) Animal.Owner,
                       Function(person, AnimalCollection) _
                           New With {.OwnerName = person.Name,
                                     .Animals = AnimalCollection.Select(
                                                        Function(Animal) Animal.Name)})

        WriteLine()
        MyWriteLine("GroupJoin ---------------")
        For Each obj In query
            ' Output the owner's name.
            Console.Write(obj.OwnerName & ": ")
            ' Output each of the owner's Animal's names.
            obj.Animals.MyWriteLine()
            'For Each Animal As String In obj.Animals
            '    Console.Write(" " & Animal)
            'Next
            'WriteLine()
        Next

    End Sub

    ' Simply reverses a sequence
    ' Internally, it's copied to a Buffer array
    Sub TestReverse()
        Dim WeekDays As String() = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday"}

        WriteLine()
        MyWriteLine("Reverse -----------------")
        Console.Write("WeekDays: ")
        WeekDays.MyWriteLine()
        Console.Write("WeekDays.Reverse: ")
        WeekDays.Reverse.MyWriteLine()
    End Sub

    ' Select extensions apply a transformation function on an enumeration
    ' Select transforms 1 element in 1 element
    ' SelectMany transforms 1 element in a sequence, and flattens the result
    Sub TestSelect()
        Dim ts() As String = {"one", "upon", "a", "time", "in", "a", "far", "away", "kingdom"}
        Dim ils As IEnumerable(Of Integer) = ts.Select(Function(s) s.Length)
        Dim ilc As IEnumerable(Of Char) = ts.SelectMany(Function(s) s.ToCharArray)

        WriteLine()
        MyWriteLine("Reverse -----------------")
        Console.Write("ts: ")
        ts.MyWriteLine()
        Console.Write("ts.Select(Function(s) s.Length): ")
        ils.MyWriteLine()
        Console.Write("ts.SelectMany(Function(s) s.ToCharArray): ")
        ilc.MyWriteLine()
    End Sub

    Class BaseBloke
        Public Name As String
        Public Age As Integer
    End Class

    Class Bloke
        Inherits BaseBloke
        Public LivesIn As String
    End Class

    ' Conversion to various objects that implement more sophisticated interfaces than IEnumerable(Of T)
    ' (No visual output)
    Sub TestToX()
        Dim ii As IEnumerable(Of Integer) = Enumerable.Range(1, 10)
        Dim tb As Bloke() = {New Bloke With {.Name = "Pierre", .Age = 43, .LivesIn = "Grenoble"}, New Bloke With {.Name = "Jacques", .Age = 39, .LivesIn = "Lyon"}}

        ' Simple array
        Dim ti As Integer() = ii.ToArray
        ' Simple list
        Dim li As List(Of Integer) = ii.ToList
        ' Simple dictionary, with a function that returns key
        Dim db As Dictionary(Of String, Bloke) = tb.ToDictionary(Function(b As Bloke) b.Name)
        ' A dictionary with a specific comparer
        Dim dbCaseInsensitive As Dictionary(Of String, Bloke) = tb.ToDictionary(Function(b As Bloke) b.Name, StringComparer.InvariantCultureIgnoreCase)
        ' A dictionary with a transformation function to return a new object
        Dim dbb As Dictionary(Of String, BaseBloke) = tb.ToDictionary(Function(b As Bloke) b.Name, Function(b As Bloke) New BaseBloke With {.Name = b.Name, .Age = b.Age})
    End Sub

    ' Awful implementation of Eratosthene's sieve using Enumerable extensions
    ' to show clearly the dark side of this kind of programming
    '
    ' For each pass of the loop, one or two (if element is a prime) new enumerators are
    ' created ==> memory and processing time increases at each pass of the loop, while a
    ' traditional implementaiton with a BitArray doesn't have this kind of issue
    Sub TestCrible()
        Const pMax As Integer = 400
        Dim sw1, sw2 As New Stopwatch
        Dim l1, l2 As IEnumerable(Of Integer)
        sw1.Start()
        l1 = CribleWithSequence(pMax)
        sw1.Stop()
        sw2.Start()
        l2 = CribleTraditional(pMax)
        sw2.Stop()

        WriteLine()
        MyWriteLine("TestCrible --------------")
        MyWriteLine("From 2 to " & pMax.ToString)
        MyWriteLine("Enumerable:  " & l1.Count & " primes, elapsed=" & sw1.Elapsed.ToString)
        MyWriteLine("Traditional: " & l2.Count & " primes, elapsed=" & sw2.Elapsed.ToString)
        MyWriteLine("Elapsed ratio Trad/Enum: " & CLng(sw1.ElapsedTicks / sw2.ElapsedTicks).ToString)
    End Sub

    ' Note that with a "yield return" statement we could return directly the prime sequence
    ' without building a list
    Function CribleWithSequence(pMax As Integer) As IEnumerable(Of Integer)
        Dim li As IEnumerable(Of Integer) = Enumerable.Range(2, pMax - 1)
        Dim lp As New List(Of Integer)
        Do While li.Any                     ' .Any = not .isEmpty (contains at least one element)
            ' Take list head
            Dim p As Integer = li.First
            If p <> 0 Then
                ' It's a prime!
                lp.Add(p)
                ' Replace all multiples of p by zero, keep the rest
                li = li.Select(Function(n As Integer, index As Integer) If(index Mod p, n, 0))
            End If
            ' Continue with the rest of the list
            li = li.Skip(1)
        Loop
        Return lp
    End Function

    ' More than 1000 times faster for pMax=400, and it gets much worse when pMax is greater!
    ' Reverse the usual bit convention to avoid the initialization of all bits to true (can
    ' be done by the constructor, but takes 0.1s for list with more than 10 million bits...)
    Function CribleTraditional(pMax As Integer) As IEnumerable(Of Integer)
        Dim tb = New BitArray(pMax / 2 + 1)                 ' Don't test even numbers
        Dim lp = New List(Of Integer) From {
            2
        }
        Dim nv = 3                                          ' Start at 3
        While nv <= pMax
            If (Not tb((nv - 1) / 2)) Then
                lp.Add(nv)
                Dim nvr = nv + nv + nv                      ' First to check is 3 x prime, since 1xprime, we already know, and 2xprime is even
                While nvr <= pMax
                    'If (Not tb((nvr - 1) / 2)) Then        ' 20% slower with this test
                    tb((nvr - 1) / 2) = True
                    nvr += nv + nv                          ' Skip even numbers
                End While
            End If
            nv += 2
        End While
        Return lp
    End Function

End Module