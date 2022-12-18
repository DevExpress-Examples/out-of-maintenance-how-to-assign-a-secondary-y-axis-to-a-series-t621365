Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace SecondaryAxesSample.Model

    Public Class CurrencyInfo

        Public Sub New(ByVal [date] As Date, ByVal value As Double)
            Me.Date = [date]
            Me.Value = value
            ChangeRate = 0
        End Sub

        Public Property [Date] As Date

        Public Property Value As Double

        Public Property ChangeRate As Double

        Public Sub UpdateChangeRate(ByVal prevInfo As CurrencyInfo)
            ChangeRate = 100 * (Value / prevInfo.Value - 1)
        End Sub
    End Class

    Public Class ChartModel

        Private _CurrencyInfos As IReadOnlyList(Of SecondaryAxesSample.Model.CurrencyInfo)

        Public Property CurrencyInfos As IReadOnlyList(Of CurrencyInfo)
            Get
                Return _CurrencyInfos
            End Get

            Private Set(ByVal value As IReadOnlyList(Of CurrencyInfo))
                _CurrencyInfos = value
            End Set
        End Property

        Public Sub New()
            CurrencyInfos = New List(Of CurrencyInfo)() From {New CurrencyInfo(New DateTime(2018, 3, 29), 0.812219), New CurrencyInfo(New DateTime(2018, 3, 28), 0.808507), New CurrencyInfo(New DateTime(2018, 3, 27), 0.805010), New CurrencyInfo(New DateTime(2018, 3, 26), 0.805637), New CurrencyInfo(New DateTime(2018, 3, 25), 0.809225), New CurrencyInfo(New DateTime(2018, 3, 24), 0.809264), New CurrencyInfo(New DateTime(2018, 3, 23), 0.810088), New CurrencyInfo(New DateTime(2018, 3, 22), 0.810826), New CurrencyInfo(New DateTime(2018, 3, 21), 0.813835), New CurrencyInfo(New DateTime(2018, 3, 20), 0.813088), New CurrencyInfo(New DateTime(2018, 3, 19), 0.812814), New CurrencyInfo(New DateTime(2018, 3, 18), 0.813568), New CurrencyInfo(New DateTime(2018, 3, 17), 0.813531), New CurrencyInfo(New DateTime(2018, 3, 16), 0.812850), New CurrencyInfo(New DateTime(2018, 3, 15), 0.809969), New CurrencyInfo(New DateTime(2018, 3, 14), 0.807702), New CurrencyInfo(New DateTime(2018, 3, 13), 0.809091), New CurrencyInfo(New DateTime(2018, 3, 12), 0.811534), New CurrencyInfo(New DateTime(2018, 3, 11), 0.812401), New CurrencyInfo(New DateTime(2018, 3, 10), 0.812427), New CurrencyInfo(New DateTime(2018, 3, 9), 0.812363), New CurrencyInfo(New DateTime(2018, 3, 8), 0.808501), New CurrencyInfo(New DateTime(2018, 3, 7), 0.805534), New CurrencyInfo(New DateTime(2018, 3, 6), 0.807911), New CurrencyInfo(New DateTime(2018, 3, 5), 0.811605), New CurrencyInfo(New DateTime(2018, 3, 4), 0.811525), New CurrencyInfo(New DateTime(2018, 3, 3), 0.811609), New CurrencyInfo(New DateTime(2018, 3, 2), 0.813141), New CurrencyInfo(New DateTime(2018, 3, 1), 0.819303)}
            Dim i As Integer = 0
            While i < CurrencyInfos.Count - 1
                CurrencyInfos(i).UpdateChangeRate(CurrencyInfos(i + 1))
                Threading.Interlocked.Increment(i)
            End While

            Dim lastCurrency = New CurrencyInfo(New DateTime(2018, 2, 28), 0.818623)
            Enumerable.Last(CurrencyInfos).UpdateChangeRate(lastCurrency)
        End Sub
    End Class
End Namespace
