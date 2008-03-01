Module ArrayFieldsVariableChar1
    Dim a As Char()
    Dim b As Char(,)
    Dim c As Char(,,)
    Dim d As Char(,,,)
    Dim aa() As Char
    Dim bb(,) As Char
    Dim cc(,,) As Char
    Dim dd(,,,) As Char

    Function Main() As Int32
        Dim result As Int32

        a = New Char() {}
        b = New Char(,) {}
        c = New Char(,,) {}
        d = New Char(,,,) {}

        aa = New Char() {}
        bb = New Char(,) {}
        cc = New Char(,,) {}
        dd = New Char(,,,) {}

        result += ArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 0 Then result += ArrayVerifier.Report()
        If b.Length <> 0 Then result += ArrayVerifier.Report()
        If c.Length <> 0 Then result += ArrayVerifier.Report()
        If d.Length <> 0 Then result += ArrayVerifier.Report()

        If aa.Length <> 0 Then result += ArrayVerifier.Report()
        If bb.Length <> 0 Then result += ArrayVerifier.Report()
        If cc.Length <> 0 Then result += ArrayVerifier.Report()
        If dd.Length <> 0 Then result += ArrayVerifier.Report()

        a = New Char() {}
        b = New Char(,) {{}}
        c = New Char(,,) {{{}}}
        d = New Char(,,,) {{{{}}}}

        aa = New Char() {}
        bb = New Char(,) {{}}
        cc = New Char(,,) {{{}}}
        dd = New Char(,,,) {{{{}}}}

        result += ArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 0 Then result += ArrayVerifier.Report()
        If b.Length <> 0 Then result += ArrayVerifier.Report()
        If c.Length <> 0 Then result += ArrayVerifier.Report()
        If d.Length <> 0 Then result += ArrayVerifier.Report()

        If aa.Length <> 0 Then result += ArrayVerifier.Report()
        If bb.Length <> 0 Then result += ArrayVerifier.Report()
        If cc.Length <> 0 Then result += ArrayVerifier.Report()
        If dd.Length <> 0 Then result += ArrayVerifier.Report()


        a = New Char() {Chr(1), Chr(2)}
        b = New Char(,) {{Chr(10), Chr(11)}, {Chr(12), Chr(13)}}
        c = New Char(,,) {{{Chr(20), Chr(21)}, {Chr(22), Chr(23)}}, {{Chr(24), Chr(25)}, {Chr(26), Chr(27)}}}
        d = New Char(,,,) {{{{Chr(30), Chr(31)}, {Chr(32), Chr(33)}}, {{Chr(34), Chr(35)}, {Chr(36), Chr(37)}}}, {{{Chr(40), Chr(41)}, {Chr(42), Chr(43)}}, {{Chr(44), Chr(45)}, {Chr(46), Chr(47)}}}}

        aa = New Char() {Chr(1), Chr(2)}
        bb = New Char(,) {{Chr(10), Chr(11)}, {Chr(12), Chr(13)}}
        cc = New Char(,,) {{{Chr(20), Chr(21)}, {Chr(22), Chr(23)}}, {{Chr(24), Chr(25)}, {Chr(26), Chr(27)}}}
        dd = New Char(,,,) {{{{Chr(30), Chr(31)}, {Chr(32), Chr(33)}}, {{Chr(34), Chr(35)}, {Chr(36), Chr(37)}}}, {{{Chr(40), Chr(41)}, {Chr(42), Chr(43)}}, {{Chr(44), Chr(45)}, {Chr(46), Chr(47)}}}}

        result += ArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 2 Then result += ArrayVerifier.Report()
        If b.Length <> 4 Then result += ArrayVerifier.Report()
        If c.Length <> 8 Then result += ArrayVerifier.Report()
        If d.Length <> 16 Then result += ArrayVerifier.Report()

        If aa.Length <> 2 Then result += ArrayVerifier.Report()
        If bb.Length <> 4 Then result += ArrayVerifier.Report()
        If cc.Length <> 8 Then result += ArrayVerifier.Report()
        If dd.Length <> 16 Then result += ArrayVerifier.Report()

        a = New Char() {Chr(51), Chr(52)}
        b = New Char(,) {{Chr(50), Chr(51)}, {Chr(52), Chr(53)}}
        c = New Char(,,) {{{Chr(60), Chr(61)}, {Chr(62), Chr(63)}}, {{Chr(64), Chr(65)}, {Chr(66), Chr(67)}}}
        d = New Char(,,,) {{{{Chr(70), Chr(71)}, {Chr(72), Chr(73)}}, {{Chr(74), Chr(75)}, {Chr(76), Chr(77)}}}, {{{Chr(80), Chr(81)}, {Chr(82), Chr(83)}}, {{Chr(84), Chr(85)}, {Chr(86), Chr(87)}}}}

        aa(0) = Chr(51)
        aa(1) = Chr(52)
        bb(0, 0) = Chr(50)
        bb(0, 1) = Chr(51)
        bb(1, 0) = Chr(52)
        bb(1, 1) = Chr(53)
        cc(0, 0, 0) = Chr(60)
        cc(0, 0, 1) = Chr(61)
        cc(0, 1, 0) = Chr(62)
        cc(0, 1, 1) = Chr(63)
        cc(1, 0, 0) = Chr(64)
        cc(1, 0, 1) = Chr(65)
        cc(1, 1, 0) = Chr(66)
        cc(1, 1, 1) = Chr(67)

        dd(0, 0, 0, 0) = Chr(70)
        dd(0, 0, 0, 1) = Chr(71)
        dd(0, 0, 1, 0) = Chr(72)
        dd(0, 0, 1, 1) = Chr(73)
        dd(0, 1, 0, 0) = Chr(74)
        dd(0, 1, 0, 1) = Chr(75)
        dd(0, 1, 1, 0) = Chr(76)
        dd(0, 1, 1, 1) = Chr(77)

        dd(1, 0, 0, 0) = Chr(80)
        dd(1, 0, 0, 1) = Chr(81)
        dd(1, 0, 1, 0) = Chr(82)
        dd(1, 0, 1, 1) = Chr(83)
        dd(1, 1, 0, 0) = Chr(84)
        dd(1, 1, 0, 1) = Chr(85)
        dd(1, 1, 1, 0) = Chr(86)
        dd(1, 1, 1, 1) = Chr(87)

        result += ArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 2 Then result += ArrayVerifier.Report()
        If b.Length <> 4 Then result += ArrayVerifier.Report()
        If c.Length <> 8 Then result += ArrayVerifier.Report()
        If d.Length <> 16 Then result += ArrayVerifier.Report()

        If aa.Length <> 2 Then result += ArrayVerifier.Report()
        If bb.Length <> 4 Then result += ArrayVerifier.Report()
        If cc.Length <> 8 Then result += ArrayVerifier.Report()
        If dd.Length <> 16 Then result += ArrayVerifier.Report()

        Return result
    End Function

End Module