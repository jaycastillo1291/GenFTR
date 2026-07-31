Public Class FormResizer

    Private Structure ControlState
        Public Bounds As Rectangle
        Public FontSize As Single
    End Structure

    Private ReadOnly _targetForm As Form
    Private _originalFormSize As Size
    Private ReadOnly _controlStates As New Dictionary(Of Control, ControlState)
    Private _isInitialized As Boolean = False

    ' THIS IS THE CONSTRUCTOR (Where Option A happens)
    Public Sub New(targetForm As Form)
        _targetForm = targetForm

        ' 1. Wire up the Resize event so it triggers whenever you drag the window
        AddHandler _targetForm.Resize, AddressOf OnFormResize

        ' 2. Turn on double buffering to prevent screen flickering
        SetDoubleBuffered(_targetForm)

        ' 3. Option A: Record all control sizes right now, immediately!
        CaptureOriginalLayout()
    End Sub

    Private Sub CaptureOriginalLayout()
        If _isInitialized Then Return

        _originalFormSize = _targetForm.ClientSize

        _controlStates.Clear()
        SaveStates(_targetForm)

        _isInitialized = True
    End Sub

    Private Sub SaveStates(parent As Control)
        For Each ctrl As Control In parent.Controls
            _controlStates(ctrl) = New ControlState With {
                .Bounds = ctrl.Bounds,
                .FontSize = ctrl.Font.Size
            }

            If ctrl.HasChildren Then
                SaveStates(ctrl)
            End If
        Next
    End Sub

    Private Sub OnFormResize(sender As Object, e As EventArgs)
        If Not _isInitialized OrElse _originalFormSize.Width = 0 OrElse _originalFormSize.Height = 0 Then
            Return
        End If

        _targetForm.SuspendLayout()

        Dim scaleX As Single = CSng(_targetForm.ClientSize.Width) / CSng(_originalFormSize.Width)
        Dim scaleY As Single = CSng(_targetForm.ClientSize.Height) / CSng(_originalFormSize.Height)

        ScaleControls(_targetForm, scaleX, scaleY)

        _targetForm.ResumeLayout()
    End Sub

    Private Sub ScaleControls(parent As Control, scaleX As Single, scaleY As Single)
        Dim fontScale As Single = (scaleX + scaleY) / 2.0F

        For Each ctrl As Control In parent.Controls
            If _controlStates.ContainsKey(ctrl) Then
                Dim original As ControlState = _controlStates(ctrl)

                Dim newX As Integer = CInt(original.Bounds.X * scaleX)
                Dim newY As Integer = CInt(original.Bounds.Y * scaleY)
                Dim newWidth As Integer = CInt(original.Bounds.Width * scaleX)
                Dim newHeight As Integer = CInt(original.Bounds.Height * scaleY)

                If TypeOf ctrl Is TextBox AndAlso Not DirectCast(ctrl, TextBox).Multiline Then
                    ctrl.Location = New Point(newX, newY)
                    ctrl.Width = newWidth
                Else
                    ctrl.SetBounds(newX, newY, newWidth, newHeight)
                End If

                Dim newFontSize As Single = original.FontSize * fontScale
                If newFontSize < 8.0F Then newFontSize = 8.0F
                If newFontSize > 28.0F Then newFontSize = 28.0F

                ctrl.Font = New Font(ctrl.Font.FontFamily, newFontSize, ctrl.Font.Style)
            End If

            If ctrl.HasChildren Then
                ScaleControls(ctrl, scaleX, scaleY)
            End If
        Next
    End Sub

    Private Sub SetDoubleBuffered(ctrl As Control)
        Dim pi = GetType(Control).GetProperty("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        If pi IsNot Nothing Then
            pi.SetValue(ctrl, True, Nothing)
        End If
    End Sub

End Class




''Public Class FormResizer

''    ' Stores original bounds and font size for each control
''    Private Structure ControlState
''        Public Bounds As Rectangle
''        Public FontSize As Single
''    End Structure

''    Private ReadOnly _targetForm As Form
''    Private _originalFormSize As Size
''    Private ReadOnly _controlStates As New Dictionary(Of Control, ControlState)
''    Private _isInitializing As Boolean = True

''    ''' <summary>
''    ''' Enables automatic proportional scaling for the specified Form and its controls.
''    ''' </summary>
''    ''' <param name="targetForm">The Form instance to enable auto-scaling on.</param>
''    ''' <param name="preserveAspectRatio">Set to True to scale uniformly without stretching controls out of shape.</param>
''    Public Property PreserveAspectRatio As Boolean = False
''    Public Property MinFontSize As Single = 8.0F
''    Public Property MaxFontSize As Single = 28.0F

''    Public Sub New(targetForm As Form, Optional preserveAspectRatio As Boolean = False)
''        _targetForm = targetForm
''        Me.PreserveAspectRatio = preserveAspectRatio

''        ' Wire up form events automatically
''        AddHandler _targetForm.Load, AddressOf OnFormLoad
''        AddHandler _targetForm.Resize, AddressOf OnFormResize
''    End Sub

''    Private Sub OnFormLoad(sender As Object, e As EventArgs)
''        ' Enable double buffering on the form to avoid flickering during resize
''        SetDoubleBuffered(_targetForm)

''        ' Record initial dimensions
''        _originalFormSize = _targetForm.ClientSize
''        SaveOriginalStates(_targetForm)

''        _isInitializing = False
''    End Sub

''    Private Sub SaveOriginalStates(parent As Control)
''        For Each ctrl As Control In parent.Controls
''            _controlStates(ctrl) = New ControlState With {
''                .Bounds = ctrl.Bounds,
''                .FontSize = ctrl.Font.Size
''            }

''            ' Recurse into child containers (Panels, GroupBoxes, TabPages, etc.)
''            If ctrl.HasChildren Then
''                SaveOriginalStates(ctrl)
''            End If
''        Next
''    End Sub

''    Private Sub OnFormResize(sender As Object, e As EventArgs)
''        If _isInitializing OrElse _originalFormSize.Width = 0 OrElse _originalFormSize.Height = 0 Then Return

''        _targetForm.SuspendLayout()

''        Dim scaleX As Single = CSng(_targetForm.ClientSize.Width) / CSng(_originalFormSize.Width)
''        Dim scaleY As Single = CSng(_targetForm.ClientSize.Height) / CSng(_originalFormSize.Height)

''        ScaleControls(_targetForm, scaleX, scaleY)

''        _targetForm.ResumeLayout()
''    End Sub

''    Private Sub ScaleControls(parent As Control, scaleX As Single, scaleY As Single)
''        ' Choose between uniform (aspect ratio locked) or free stretch
''        Dim fontScale As Single = If(PreserveAspectRatio, Math.Min(scaleX, scaleY), (scaleX + scaleY) / 2.0F)
''        Dim widthScale As Single = If(PreserveAspectRatio, Math.Min(scaleX, scaleY), scaleX)
''        Dim heightScale As Single = If(PreserveAspectRatio, Math.Min(scaleX, scaleY), scaleY)

''        For Each ctrl As Control In parent.Controls
''            If _controlStates.ContainsKey(ctrl) Then
''                Dim original As ControlState = _controlStates(ctrl)

''                ' 1. Calculate new bounds
''                Dim newX As Integer = CInt(original.Bounds.X * scaleX)
''                Dim newY As Integer = CInt(original.Bounds.Y * scaleY)
''                Dim newWidth As Integer = CInt(original.Bounds.Width * widthScale)
''                Dim newHeight As Integer = CInt(original.Bounds.Height * heightScale)

''                ' 2. Apply positioning (handling single-line TextBoxes vs other controls)
''                If TypeOf ctrl Is TextBox AndAlso Not DirectCast(ctrl, TextBox).Multiline Then
''                    ctrl.Location = New Point(newX, newY)
''                    ctrl.Width = newWidth
''                Else
''                    ctrl.SetBounds(newX, newY, newWidth, newHeight)
''                End If

''                ' 3. Calculate and clamp Font size
''                Dim newFontSize As Single = original.FontSize * fontScale
''                If newFontSize < MinFontSize Then newFontSize = MinFontSize
''                If newFontSize > MaxFontSize Then newFontSize = MaxFontSize

''                ctrl.Font = New Font(ctrl.Font.FontFamily, newFontSize, ctrl.Font.Style)
''            End If

''            ' Recurse child controls
''            If ctrl.HasChildren Then
''                ScaleControls(ctrl, scaleX, scaleY)
''            End If
''        Next
''    End Sub

''    ' Uses reflection to safely force DoubleBuffered = True on Form and containers
''    Private Sub SetDoubleBuffered(ctrl As Control)
''        Dim pi = GetType(Control).GetProperty("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
''        If pi IsNot Nothing Then
''            pi.SetValue(ctrl, True, Nothing)
''        End If
''    End Sub

''End Class