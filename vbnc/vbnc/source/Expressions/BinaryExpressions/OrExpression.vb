' 
' Visual Basic.Net Compiler
' Copyright (C) 2004 - 2010 Rolf Bjarne Kvinge, RKvinge@novell.com
' 
' This library is free software; you can redistribute it and/or
' modify it under the terms of the GNU Lesser General Public
' License as published by the Free Software Foundation; either
' version 2.1 of the License, or (at your option) any later version.
' 
' This library is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
' Lesser General Public License for more details.
' 
' You should have received a copy of the GNU Lesser General Public
' License along with this library; if not, write to the Free Software
' Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
' 

Public Class OrExpression
    Inherits BinaryExpression

    Overrides ReadOnly Property ExpressionType() As Mono.Cecil.TypeReference
        Get
            Dim result As Mono.Cecil.TypeReference
            Dim lType, rType As Mono.Cecil.TypeReference

            lType = Me.LeftType
            rType = Me.RightType

            If Helper.CompareType(lType, rType) AndAlso Helper.IsEnum(Compiler, lType) Then
                result = lType
            Else
                result = MyBase.ExpressionType()
            End If

            Return result
        End Get
    End Property

    Protected Overrides Function GenerateCodeInternal(ByVal Info As EmitInfo) As Boolean
        Dim result As Boolean = True

        ValidateBeforeGenerateCode(Info)

        Dim expInfo As EmitInfo = Info.Clone(Me, True, False, OperandType)

        result = m_LeftExpression.GenerateCode(expInfo) AndAlso result
        result = m_RightExpression.GenerateCode(expInfo) AndAlso result

        Select Case OperandTypeCode
            Case TypeCode.Byte, TypeCode.SByte, TypeCode.Int16, TypeCode.UInt16, TypeCode.Int32, TypeCode.UInt32, TypeCode.Int64, TypeCode.UInt64, TypeCode.Boolean
                Emitter.EmitOr(Info, OperandType)
            Case TypeCode.Object
                Helper.Assert(Helper.CompareType(OperandType, Compiler.TypeCache.System_Object))
                Emitter.EmitCall(Info, Compiler.TypeCache.MS_VB_CS_Operators__OrObject_Object_Object)
            Case Else
                Throw New InternalException(Me)
        End Select

        Return result
    End Function

    Sub New(ByVal Parent As ParsedObject, ByVal LExp As Expression, ByVal RExp As Expression)
        MyBase.New(Parent, LExp, RExp)
    End Sub

    Public Overrides ReadOnly Property Keyword() As KS
        Get
            Return KS.Or
        End Get
    End Property

    Public Overrides ReadOnly Property IsConstant() As Boolean
        Get
            Return MyBase.IsConstant 'CHECK: is this true?
        End Get
    End Property

    Public Overrides ReadOnly Property ConstantValue() As Object
        Get
            Dim rvalue, lvalue As Object
            lvalue = m_LeftExpression.ConstantValue
            rvalue = m_RightExpression.ConstantValue
            If lvalue Is Nothing Or rvalue Is Nothing Then
                Return Nothing
            Else

                Dim tlvalue, trvalue As Mono.Cecil.TypeReference
                Dim clvalue, crvalue As TypeCode
                tlvalue = CecilHelper.GetType(Compiler, lvalue)
                clvalue = Helper.GetTypeCode(Compiler, tlvalue)
                trvalue = CecilHelper.GetType(Compiler, rvalue)
                crvalue = Helper.GetTypeCode(Compiler, trvalue)

                If clvalue = TypeCode.Boolean AndAlso crvalue = TypeCode.Boolean Then
                    Return CBool(lvalue) Or CBool(rvalue)
                End If

                Dim smallest As Mono.Cecil.TypeReference
                Dim csmallest As TypeCode
                smallest = Compiler.TypeResolution.GetSmallestIntegralType(tlvalue, trvalue)
                Helper.Assert(smallest IsNot Nothing)
                csmallest = Helper.GetTypeCode(Compiler, smallest)
                Select Case csmallest
                    Case TypeCode.Byte
                        Return CByte(lvalue) Or CByte(rvalue)
                    Case TypeCode.SByte
                        Return CSByte(lvalue) Or CSByte(rvalue)
                    Case TypeCode.Int16
                        Return CShort(lvalue) Or CShort(rvalue)
                    Case TypeCode.UInt16
                        Return CUShort(lvalue) Or CUShort(rvalue)
                    Case TypeCode.Int32
                        Return CInt(lvalue) Or CInt(rvalue)
                    Case TypeCode.UInt32
                        Return CUInt(lvalue) Or CUInt(rvalue)
                    Case TypeCode.Int64
                        Return CLng(lvalue) Or CLng(rvalue)
                    Case TypeCode.UInt64
                        Return CULng(lvalue) Or CULng(rvalue)
                    Case TypeCode.Double
                        'Return CDbl(lvalue) Or CDbl(rvalue)
                        Throw New InternalException(Me)
                    Case TypeCode.Single
                        'Return CSng(lvalue) Or CSng(rvalue)
                        Throw New InternalException(Me)
                    Case TypeCode.Decimal
                        'Return CDec(lvalue) Or CDec(rvalue)
                        Throw New InternalException(Me)
                    Case Else
                        Throw New InternalException(Me)
                End Select
            End If
        End Get
    End Property
End Class
