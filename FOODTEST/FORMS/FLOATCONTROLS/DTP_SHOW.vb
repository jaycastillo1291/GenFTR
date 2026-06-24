Public Class dtpDialog
    Property DateFormat As String = "MM/dd/yyyy HH:mm"
    Property MousePosition1 As Point = MousePosition
    Property DefaultValue As DateTime = ServerDate()

    Property MaxDate As Date = "2099/12/31"

    Property MinDate As Date = "1/1/2000"

    Private Sub DateTimePickerDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Optional: Set initial value or customize DateTimePicker properties
        MyBase.Location = MousePosition1
        DateTimePicker1.CustomFormat = DateFormat
        DateTimePicker1.Value = DefaultValue
        DateTimePicker1.MinDate = MinDate
        DateTimePicker1.MaxDate = MaxDate
    End Sub

    'Public ReadOnly Property SelectedDateTime As DateTime
    '    Get
    '        Return DateTimePicker1.Value
    '    End Get
    'End Property

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles btnCancelButton.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Public ReadOnly Property SelectedDate As Date
        Get
            Return DateTimePicker1.Value.Date
        End Get
    End Property

    Public ReadOnly Property SelectedDateTime As DateTime
        Get
            Return DateTimePicker1.Value
        End Get
    End Property
End Class