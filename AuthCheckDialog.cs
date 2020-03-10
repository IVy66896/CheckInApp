using BannerChurch.Common;
using BannerChurch.Data.Security;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.Security;
using System.Windows.Forms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

public class AuthCheckDialog : RadForm
{
	private IContainer components = null;

	private RadTextBox txtPassword;

	private RadTextBox txtAccount;

	private RadLabel radLabel3;

	private RadLabel radLabel2;

	private RadButton btnOK;

	private RadPanel radPanel1;

	private RadButton btnCancel;

	private RadLabel radLabel4;

	public AuthCheckDialog()
	{
		InitializeComponent();
		base.WindowState = FormWindowState.Normal;
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
	}

	protected override void OnShown(EventArgs e)
	{
		base.OnShown(e);
		txtAccount.Focus();
	}

	private void btnLogin_Click(object sender, EventArgs e)
	{
		bool flag = Membership.ValidateUser(txtAccount.Text, txtPassword.Text);
		if (flag)
		{
			UserInfo userInfo = WinGlobal.DB.GetUserInfo(txtAccount.Text);
			flag = WinGlobal.IsPermissionAllowed(WinGlobal.PermissionDefinitionOption.LessionCheckIn, WinGlobal.PermissionCdOption.Access, userInfo);
		}
		if (flag)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
		else
		{
			ResetInputs();
			MessageBox.Show("帳號密碼輸入錯誤，或者您輸入的帳號沒有報到系統的行政權限。", "權限確認未通過", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
		Dispose();
	}

	public void ResetInputs()
	{
		txtAccount.Text = "";
		txtPassword.Text = "";
		txtAccount.Focus();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		btnOK = new Telerik.WinControls.UI.RadButton();
		txtPassword = new Telerik.WinControls.UI.RadTextBox();
		txtAccount = new Telerik.WinControls.UI.RadTextBox();
		radLabel3 = new Telerik.WinControls.UI.RadLabel();
		radLabel2 = new Telerik.WinControls.UI.RadLabel();
		radPanel1 = new Telerik.WinControls.UI.RadPanel();
		btnCancel = new Telerik.WinControls.UI.RadButton();
		radLabel4 = new Telerik.WinControls.UI.RadLabel();
		((System.ComponentModel.ISupportInitialize)btnOK).BeginInit();
		((System.ComponentModel.ISupportInitialize)txtPassword).BeginInit();
		((System.ComponentModel.ISupportInitialize)txtAccount).BeginInit();
		((System.ComponentModel.ISupportInitialize)radLabel3).BeginInit();
		((System.ComponentModel.ISupportInitialize)radLabel2).BeginInit();
		((System.ComponentModel.ISupportInitialize)radPanel1).BeginInit();
		radPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)btnCancel).BeginInit();
		((System.ComponentModel.ISupportInitialize)radLabel4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this).BeginInit();
		SuspendLayout();
		btnOK.Dock = System.Windows.Forms.DockStyle.Left;
		btnOK.Font = new System.Drawing.Font("Segoe UI", 11f);
		btnOK.Location = new System.Drawing.Point(5, 5);
		btnOK.Name = "btnOK";
		btnOK.Size = new System.Drawing.Size(90, 28);
		btnOK.TabIndex = 5;
		btnOK.Text = "確定";
		btnOK.Click += new System.EventHandler(btnLogin_Click);
		((Telerik.WinControls.UI.RadButtonElement)btnOK.GetChildAt(0)).Text = "確定";
		((Telerik.WinControls.Primitives.TextPrimitive)btnOK.GetChildAt(0).GetChildAt(1).GetChildAt(1)).LineLimit = false;
		((Telerik.WinControls.Primitives.TextPrimitive)btnOK.GetChildAt(0).GetChildAt(1).GetChildAt(1)).ForeColor = System.Drawing.Color.DarkGreen;
		((Telerik.WinControls.Primitives.TextPrimitive)btnOK.GetChildAt(0).GetChildAt(1).GetChildAt(1)).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
		txtPassword.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
		txtPassword.Location = new System.Drawing.Point(68, 85);
		txtPassword.Name = "txtPassword";
		txtPassword.PasswordChar = '*';
		txtPassword.Size = new System.Drawing.Size(163, 29);
		txtPassword.TabIndex = 2;
		txtAccount.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
		txtAccount.Location = new System.Drawing.Point(68, 53);
		txtAccount.Name = "txtAccount";
		txtAccount.Size = new System.Drawing.Size(163, 29);
		txtAccount.TabIndex = 1;
		radLabel3.Font = new System.Drawing.Font("Segoe UI", 10f);
		radLabel3.Location = new System.Drawing.Point(12, 60);
		radLabel3.Name = "radLabel3";
		radLabel3.Size = new System.Drawing.Size(50, 21);
		radLabel3.TabIndex = 1;
		radLabel3.Text = "帳號：";
		radLabel3.ThemeName = "ControlDefault";
		((Telerik.WinControls.UI.RadLabelElement)radLabel3.GetChildAt(0)).Text = "帳號：";
		radLabel2.Font = new System.Drawing.Font("Segoe UI", 10f);
		radLabel2.Location = new System.Drawing.Point(12, 92);
		radLabel2.Name = "radLabel2";
		radLabel2.Size = new System.Drawing.Size(50, 21);
		radLabel2.TabIndex = 2;
		radLabel2.Text = "密碼：";
		radLabel2.ThemeName = "ControlDefault";
		((Telerik.WinControls.UI.RadLabelElement)radLabel2.GetChildAt(0)).Text = "密碼：";
		radPanel1.BackColor = System.Drawing.Color.Silver;
		radPanel1.Controls.Add(btnCancel);
		radPanel1.Controls.Add(btnOK);
		radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		radPanel1.Location = new System.Drawing.Point(0, 138);
		radPanel1.Name = "radPanel1";
		radPanel1.Padding = new System.Windows.Forms.Padding(5);
		radPanel1.Size = new System.Drawing.Size(336, 38);
		radPanel1.TabIndex = 107;
		btnCancel.CausesValidation = false;
		btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
		btnCancel.Font = new System.Drawing.Font("Segoe UI", 11f);
		btnCancel.Location = new System.Drawing.Point(95, 5);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(68, 28);
		btnCancel.TabIndex = 7;
		btnCancel.Text = "取消";
		radLabel4.Font = new System.Drawing.Font("Segoe UI", 15f, System.Drawing.FontStyle.Bold);
		radLabel4.ForeColor = System.Drawing.Color.DarkGreen;
		radLabel4.Location = new System.Drawing.Point(12, 13);
		radLabel4.Name = "radLabel4";
		radLabel4.Size = new System.Drawing.Size(268, 31);
		radLabel4.TabIndex = 108;
		radLabel4.Text = "請輸入您的行政帳號與密碼";
		radLabel4.ThemeName = "ControlDefault";
		((Telerik.WinControls.UI.RadLabelElement)radLabel4.GetChildAt(0)).Text = "請輸入您的行政帳號與密碼";
		base.AcceptButton = btnOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.WhiteSmoke;
		base.ClientSize = new System.Drawing.Size(336, 176);
		base.Controls.Add(radLabel4);
		base.Controls.Add(radPanel1);
		base.Controls.Add(txtPassword);
		base.Controls.Add(txtAccount);
		base.Controls.Add(radLabel3);
		base.Controls.Add(radLabel2);
		Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "AuthCheckDialog";
		base.RootElement.ApplyShapeToControl = true;
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "權限確認";
		base.ThemeName = "ControlDefault";
		((System.ComponentModel.ISupportInitialize)btnOK).EndInit();
		((System.ComponentModel.ISupportInitialize)txtPassword).EndInit();
		((System.ComponentModel.ISupportInitialize)txtAccount).EndInit();
		((System.ComponentModel.ISupportInitialize)radLabel3).EndInit();
		((System.ComponentModel.ISupportInitialize)radLabel2).EndInit();
		((System.ComponentModel.ISupportInitialize)radPanel1).EndInit();
		radPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)btnCancel).EndInit();
		((System.ComponentModel.ISupportInitialize)radLabel4).EndInit();
		((System.ComponentModel.ISupportInitialize)this).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
