Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace SecondaryAxesSample.Model
    Public Class CurrencyInfo
        Public Sub New(ByVal [date] As Date, ByVal value As Double)
            Me.Date = [date]
            Me.Value = value
            Me.ChangeRate = 0
        End Sub
        Public Property [Date]() As Date
        Public Property Value() As Double
        Public Property ChangeRate() As Double

        Public Sub UpdateChangeRate(ByVal prevInfo As CurrencyInfo)
            ChangeRate = 100 * ((Me.Value / prevInfo.Value) - 1)
        End Sub
    End Class

    Public Class ChartModel
        Private privateCurrencyInfos As IReadOnlyList(Of CurrencyInfo)
        Public Property CurrencyInfos() As IReadOnlyList(Of CurrencyInfo)
            Get
                Return privateCurrencyInfos
            End Get
            Private Set(ByVal value As IReadOnlyList(Of CurrencyInfo))
                privateCurrencyInfos = value
            End Set
        End Property
        Public Sub New()
            CurrencyInfos = New List(Of CurrencyInfo)() From { _
                New CurrencyInfo(New Date(2018, 3, 29), 0.812219), _
                New CurrencyInfo(New Date(2018, 3, 28), 0.808507), _
                New CurrencyInfo(New Date(2018, 3, 27), 0.805010), _
                New CurrencyInfo(New Date(2018, 3, 26), 0.805637), _
                New CurrencyInfo(New Date(2018, 3, 25), 0.809225), _
                New CurrencyInfo(New Date(2018, 3, 24), 0.809264), _
                New CurrencyInfo(New Date(2018, 3, 23), 0.810088), _
                New CurrencyInfo(New Date(2018, 3, 22), 0.810826), _
                New CurrencyInfo(New Date(2018, 3, 21), 0.813835), _
                New CurrencyInfo(New Date(2018, 3, 20), 0.813088), _
                New CurrencyInfo(New Date(2018, 3, 19), 0.812814), _
                New CurrencyInfo(New Date(2018, 3, 18), 0.813568), _
                New CurrencyInfo(New Date(2018, 3, 17), 0.813531), _
                New CurrencyInfo(New Date(2018, 3, 16), 0.812850), _
                New CurrencyInfo(New Date(2018, 3, 15), 0.809969), _
                New CurrencyInfo(New Date(2018, 3, 14), 0.807702), _
                New CurrencyInfo(New Date(2018, 3, 13), 0.809091), _
                New CurrencyInfo(New Date(2018, 3, 12), 0.811534), _
                New CurrencyInfo(New Date(2018, 3, 11), 0.812401), _
                New CurrencyInfo(New Date(2018, 3, 10), 0.812427), _
                New CurrencyInfo(New Date(2018, 3, 9), 0.812363), _
                New CurrencyInfo(New Date(2018, 3, 8), 0.808501), _
                New CurrencyInfo(New Date(2018, 3, 7), 0.805534), _
                New CurrencyInfo(New Date(2018, 3, 6), 0.807911), _
                New CurrencyInfo(New Date(2018, 3, 5), 0.811605), _
                New CurrencyInfo(New Date(2018, 3, 4), 0.811525), _
                New CurrencyInfo(New Date(2018, 3, 3), 0.811609), _
                New CurrencyInfo(New Date(2018, 3, 2), 0.813141), _
                New CurrencyInfo(New Date(2018, 3, 1), 0.819303) _
            }

            For i As Integer = 0 To CurrencyInfos.Count - 2
                CurrencyInfos(i).UpdateChangeRate(CurrencyInfos(i + 1))
            Next i

            Dim lastCurrency = New CurrencyInfo(New Date(2018, 2, 28), 0.818623)
            CurrencyInfos.Last().UpdateChangeRate(lastCurrency)
        End Sub
    End Class
End Namespace
