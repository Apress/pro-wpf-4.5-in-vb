Imports System.ComponentModel

Public Class Product
    Implements INotifyPropertyChanged

    Private _modelNumber As String
    Public Property ModelNumber() As String
        Get
            Return _modelNumber
        End Get
        Set(ByVal value As String)
            _modelNumber = value
            OnPropertyChanged(New PropertyChangedEventArgs("ModelNumber"))
        End Set
    End Property

    Private _modelName As String
    Public Property ModelName() As String
        Get
            Return _modelName
        End Get
        Set(ByVal value As String)
            _modelName = value
            OnPropertyChanged(New PropertyChangedEventArgs("ModelName"))
        End Set
    End Property

    Private _unitCost As Decimal
    Public Property UnitCost() As Decimal
        Get
            Return _unitCost
        End Get
        Set(ByVal value As Decimal)
            _unitCost = value
            OnPropertyChanged(New PropertyChangedEventArgs("UnitCost"))
        End Set
    End Property

    Private _description As String
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
            OnPropertyChanged(New PropertyChangedEventArgs("Description"))
        End Set
    End Property

    Private _categoryName As String
    Public Property CategoryName() As String
        Get
            Return _categoryName
        End Get
        Set(ByVal value As String)
            _categoryName = value
        End Set
    End Property

    ' For DataGridComboBoxColumn example.
    Private _categoryID As Integer
    Public Property CategoryID() As Integer
        Get
            Return _categoryID
        End Get
        Set(ByVal value As Integer)
            _categoryID = value
        End Set
    End Property

    Private _productImagePath As String
    Public Property ProductImagePath() As String
        Get
            Return _productImagePath
        End Get
        Set(ByVal value As String)
            _productImagePath = value
        End Set
    End Property

	Public Sub New(ByVal modelNumber As String, ByVal modelName As String, ByVal unitCost As Decimal, ByVal description As String)
        Me.ModelNumber = modelNumber
		Me.ModelName = modelName
		Me.UnitCost = unitCost
		Me.Description = description
	End Sub

	Public Sub New(ByVal modelNumber As String, ByVal modelName As String, ByVal unitCost As Decimal, ByVal description As String, ByVal productImagePath As String)
		Me.New(modelNumber, modelName, unitCost, description)
		Me.ProductImagePath = productImagePath
	End Sub

    Public Sub New(ByVal modelNumber As String, ByVal modelName As String, ByVal unitCost As Decimal, ByVal description As String, _
                   ByVal categoryID As Integer, ByVal categoryName As String, ByVal productImagePath As String)
        Me.New(modelNumber, modelName, unitCost, description)
        Me.CategoryID = categoryID
        Me.CategoryName = CategoryName
        Me.ProductImagePath = productImagePath
    End Sub

	Public Overrides Function ToString() As String
		Return ModelName & " (" & ModelNumber & ")"
	End Function

	Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
	Public Sub OnPropertyChanged(ByVal e As PropertyChangedEventArgs)
		If Not PropertyChangedEvent Is Nothing Then
			RaiseEvent PropertyChanged(Me, e)
		End If
    End Sub

    ' This for testing date editing. The value isn't actually stored in the database.
    Private _dateAdded As DateTime = DateTime.Today
    Public Property DateAdded() As DateTime
        Get
            Return _dateAdded
        End Get
        Set(ByVal value As DateTime)
            _dateAdded = value
        End Set
    End Property

End Class
