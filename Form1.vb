
Public Class Form1
    Dim w As New Integer 'membuat variabel w dengan tipe integer
    Dim h As New Integer 'membuat variabel h dengan tipe integer
    Dim x As Integer 'membuat variabel x dengan tipe integer
    Dim y As Integer 'membuat variabel y dengan tipe integer
    Dim a, r, g, b As Integer 'membuat variabel a,r,g,b dengan tipe integer


    Private Sub buka_Click(sender As Object, e As EventArgs) Handles buka.Click 'jika tombol buka di klik maka akan menjalankan script
        Dim ofd As New OpenFileDialog 'mendeklarasikan OpenFileDialog baru menjadi variabel ofd
        ofd.Title = "Pilih Gambar" 'mengatur judul openfiledialog menjadi "Pilih Gambar"
        ofd.Filter = "image files|*.bmp;*.jpg" 'mengatur filter dari openfiledialog sehingga hanya bisa membuka file gambar
        ofd.RestoreDirectory = True 'mengatur jika kita membuka suatu file di salah satu direktori, maka saat openfiledialog dijalankan akan berada di direktori sebelumnya
        If ofd.ShowDialog() = DialogResult.OK Then 'membuat premis jika openfiledialog saat membuka file bernilai benar sesuai filter maka
            tampilan1.Image = New Bitmap(ofd.FileName) 'pada tampilan1 akan memuat sebuah gambar sesuai dengan file yang di pilih openfiledialog
            tampilan1.SizeMode = PictureBoxSizeMode.StretchImage 'mengatur besaran gambar akan sesuai dengan picbox yang telah di buat
        End If
    End Sub

    Private Sub salin_Click(sender As Object, e As EventArgs) Handles salin.Click 'jika tombol salin di klik makan akan menjalankan script
        If IsNothing(tampilan1.Image) Then 'membuat premis jika picbox pada tampilan1 tidak menampilkan gambar maka
            MessageBox.Show("Anda Belum Memilih Gambar!", "Gagal Menyalin Gambar", MessageBoxButtons.OK, MessageBoxIcon.Warning) 'maka akan mengeluarkan sebuah dialog pesan yang  berisi tulisan sesuai yang telah diatur, memiliki tombol OK dan menampilkan ikon warning
        Else 'atau
            Dim gambar As New Bitmap(tampilan1.Image, tampilan1.Width, tampilan1.Height) 'mendeklarasikan sebuah variabel gambar menjadi bitmap baru yang memiliki gambar, panjang dan lebar pada picbox tampilan1
            Dim salinan As New Bitmap(tampilan2.Width, tampilan2.Height) 'mendeklarasikan sebuah variabel yang bernama salinan sebagai tempat menampung variabel panjang dan lebar pada picbox tampilan2
            For Me.y = 0 To gambar.Height - 1 'perulangan jika y = 0 menuju gambar yang tingginya -1 (karena koordinat 0 juga di hitung sehingga -1)
                For Me.x = 0 To gambar.Width - 1 'perulangan jika x = 0 menuju gambar yang lebarnya - 1 (karena koordinat 0 juga di hitung sehingga -1)
                    salinan.SetPixel(x, y, gambar.GetPixel(x, y)) 'maka variabel salinan akan mengset pixel pada koordinat perulangan x dan y sesuai dengan koordinat pada variabel gambar
                Next x 'perulangan dilanjutkan sampai ke x
            Next y 'perulangan dilanjutkan sampai ke y
            radioR.Enabled = True 'mengatur radiobutton Red mempunyai nilai true
            radioG.Enabled = True 'mengatur radiobutton Green mempunyai nilai true
            radioB.Enabled = True 'mengatur radiobutton Blue mempunyai nilai true
            radioC.Enabled = True 'mengatur radiobutton Cyan mempunyai nilai true
            radioM.Enabled = True 'mengatur radiobutton Magenta mempunyai nilai true
            radioY.Enabled = True 'mengatur radiobutton Yellow mempunyai nilai true
            tampilan2.Image = salinan 'mengatur bahwa picbox tampilan2 adalah isi dari variabel salinan
        End If
    End Sub

    Private Sub radioR_CheckedChanged(sender As Object, e As EventArgs) Handles radioR.CheckedChanged 'jika radioR di check/ di pilih maka akan menjalankan script
        If IsNothing(tampilan2.Image) Then 'membuat premis jika picbo tampilan2 tidak memuat gambar maka
            MessageBox.Show("Salin Gambar Terlebih Dahulu!", "Gagal Memfilter", MessageBoxButtons.OK, MessageBoxIcon.Warning) 'mengeluarkan pesan dan memberi tombol OK serta memunculkan ikon warning
        Else 'atau
            w = tampilan1.ClientSize.Width 'mendeklarasikan bahwa w adalah lebar dari ukuran gambar yang berada di picbox tampilan1
            h = tampilan1.ClientSize.Height 'mendeklarasikan bahwa h adalah tinggi dari ukuran gambar yang berada di picbox tampilan1
            Dim gambarfilter As New Bitmap(w, h) 'mendeklarasikan variabel gambarfilter sebagai tempat menyimpan nilai w dan h
            tampilan1.DrawToBitmap(gambarfilter, tampilan1.ClientRectangle) 'untuk menyalin border bitmap dari tampilan1 ke variable gambarfilter

            If radioR.Checked = True Then 'membuat premis jika radioR bernilai true maka
                For Me.y = 0 To h - 1 'perulangan jika y = 0 menuju variabel h yang tingginya - 1 (karena koordinat 0 juga di hitung sehingga -1)
                    For Me.x = 0 To w - 1 'perulangan jika x = 0 menuju variabel w yang lebarnya - 1 (karena koordinat 0 juga di hitung sehingga -1
                        Dim pixelcolor As Color = gambarfilter.GetPixel(x, y) 'membuat sebuah variabel dengan nama pixelcolor sebagai tempat untuk menampung warna yang berada pada pixel sesuai dengan koordinat perulangan
                        r = pixelcolor.R 'mendeklarasikan bahwa variabel r merupakan warna pixel dari red
                        gambarfilter.SetPixel(x, y, Color.FromArgb(r, 0, 0)) 'setelah itu variabel gambar filter akan di atur perpixel sesuai dengan koordinat perulangan menjadi warna Argb (a,r,0,0)
                    Next x 'perulangan dilanjutkan sampai ke x
                Next y 'perulangan dilanjutkan sampai ke y
                tampilan3.Image = gambarfilter 'mendeklarasikan bahwa picbox tampilan3 memuat image dari variabel gambarfilter
            End If
        End If
    End Sub

    Private Sub radioG_CheckedChanged(sender As Object, e As EventArgs) Handles radioG.CheckedChanged
        If IsNothing(tampilan2.Image) Then
            MessageBox.Show("Ikuti Langkah - Langkah !", "Gagal Mengisikan Filter", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            w = tampilan1.ClientSize.Width
            h = tampilan1.ClientSize.Height
            Dim gambarfilter As New Bitmap(w, h)
            tampilan1.DrawToBitmap(gambarfilter, tampilan1.ClientRectangle)

            If radioG.Checked = True Then
                For Me.y = 0 To h - 1
                    For Me.x = 0 To w - 1
                        Dim pixelcolor As Color = gambarfilter.GetPixel(x, y)
                        g = pixelcolor.G
                        gambarfilter.SetPixel(x, y, Color.FromArgb(0, g, 0))
                    Next x
                Next y
                tampilan3.Image = gambarfilter
            End If
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles radioB.CheckedChanged
        If IsNothing(tampilan2.Image) Then
            MessageBox.Show("Ikuti Langkah - Langkah !", "Gagal Mengisikan Filter", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            w = tampilan1.ClientSize.Width
            h = tampilan1.ClientSize.Height
            Dim gambarfilter As New Bitmap(w, h)
            tampilan1.DrawToBitmap(gambarfilter, tampilan1.ClientRectangle)

            If radioB.Checked = True Then
                For Me.y = 0 To h - 1
                    For Me.x = 0 To w - 1
                        Dim pixelcolor As Color = gambarfilter.GetPixel(x, y)
                        b = pixelcolor.B
                        gambarfilter.SetPixel(x, y, Color.FromArgb(0, 0, b))
                    Next x
                Next y
                tampilan3.Image = gambarfilter
            End If
        End If
    End Sub

    Private Sub radioC_CheckedChanged(sender As Object, e As EventArgs) Handles radioC.CheckedChanged
        If IsNothing(tampilan2.Image) Then
            MessageBox.Show("Ikuti Langkah - Langkah !", "Gagal Mengisikan Filter", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            w = tampilan1.ClientSize.Width
            h = tampilan1.ClientSize.Height
            Dim gambarfilter As New Bitmap(w, h)
            tampilan1.DrawToBitmap(gambarfilter, tampilan1.ClientRectangle)

            If radioC.Checked = True Then
                For Me.y = 0 To h - 1
                    For Me.x = 0 To w - 1
                        Dim pixelcolor As Color = gambarfilter.GetPixel(x, y)
                        g = pixelcolor.G
                        b = pixelcolor.B
                        gambarfilter.SetPixel(x, y, Color.FromArgb(0, g, b))
                    Next x
                Next y
                tampilan3.Image = gambarfilter
            End If
        End If
    End Sub

    Private Sub T_keluar_Click(sender As Object, e As EventArgs) Handles T_Keluar.Click
        Dim result = MessageBox.Show("Yakin Anda ingin keluar ?", "Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Close() 'untuk keluar dari form
        End If
    End Sub

    Private Sub T_ulang_Click(sender As Object, e As EventArgs) Handles T_Ulang.Click
        Controls.Clear() 'untuk menghapus semua control yang ada
        InitializeComponent() 'untuk memuat kembali componen-componen yang ada pada form
    End Sub

    Private Sub radioM_CheckedChanged(sender As Object, e As EventArgs) Handles radioM.CheckedChanged
        If IsNothing(tampilan2.Image) Then
            MessageBox.Show("Ikuti Langkah - Langkah !", "Gagal Mengisikan Filter", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            w = tampilan1.ClientSize.Width
            h = tampilan1.ClientSize.Height
            Dim gambarfilter As New Bitmap(w, h)
            tampilan1.DrawToBitmap(gambarfilter, tampilan1.ClientRectangle)

            If radioM.Checked = True Then
                For Me.y = 0 To h - 1
                    For Me.x = 0 To w - 1
                        Dim pixelcolor As Color = gambarfilter.GetPixel(x, y)
                        r = pixelcolor.R
                        b = pixelcolor.B
                        gambarfilter.SetPixel(x, y, Color.FromArgb(r, 0, b))
                    Next x
                Next y
                tampilan3.Image = gambarfilter
            End If
        End If
    End Sub

    Private Sub radioY_CheckedChanged(sender As Object, e As EventArgs) Handles radioY.CheckedChanged
        If IsNothing(tampilan2.Image) Then
            MessageBox.Show("Ikuti Langkah - Langkah !", "Gagal Mengisikan Filter", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            w = tampilan1.ClientSize.Width
            h = tampilan1.ClientSize.Height
            Dim gambarfilter As New Bitmap(w, h)
            tampilan1.DrawToBitmap(gambarfilter, tampilan1.ClientRectangle)

            If radioY.Checked = True Then
                For Me.y = 0 To h - 1
                    For Me.x = 0 To w - 1
                        Dim pixelcolor As Color = gambarfilter.GetPixel(x, y)
                        r = pixelcolor.R
                        g = pixelcolor.G
                        gambarfilter.SetPixel(x, y, Color.FromArgb(r, g, 0))
                    Next x
                Next y
                tampilan3.Image = gambarfilter
            End If
        End If
    End Sub

End Class