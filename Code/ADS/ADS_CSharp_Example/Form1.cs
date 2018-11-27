using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using TwinCAT.Ads;


namespace Sample07
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button btnDeleteNotifications;
		internal System.Windows.Forms.Button btnAddNotifications;
		internal System.Windows.Forms.Button btnWrite;
		internal System.Windows.Forms.Button btnRead;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.TextBox tbComplexStruct_dintArr;
		internal System.Windows.Forms.Label Label14;
		internal System.Windows.Forms.TextBox tbComplexStruct_ByteVal;
		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.TextBox tbComplexStruct_SimpleStruct1_lrealVal;
		internal System.Windows.Forms.Label Label12;
		internal System.Windows.Forms.TextBox tbComplexStruct_SimpleStruct_dintVal;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox tbComplexStruct_stringVal;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox tbComplexStruct_boolVal;
		internal System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.TextBox tbComplexStruct_IntVal;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.TextBox tbStr2;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.TextBox tbStr1;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.TextBox tblreal1;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox tbUsint1;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox tbDint1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox tbBool1;
		internal System.Windows.Forms.Label Label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        //PLC variable handles
        private int htest1;
        private int hdint1;
		private int hbool1;    
		private int husint1;
		private int hlreal1;
		private int hstr1;
		private int hstr2;
		private int hcomplexStruct;
		private ArrayList notificationHandles;
		
		private TcAdsClient adsClient;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnDeleteNotifications = new System.Windows.Forms.Button();
			this.btnAddNotifications = new System.Windows.Forms.Button();
			this.btnWrite = new System.Windows.Forms.Button();
			this.btnRead = new System.Windows.Forms.Button();
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.tbComplexStruct_dintArr = new System.Windows.Forms.TextBox();
			this.Label14 = new System.Windows.Forms.Label();
			this.tbComplexStruct_ByteVal = new System.Windows.Forms.TextBox();
			this.Label13 = new System.Windows.Forms.Label();
			this.tbComplexStruct_SimpleStruct1_lrealVal = new System.Windows.Forms.TextBox();
			this.Label12 = new System.Windows.Forms.Label();
			this.tbComplexStruct_SimpleStruct_dintVal = new System.Windows.Forms.TextBox();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.tbComplexStruct_stringVal = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.tbComplexStruct_boolVal = new System.Windows.Forms.TextBox();
			this.Label9 = new System.Windows.Forms.Label();
			this.tbComplexStruct_IntVal = new System.Windows.Forms.TextBox();
			this.Label10 = new System.Windows.Forms.Label();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.tbStr2 = new System.Windows.Forms.TextBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.tbStr1 = new System.Windows.Forms.TextBox();
			this.Label8 = new System.Windows.Forms.Label();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.tblreal1 = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.tbUsint1 = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.tbDint1 = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.tbBool1 = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.GroupBox3.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnDeleteNotifications
			// 
			this.btnDeleteNotifications.Location = new System.Drawing.Point(472, 112);
			this.btnDeleteNotifications.Name = "btnDeleteNotifications";
			this.btnDeleteNotifications.Size = new System.Drawing.Size(112, 23);
			this.btnDeleteNotifications.TabIndex = 13;
			this.btnDeleteNotifications.Text = "Delete Notifications";
			this.btnDeleteNotifications.Click += new System.EventHandler(this.btnDeleteNotifications_Click);
			// 
			// btnAddNotifications
			// 
			this.btnAddNotifications.Location = new System.Drawing.Point(472, 80);
			this.btnAddNotifications.Name = "btnAddNotifications";
			this.btnAddNotifications.Size = new System.Drawing.Size(112, 23);
			this.btnAddNotifications.TabIndex = 12;
			this.btnAddNotifications.Text = "Add Notifications";
			this.btnAddNotifications.Click += new System.EventHandler(this.btnAddNotifications_Click);
			// 
			// btnWrite
			// 
			this.btnWrite.Location = new System.Drawing.Point(472, 48);
			this.btnWrite.Name = "btnWrite";
			this.btnWrite.Size = new System.Drawing.Size(112, 23);
			this.btnWrite.TabIndex = 11;
			this.btnWrite.Text = "Write";
			this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
			// 
			// btnRead
			// 
			this.btnRead.Location = new System.Drawing.Point(472, 16);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(112, 23);
			this.btnRead.TabIndex = 10;
			this.btnRead.Text = "Read";
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// GroupBox3
			// 
			this.GroupBox3.Controls.Add(this.tbComplexStruct_dintArr);
			this.GroupBox3.Controls.Add(this.Label14);
			this.GroupBox3.Controls.Add(this.tbComplexStruct_ByteVal);
			this.GroupBox3.Controls.Add(this.Label13);
			this.GroupBox3.Controls.Add(this.tbComplexStruct_SimpleStruct1_lrealVal);
			this.GroupBox3.Controls.Add(this.Label12);
			this.GroupBox3.Controls.Add(this.tbComplexStruct_SimpleStruct_dintVal);
			this.GroupBox3.Controls.Add(this.Label11);
			this.GroupBox3.Controls.Add(this.Label5);
			this.GroupBox3.Controls.Add(this.tbComplexStruct_stringVal);
			this.GroupBox3.Controls.Add(this.Label3);
			this.GroupBox3.Controls.Add(this.tbComplexStruct_boolVal);
			this.GroupBox3.Controls.Add(this.Label9);
			this.GroupBox3.Controls.Add(this.tbComplexStruct_IntVal);
			this.GroupBox3.Controls.Add(this.Label10);
			this.GroupBox3.Location = new System.Drawing.Point(184, 8);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(272, 280);
			this.GroupBox3.TabIndex = 9;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Complex Structure";
			// 
			// tbComplexStruct_dintArr
			// 
			this.tbComplexStruct_dintArr.Location = new System.Drawing.Point(64, 56);
			this.tbComplexStruct_dintArr.Name = "tbComplexStruct_dintArr";
			this.tbComplexStruct_dintArr.Size = new System.Drawing.Size(192, 20);
			this.tbComplexStruct_dintArr.TabIndex = 20;
			this.tbComplexStruct_dintArr.Text = "";
			// 
			// Label14
			// 
			this.Label14.Location = new System.Drawing.Point(8, 56);
			this.Label14.Name = "Label14";
			this.Label14.Size = new System.Drawing.Size(48, 16);
			this.Label14.TabIndex = 19;
			this.Label14.Text = "dintArr:";
			// 
			// tbComplexStruct_ByteVal
			// 
			this.tbComplexStruct_ByteVal.Location = new System.Drawing.Point(64, 120);
			this.tbComplexStruct_ByteVal.Name = "tbComplexStruct_ByteVal";
			this.tbComplexStruct_ByteVal.Size = new System.Drawing.Size(192, 20);
			this.tbComplexStruct_ByteVal.TabIndex = 18;
			this.tbComplexStruct_ByteVal.Text = "";
			// 
			// Label13
			// 
			this.Label13.Location = new System.Drawing.Point(8, 120);
			this.Label13.Name = "Label13";
			this.Label13.Size = new System.Drawing.Size(56, 16);
			this.Label13.TabIndex = 17;
			this.Label13.Text = "byteVal:";
			// 
			// tbComplexStruct_SimpleStruct1_lrealVal
			// 
			this.tbComplexStruct_SimpleStruct1_lrealVal.Location = new System.Drawing.Point(104, 216);
			this.tbComplexStruct_SimpleStruct1_lrealVal.Name = "tbComplexStruct_SimpleStruct1_lrealVal";
			this.tbComplexStruct_SimpleStruct1_lrealVal.Size = new System.Drawing.Size(152, 20);
			this.tbComplexStruct_SimpleStruct1_lrealVal.TabIndex = 16;
			this.tbComplexStruct_SimpleStruct1_lrealVal.Text = "";
			// 
			// Label12
			// 
			this.Label12.Location = new System.Drawing.Point(48, 216);
			this.Label12.Name = "Label12";
			this.Label12.Size = new System.Drawing.Size(48, 16);
			this.Label12.TabIndex = 15;
			this.Label12.Text = "lrealVal:";
			// 
			// tbComplexStruct_SimpleStruct_dintVal
			// 
			this.tbComplexStruct_SimpleStruct_dintVal.Location = new System.Drawing.Point(104, 248);
			this.tbComplexStruct_SimpleStruct_dintVal.Name = "tbComplexStruct_SimpleStruct_dintVal";
			this.tbComplexStruct_SimpleStruct_dintVal.Size = new System.Drawing.Size(152, 20);
			this.tbComplexStruct_SimpleStruct_dintVal.TabIndex = 14;
			this.tbComplexStruct_SimpleStruct_dintVal.Text = "";
			// 
			// Label11
			// 
			this.Label11.Location = new System.Drawing.Point(48, 248);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(48, 16);
			this.Label11.TabIndex = 13;
			this.Label11.Text = "dintVal:";
			// 
			// Label5
			// 
			this.Label5.Location = new System.Drawing.Point(8, 184);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(80, 23);
			this.Label5.TabIndex = 12;
			this.Label5.Text = "simpleStruct1:";
			// 
			// tbComplexStruct_stringVal
			// 
			this.tbComplexStruct_stringVal.Location = new System.Drawing.Point(64, 152);
			this.tbComplexStruct_stringVal.Name = "tbComplexStruct_stringVal";
			this.tbComplexStruct_stringVal.Size = new System.Drawing.Size(192, 20);
			this.tbComplexStruct_stringVal.TabIndex = 11;
			this.tbComplexStruct_stringVal.Text = "";
			// 
			// Label3
			// 
			this.Label3.Location = new System.Drawing.Point(8, 152);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(56, 16);
			this.Label3.TabIndex = 10;
			this.Label3.Text = "stringVal:";
			// 
			// tbComplexStruct_boolVal
			// 
			this.tbComplexStruct_boolVal.Location = new System.Drawing.Point(64, 88);
			this.tbComplexStruct_boolVal.Name = "tbComplexStruct_boolVal";
			this.tbComplexStruct_boolVal.Size = new System.Drawing.Size(192, 20);
			this.tbComplexStruct_boolVal.TabIndex = 3;
			this.tbComplexStruct_boolVal.Text = "";
			// 
			// Label9
			// 
			this.Label9.Location = new System.Drawing.Point(8, 88);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(48, 16);
			this.Label9.TabIndex = 2;
			this.Label9.Text = "boolVal:";
			// 
			// tbComplexStruct_IntVal
			// 
			this.tbComplexStruct_IntVal.Location = new System.Drawing.Point(64, 27);
			this.tbComplexStruct_IntVal.Name = "tbComplexStruct_IntVal";
			this.tbComplexStruct_IntVal.Size = new System.Drawing.Size(192, 20);
			this.tbComplexStruct_IntVal.TabIndex = 1;
			this.tbComplexStruct_IntVal.Text = "";
			// 
			// Label10
			// 
			this.Label10.Location = new System.Drawing.Point(8, 27);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(40, 16);
			this.Label10.TabIndex = 0;
			this.Label10.Text = "intVal:";
			// 
			// GroupBox2
			// 
			this.GroupBox2.Controls.Add(this.tbStr2);
			this.GroupBox2.Controls.Add(this.Label7);
			this.GroupBox2.Controls.Add(this.tbStr1);
			this.GroupBox2.Controls.Add(this.Label8);
			this.GroupBox2.Location = new System.Drawing.Point(8, 168);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(168, 88);
			this.GroupBox2.TabIndex = 8;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "String Types";
			// 
			// tbStr2
			// 
			this.tbStr2.Location = new System.Drawing.Point(48, 56);
			this.tbStr2.Name = "tbStr2";
			this.tbStr2.Size = new System.Drawing.Size(104, 20);
			this.tbStr2.TabIndex = 3;
			this.tbStr2.Text = "";
			// 
			// Label7
			// 
			this.Label7.Location = new System.Drawing.Point(8, 58);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(40, 16);
			this.Label7.TabIndex = 2;
			this.Label7.Text = "str2:";
			// 
			// tbStr1
			// 
			this.tbStr1.Location = new System.Drawing.Point(48, 24);
			this.tbStr1.Name = "tbStr1";
			this.tbStr1.Size = new System.Drawing.Size(104, 20);
			this.tbStr1.TabIndex = 1;
			this.tbStr1.Text = "";
			// 
			// Label8
			// 
			this.Label8.Location = new System.Drawing.Point(8, 27);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(40, 16);
			this.Label8.TabIndex = 0;
			this.Label8.Text = "str1:";
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.Add(this.tblreal1);
			this.GroupBox1.Controls.Add(this.Label6);
			this.GroupBox1.Controls.Add(this.tbUsint1);
			this.GroupBox1.Controls.Add(this.Label4);
			this.GroupBox1.Controls.Add(this.tbDint1);
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Controls.Add(this.tbBool1);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Location = new System.Drawing.Point(8, 8);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(168, 152);
			this.GroupBox1.TabIndex = 7;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Primitive Types";
			// 
			// tblreal1
			// 
			this.tblreal1.Location = new System.Drawing.Point(48, 120);
			this.tblreal1.Name = "tblreal1";
			this.tblreal1.Size = new System.Drawing.Size(104, 20);
			this.tblreal1.TabIndex = 11;
			this.tblreal1.Text = "";
			// 
			// Label6
			// 
			this.Label6.Location = new System.Drawing.Point(8, 120);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(40, 16);
			this.Label6.TabIndex = 10;
			this.Label6.Text = "lreal1:";
			// 
			// tbUsint1
			// 
			this.tbUsint1.Location = new System.Drawing.Point(48, 88);
			this.tbUsint1.Name = "tbUsint1";
			this.tbUsint1.Size = new System.Drawing.Size(104, 20);
			this.tbUsint1.TabIndex = 7;
			this.tbUsint1.Text = "";
			// 
			// Label4
			// 
			this.Label4.Location = new System.Drawing.Point(8, 88);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(40, 16);
			this.Label4.TabIndex = 6;
			this.Label4.Text = "usint1:";
			// 
			// tbDint1
			// 
			this.tbDint1.Location = new System.Drawing.Point(48, 58);
			this.tbDint1.Name = "tbDint1";
			this.tbDint1.Size = new System.Drawing.Size(104, 20);
			this.tbDint1.TabIndex = 3;
			this.tbDint1.Text = "";
			// 
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point(8, 58);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(40, 16);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "dint1:";
			// 
			// tbBool1
			// 
			this.tbBool1.Location = new System.Drawing.Point(48, 27);
			this.tbBool1.Name = "tbBool1";
			this.tbBool1.Size = new System.Drawing.Size(104, 20);
			this.tbBool1.TabIndex = 1;
			this.tbBool1.Text = "";
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(8, 27);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(40, 16);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "bool1:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 302);
			this.Controls.Add(this.btnDeleteNotifications);
			this.Controls.Add(this.btnAddNotifications);
			this.Controls.Add(this.btnWrite);
			this.Controls.Add(this.btnRead);
			this.Controls.Add(this.GroupBox3);
			this.Controls.Add(this.GroupBox2);
			this.Controls.Add(this.GroupBox1);
			this.Name = "Form1";
			this.Text = "Sample07";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{		
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			adsClient = new TcAdsClient();
			notificationHandles = new ArrayList();
			try
			{
				adsClient.Connect("5.59.204.132.1.1" ,851);
				adsClient.AdsNotificationEx+=new AdsNotificationExEventHandler(adsClient_AdsNotificationEx);
				btnDeleteNotifications.Enabled = false;
				//create handles for the PLC variables;
				htest1 = adsClient.CreateVariableHandle("MAIN.test");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			adsClient.Dispose();
		}

		private void btnRead_Click(object sender, System.EventArgs e)
		{
			try
			{           
                //read by handle
				//the second parameter specifies the type of the variable
				tbDint1.Text = adsClient.ReadAny(htest1, typeof(int)).ToString();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnWrite_Click(object sender, System.EventArgs e)
		{
			try
			{
				//write by handle
				//the second parameter is the object to be written to the PLC variable
				adsClient.WriteAny(htest1, int.Parse(tbDint1.Text));
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnAddNotifications_Click(object sender, System.EventArgs e)
		{
			notificationHandles.Clear();
			try
			{
				//register notification            
				notificationHandles.Add(adsClient.AddDeviceNotificationEx("MAIN.dint1", AdsTransMode.OnChange, 100, 0, tbDint1, typeof(int)));
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			btnDeleteNotifications.Enabled = true;
			btnAddNotifications.Enabled = false;
		}

		private void btnDeleteNotifications_Click(object sender, System.EventArgs e)
		{
			//delete registered notifications.
			try
			{
				foreach(int handle in notificationHandles)
					adsClient.DeleteDeviceNotification(handle);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			notificationHandles.Clear();
			btnAddNotifications.Enabled = true;
			btnDeleteNotifications.Enabled = false;
		}

		private void adsClient_AdsNotificationEx(object sender, AdsNotificationExEventArgs e)
		{			 
			TextBox textBox = (TextBox)e.UserData;
			Type type = e.Value.GetType();
			if(type == typeof(string) || type.IsPrimitive)
				textBox.Text = e.Value.ToString();
			else if(type == typeof(ComplexStruct))
				FillStructControls((ComplexStruct)e.Value);        
		}

		private void FillStructControls(ComplexStruct structure)
		{
			tbComplexStruct_IntVal.Text = structure.intVal.ToString();
			tbComplexStruct_dintArr.Text = String.Format("{0:d}, {1:d}, {2:d}, {3:d}", structure.dintArr[0],
				structure.dintArr[1], structure.dintArr[2], structure.dintArr[3]);
			tbComplexStruct_boolVal.Text = structure.boolVal.ToString();
			tbComplexStruct_ByteVal.Text = structure.byteVal.ToString();
			tbComplexStruct_stringVal.Text = structure.stringVal;
			tbComplexStruct_SimpleStruct1_lrealVal.Text = structure.simpleStruct1.lrealVal.ToString();
			tbComplexStruct_SimpleStruct_dintVal.Text = structure.simpleStruct1.dintVal1.ToString();
		}

		private ComplexStruct GetStructFromControls()
		{
			ComplexStruct structure = new ComplexStruct();
			String[] stringArr = tbComplexStruct_dintArr.Text.Split(new char[] {','});
			structure.intVal = short.Parse(tbComplexStruct_IntVal.Text);
			for(int i=0; i<stringArr.Length; i++)
				structure.dintArr[i] = int.Parse(stringArr[i]);
        
			structure.boolVal = Boolean.Parse(tbComplexStruct_boolVal.Text);
			structure.byteVal = Byte.Parse(tbComplexStruct_ByteVal.Text);
			structure.stringVal = tbComplexStruct_stringVal.Text;
			structure.simpleStruct1.dintVal1 = int.Parse(tbComplexStruct_SimpleStruct_dintVal.Text);
			structure.simpleStruct1.lrealVal = double.Parse(tbComplexStruct_SimpleStruct1_lrealVal.Text);
			return structure;
		}		
	}

	[StructLayout(LayoutKind.Sequential, Pack=0)]
	public class SimpleStruct
	{
		public double lrealVal;
		public int dintVal1;
	}

	[StructLayout(LayoutKind.Sequential, Pack=0)]
	public class ComplexStruct
	{
		public short intVal;
		//specifies how .NET should marshal the array
		//SizeConst specifies the number of elements the array has.
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
		public int[] dintArr = new int[4];
		[MarshalAs(UnmanagedType.I1)]
		public bool boolVal;
		public byte byteVal;
		//specifies how .NET should marshal the string
		//SizeConst specifies the number of characters the string has.
		//'(inclusive the terminating null ). 
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=6)]
		public string stringVal = "";
		public SimpleStruct simpleStruct1 =new SimpleStruct();
	}
}
