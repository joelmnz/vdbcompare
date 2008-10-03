Public Class frmBuyNow

    'Const BUY_NOW_URL As String = "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=sales%40meikleprogramming%2ecom&item_name=vdbCompare&amount=20%2e00&no_shipping=1&return=http%3a%2f%2fmeikleprogramming%2ecom%2fmain%2fnode%2f5&currency_code=USD&lc=US&bn=PP%2dBuyNowBF&charset=UTF%2d8"
    '16-Feb-07: updating to be products sale page as link may change, best to use global link.
    Const BUY_NOW_URL As String = "http://meikleprogramming.com/main/node/3#buynow"
    Private Const STR_Mailtosales As String = "mailto:sales@meikleprogramming.com?subject=vdbCompare"
    Private Const STR_Httpwwwshareit As String = "http://www.shareit.com/ccc/index.html?publisherid=200053871&languageid=1"


    Private Sub btnBuyNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuyNow.Click
        BuyNow()
    End Sub




    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        BuyNow()
    End Sub

    Private Sub BuyNow()
        G.StartProcess(BUY_NOW_URL)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        G.StartProcess(STR_Httpwwwshareit)
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        G.StartProcess(STR_Mailtosales)
    End Sub

End Class