using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

using C_Global;
using C_Event;

using Language;

namespace M_GM
{
	/// <summary>
	/// AccountList ��ժҪ˵����
	/// </summary>
	[C_Global.CModuleAttribute("GM�û�����", "AccountList", "����GM�û���Ϣ", "User Group")]
	public class AccountList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel3;
        private ImageTextControl.IMGTXTCTRL ITCNewUser;
        private ImageTextControl.IMGTXTCTRL ITCDelUser;
        private ImageTextControl.IMGTXTCTRL ITCEditUser;
        private ImageTextControl.IMGTXTCTRL ITC_Prev;
        private ImageTextControl.IMGTXTCTRL ITC_Next;
        private BackgroundWorker backgroundWorkerFormLoad;
        private BackgroundWorker backgroundWorkerDel;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ListView listViewAcoount;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private TabPage tabPage2;
        private ListView listViewAcoount2;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader20;
        private ColumnHeader columnHeader21;
        private ColumnHeader columnHeader22;
        private ColumnHeader columnHeader23;
        private ColumnHeader columnHeader24;
        private ColumnHeader id;
        private ColumnHeader realName;
        private ColumnHeader department;
        private ColumnHeader userName;
        private ColumnHeader userToDate;
        private ColumnHeader flag;
        private ColumnHeader onlineStatus;
        private ColumnHeader adminLevel;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AccountList()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//

		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountList));
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDel = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.realName = new System.Windows.Forms.ColumnHeader();
            this.department = new System.Windows.Forms.ColumnHeader();
            this.userName = new System.Windows.Forms.ColumnHeader();
            this.userToDate = new System.Windows.Forms.ColumnHeader();
            this.flag = new System.Windows.Forms.ColumnHeader();
            this.onlineStatus = new System.Windows.Forms.ColumnHeader();
            this.adminLevel = new System.Windows.Forms.ColumnHeader();
            this.listViewAcoount = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.listViewAcoount2 = new System.Windows.Forms.ListView();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
            this.ITC_Next = new ImageTextControl.IMGTXTCTRL();
            this.ITC_Prev = new ImageTextControl.IMGTXTCTRL();
            this.ITCDelUser = new ImageTextControl.IMGTXTCTRL();
            this.ITCEditUser = new ImageTextControl.IMGTXTCTRL();
            this.ITCNewUser = new ImageTextControl.IMGTXTCTRL();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItem1
            // 
            this.menuItem1.Index = -1;
            this.menuItem1.Text = "�½��û�";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = -1;
            this.menuItem2.Text = "ɾ���û�";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = -1;
            this.menuItem4.Text = "-";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = -1;
            this.menuItem5.Text = "��������";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = -1;
            this.menuItem6.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = -1;
            this.menuItem3.Text = "Ȩ�޹���";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = -1;
            this.menuItem7.Text = "-";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = -1;
            this.menuItem8.Text = "����";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.ITC_Next);
            this.dividerPanel1.Controls.Add(this.ITC_Prev);
            this.dividerPanel1.Controls.Add(this.ITCDelUser);
            this.dividerPanel1.Controls.Add(this.ITCEditUser);
            this.dividerPanel1.Controls.Add(this.ITCNewUser);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Margin = new System.Windows.Forms.Padding(20);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(695, 38);
            this.dividerPanel1.TabIndex = 7;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 48);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(695, 10);
            this.dividerPanel2.TabIndex = 9;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.dividerPanel3.Controls.Add(this.tabControl1);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 58);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.dividerPanel3.Size = new System.Drawing.Size(695, 375);
            this.dividerPanel3.TabIndex = 10;
            // 
            // backgroundWorkerFormLoad
            // 
            this.backgroundWorkerFormLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFormLoad_DoWork);
            this.backgroundWorkerFormLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFormLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerDel
            // 
            this.backgroundWorkerDel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDel_DoWork);
            this.backgroundWorkerDel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDel_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 371);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listViewAcoount);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(683, 346);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "δͣ���ʺ�";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listViewAcoount2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(577, 278);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "��ͣ���ʺ�";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.Text = "���";
            this.id.Width = 44;
            // 
            // realName
            // 
            this.realName.Text = "�û�����";
            this.realName.Width = 81;
            // 
            // department
            // 
            this.department.Text = "���ڲ���";
            this.department.Width = 113;
            // 
            // userName
            // 
            this.userName.Text = "�û���";
            this.userName.Width = 79;
            // 
            // userToDate
            // 
            this.userToDate.Text = "ʹ��ʱЧ";
            this.userToDate.Width = 125;
            // 
            // flag
            // 
            this.flag.Text = "�Ƿ����";
            this.flag.Width = 64;
            // 
            // onlineStatus
            // 
            this.onlineStatus.Text = "����״̬";
            // 
            // adminLevel
            // 
            this.adminLevel.Text = "����ȼ�";
            // 
            // listViewAcoount
            // 
            this.listViewAcoount.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewAcoount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewAcoount.ContextMenu = this.contextMenu1;
            this.listViewAcoount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAcoount.FullRowSelect = true;
            this.listViewAcoount.GridLines = true;
            this.listViewAcoount.Location = new System.Drawing.Point(3, 3);
            this.listViewAcoount.MultiSelect = false;
            this.listViewAcoount.Name = "listViewAcoount";
            this.listViewAcoount.Size = new System.Drawing.Size(677, 340);
            this.listViewAcoount.TabIndex = 5;
            this.listViewAcoount.UseCompatibleStateImageBehavior = false;
            this.listViewAcoount.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "���";
            this.columnHeader1.Width = 44;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "�û�����";
            this.columnHeader2.Width = 81;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "���ڲ���";
            this.columnHeader3.Width = 113;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "�û���";
            this.columnHeader4.Width = 79;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ʹ��ʱЧ";
            this.columnHeader5.Width = 125;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "�Ƿ����";
            this.columnHeader6.Width = 64;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "����״̬";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "����ȼ�";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "���";
            this.columnHeader9.Width = 44;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "�û�����";
            this.columnHeader10.Width = 81;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "���ڲ���";
            this.columnHeader11.Width = 113;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "�û���";
            this.columnHeader12.Width = 79;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "ʹ��ʱЧ";
            this.columnHeader13.Width = 125;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "�Ƿ����";
            this.columnHeader14.Width = 64;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "����״̬";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "����ȼ�";
            // 
            // listViewAcoount2
            // 
            this.listViewAcoount2.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewAcoount2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24});
            this.listViewAcoount2.ContextMenu = this.contextMenu1;
            this.listViewAcoount2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAcoount2.FullRowSelect = true;
            this.listViewAcoount2.GridLines = true;
            this.listViewAcoount2.Location = new System.Drawing.Point(3, 3);
            this.listViewAcoount2.MultiSelect = false;
            this.listViewAcoount2.Name = "listViewAcoount2";
            this.listViewAcoount2.Size = new System.Drawing.Size(571, 272);
            this.listViewAcoount2.TabIndex = 5;
            this.listViewAcoount2.UseCompatibleStateImageBehavior = false;
            this.listViewAcoount2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "���";
            this.columnHeader17.Width = 44;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "�û�����";
            this.columnHeader18.Width = 81;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "���ڲ���";
            this.columnHeader19.Width = 113;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "�û���";
            this.columnHeader20.Width = 79;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "ʹ��ʱЧ";
            this.columnHeader21.Width = 125;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "�Ƿ����";
            this.columnHeader22.Width = 64;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "����״̬";
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "����ȼ�";
            // 
            // ITC_Next
            // 
            this.ITC_Next.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_Next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_Next.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITC_Next.IMG_SRC")));
            this.ITC_Next.ITXT_ForeColor = System.Drawing.Color.Blue;
            this.ITC_Next.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_Next.ITXT_TEXT = "��һҳ";
            this.ITC_Next.Location = new System.Drawing.Point(359, 10);
            this.ITC_Next.Name = "ITC_Next";
            this.ITC_Next.Size = new System.Drawing.Size(66, 20);
            this.ITC_Next.TabIndex = 11;
            this.ITC_Next.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_Next_ITC_CLICIK);
            // 
            // ITC_Prev
            // 
            this.ITC_Prev.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_Prev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_Prev.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITC_Prev.IMG_SRC")));
            this.ITC_Prev.ITXT_ForeColor = System.Drawing.Color.Blue;
            this.ITC_Prev.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_Prev.ITXT_TEXT = "��һҳ";
            this.ITC_Prev.Location = new System.Drawing.Point(287, 10);
            this.ITC_Prev.Name = "ITC_Prev";
            this.ITC_Prev.Size = new System.Drawing.Size(66, 20);
            this.ITC_Prev.TabIndex = 10;
            this.ITC_Prev.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_Prev_ITC_CLICIK);
            // 
            // ITCDelUser
            // 
            this.ITCDelUser.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITCDelUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITCDelUser.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITCDelUser.IMG_SRC")));
            this.ITCDelUser.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITCDelUser.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITCDelUser.ITXT_TEXT = "ɾ���ʺ�";
            this.ITCDelUser.Location = new System.Drawing.Point(176, 10);
            this.ITCDelUser.Name = "ITCDelUser";
            this.ITCDelUser.Size = new System.Drawing.Size(76, 18);
            this.ITCDelUser.TabIndex = 9;
            this.ITCDelUser.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITCDelUser_ITC_CLICIK);
            // 
            // ITCEditUser
            // 
            this.ITCEditUser.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITCEditUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITCEditUser.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITCEditUser.IMG_SRC")));
            this.ITCEditUser.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITCEditUser.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITCEditUser.ITXT_TEXT = "�༭�ʺ�";
            this.ITCEditUser.Location = new System.Drawing.Point(94, 10);
            this.ITCEditUser.Name = "ITCEditUser";
            this.ITCEditUser.Size = new System.Drawing.Size(76, 18);
            this.ITCEditUser.TabIndex = 8;
            this.ITCEditUser.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITCEditUser_ITC_CLICIK);
            // 
            // ITCNewUser
            // 
            this.ITCNewUser.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITCNewUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITCNewUser.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITCNewUser.IMG_SRC")));
            this.ITCNewUser.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITCNewUser.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITCNewUser.ITXT_TEXT = "�����ʺ�";
            this.ITCNewUser.Location = new System.Drawing.Point(12, 10);
            this.ITCNewUser.Name = "ITCNewUser";
            this.ITCNewUser.Size = new System.Drawing.Size(76, 18);
            this.ITCNewUser.TabIndex = 7;
            this.ITCNewUser.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITCNewUser_ITC_CLICIK);
            // 
            // AccountList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(715, 443);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AccountList";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "�û��б�";
            this.Closed += new System.EventHandler(this.AccountList_Closed);
            this.Load += new System.EventHandler(this.AccountList_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region ���ú���
		/// <summary>
		/// ��������еĴ���
		/// </summary>
		/// <param name="oParent">MDI ����ĸ�����</param>
		/// <param name="oSocket">Socket</param>
		/// <returns>����еĴ���</returns>
		public Form CreateModule(object oParent, object oEvent)
		{

               //((Form)oParent).Controls[1].Controls[0].Text = "���";
                
                /*
                for (int i = 0; i < ((Form)oParent).Controls.Count; i++)
                {
                    
                    if (((Form)oParent).Controls[i].GetType().Name == "DividerPanel")
                    {
                        Label mm = (Label)((Form)oParent).Controls[i];
                        if (mm.Name == "lblStatus")
                        {
                            mm.Text = "��ɣ�";
                        }
                        
                    }
                }
                */
                //oParent.GetType().
                //oParent.GetType().GetProperties().SetValue("ok", 0);
               

                this.m_ClientEvent = (CSocketEvent)oEvent;
                

                if (oParent != null)
                {
                    _parent = (Form)oParent;
                    this.MdiParent = (Form)oParent;
                    this.Show();
                }
                else
                {
                    this.ShowDialog();
                }

                return this;
            

			
			
		}



		#endregion

		#region ����
		private CSocketEvent m_ClientEvent = null;
		private C_Global.CEnum.Message_Body[,] mResult = null;		//�б���Ϣ

        private Form _parent = null;

        private int pageIndex = 1;  //���͸��������Ŀ�ʼ����
        private int pageSize = 30;   //ÿҳ��ʾ����
        private int pageCount = 1;  //��ҳ��
        private int currPage = 0;   //��ǰҳ��
		#endregion

		#region �Զ��庯��
		/// <summary>
		/// ��ʼ���б�
		/// </summary>
		public void InitializeListView()
		{
			try
			{
				listViewAcoount.Items.Clear();
				
                //��ʽ��Ϣ
				C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

				messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[0].eName = C_Global.CEnum.TagName.Index;
				messageBody[0].oContent = pageIndex;

				messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[1].eName = C_Global.CEnum.TagName.PageSize;
				messageBody[1].oContent = pageSize;

                this.backgroundWorkerFormLoad.RunWorkerAsync(messageBody);

                //mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_QUERY, C_Global.CEnum.Msg_Category.USER_ADMIN, messageBody);
				
                ////���״̬
                //if (mResult[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(mResult[0,0].oContent.ToString());
                //    return;
                //}

                ////��ҳ��
                //pageCount = int.Parse(mResult[0, 9].oContent.ToString());

                ////��ʾ���ݵ��б�
                //string[] rowInfo = new string[8];
                //for (int i=0; i<mResult.GetLength(0); i++)
                //{
                //    //�б��
                //    rowInfo[0] = Convert.ToString(i+1);
                //    //����	
                //    rowInfo[1] = mResult[i,5].oContent.ToString();
                //    //���ڲ���
                //    rowInfo[2] = mResult[i,7].oContent.ToString();
                //    //�û���
                //    rowInfo[3] = mResult[i,1].oContent.ToString();
                //    //MAC
                //    //rowInfo[4] = mResult[i,3].oContent.ToString();
                //    //ʹ��ʱЧ
                //    rowInfo[4] = mResult[i,4].oContent.ToString();
                //    //�Ƿ����
                //    rowInfo[5] = int.Parse(mResult[i, 8].oContent.ToString()) == 1 ? config.ReadConfigValue("MGM", "AL_Code_Yes") : config.ReadConfigValue("MGM", "AL_Code_No");
                //    //����״̬
                //    rowInfo[6] = int.Parse(mResult[i, 10].oContent.ToString()) == 1 ? config.ReadConfigValue("MGM", "AL_Code_Online") : config.ReadConfigValue("MGM", "AL_Code_Offline");
                //    //��Ա����
                //    rowInfo[7] = int.Parse(mResult[i, 11].oContent.ToString()) == 1 ? config.ReadConfigValue("MGM", "AL_Code_SysAdmin") : (int.Parse(mResult[i, 11].oContent.ToString()) == 2 ? config.ReadConfigValue("MGM", "AL_Code_DepartAdmin") : "");
                //    ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
                //    listViewAcoount.Items.Add(mlistViewItem);
                //    listViewAcoount.Items[i].Tag = mResult[i,0].oContent.ToString();				
                //}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		#endregion		

		#region �¼�����

		/// <summary>
		/// ���봰��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AccountList_Load(object sender, System.EventArgs e)
		{
            IntiFontLib();

			InitializeListView();
            //Status.WriteStatusText(this._parent, config.ReadConfigValue("MGM", "AL_Code_Finish"));
		}

		/// <summary>
		/// ����û�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem1_Click(object sender, System.EventArgs e)
		{
            this.AddUser();
		}

		/// <summary>
		/// ɾ���û�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem2_Click(object sender, System.EventArgs e)
		{
            this.DelUser();
		}

		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			try
			{	
				//Ҫ����������û�������
				int selectIndex = this.listViewAcoount.SelectedItems[0].Index;
				//Ҫ����������û�id
				int userID = int.Parse(this.listViewAcoount.Items[selectIndex].Tag.ToString());
				//�û�����
				string password = null;
				for(int i=0;i<mResult.GetLength(0);i++)
				{
					if(int.Parse(mResult[i,0].oContent.ToString()) == userID)
					{
						password = mResult[i,2].oContent.ToString().Trim();
					}
				}
				//���봰��
				ModiUserPwd modiPwd = new ModiUserPwd(userID,password);
				modiPwd.CreateModule(null,m_ClientEvent);
				InitializeListView();
			}
			catch(Exception ex)
			{
				//MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// Ȩ�޹���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			try
			{	
				//Ҫ����Ȩ�޵��û�������
				int selectIndex = this.listViewAcoount.SelectedItems[0].Index;
				//Ҫ����Ȩ�޵��û�id
				int userID = int.Parse(this.listViewAcoount.Items[selectIndex].Tag.ToString());
                int gmType = int.Parse(mResult[selectIndex,11].oContent.ToString());
				//���봰��
                ModiRole modiRole = new ModiRole(userID, gmType);
				modiRole.CreateModule(null,m_ClientEvent);
				InitializeListView();
			}
			catch(Exception ex)
			{
				//MessageBox.Show(ex.Message);
			}
			
		}


		/// <summary>
		/// ����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem8_Click(object sender, System.EventArgs e)
		{
            this.EditUser();
		}

		/// <summary>
		/// �رմ���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AccountList_Closed(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// ����Ҽ�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listViewAcoount_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//�Ҽ����
			if(e.Button == MouseButtons.Right && e.Clicks == 1)
			{
				//����Ҽ�����
				this.contextMenu1.MenuItems.Clear();
				try
				{
					int selectIndex = this.listViewAcoount.GetItemAt(e.X,e.Y).Index;
					this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								 this.menuItem1,
																								 this.menuItem2,
																								 this.menuItem4,
																								 this.menuItem5,
																								 this.menuItem6,
																								 this.menuItem3,
																								 this.menuItem7,
																								 this.menuItem8});
				}
				catch
				{
						
					this.contextMenu1.MenuItems.Add(this.menuItem1);
				}
			}
		}



        /// <summary>
        /// �����ʺ�
        /// </summary>
        /// <param name="sender"></param>
        private void ITCNewUser_ITC_CLICIK(object sender)
        {
            this.AddUser();
        }

        /// <summary>
        /// �༭�ʺ�
        /// </summary>
        /// <param name="sender"></param>
        private void ITCEditUser_ITC_CLICIK(object sender)
        {
            this.EditUser();
        }

        /// <summary>
        /// ɾ���ʺ�
        /// </summary>
        /// <param name="sender"></param>
        private void ITCDelUser_ITC_CLICIK(object sender)
        {
            this.DelUser();
        }

        /// <summary>
        /// ��һҳ
        /// </summary>
        /// <param name="sender"></param>
        private void ITC_Next_ITC_CLICIK(object sender)
        {
            if (currPage < pageCount - 1)
            {
                currPage += 1;
                pageIndex = currPage * pageSize + 1;
                this.InitializeListView();
            }
        }

        /// <summary>
        /// ��һҳ
        /// </summary>
        /// <param name="sender"></param>
        private void ITC_Prev_ITC_CLICIK(object sender)
        {
            if (currPage > 0)
            {
                currPage -= 1;
                pageIndex = currPage * pageSize + 1;
                this.InitializeListView();
            }
        }

		#endregion

        #region �¼�����
        /// <summary>
        /// �����ʺ�
        /// </summary>
        private void AddUser()
        {
            NewUser newUser = new NewUser(mResult);
            newUser.CreateModule(null, m_ClientEvent);
            InitializeListView();
        }

        /// <summary>
        /// �༭�ʺ�
        /// </summary>
        private void EditUser()
        {
            int selectIndex = 0;
            try
            {
                //Ҫ����������û�������
                selectIndex = this.listViewAcoount.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "AL_Code_ChooseAccount"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                int userID ;
                if(tabControl1.TabIndex==0)
                //Ҫ�������Ե��û�id
                userID= int.Parse(this.listViewAcoount.Items[selectIndex].Tag.ToString());
                else
                userID = int.Parse(this.listViewAcoount2.Items[selectIndex].Tag.ToString());
                //���͵����Դ�����û���Ϣ
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[8];


                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    if (int.Parse(mResult[i, 0].oContent.ToString()) == userID)
                    {
                        messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                        messageBody[0].eName = C_Global.CEnum.TagName.User_ID;
                        messageBody[0].oContent = userID;

                        messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                        messageBody[1].eName = C_Global.CEnum.TagName.UserName;
                        messageBody[1].oContent = mResult[i, 1].oContent.ToString().Trim();

                        messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                        messageBody[2].eName = C_Global.CEnum.TagName.Limit;
                        messageBody[2].oContent = Convert.ToDateTime(mResult[i, 4].oContent);

                        messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                        messageBody[3].eName = C_Global.CEnum.TagName.Status;
                        messageBody[3].oContent = int.Parse(mResult[i, 8].oContent.ToString());

                        messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                        messageBody[4].eName = C_Global.CEnum.TagName.RealName;
                        messageBody[4].oContent = mResult[i, 5].oContent.ToString().Trim();

                        messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                        messageBody[5].eName = C_Global.CEnum.TagName.DepartID;
                        messageBody[5].oContent = int.Parse(mResult[i, 6].oContent.ToString().Trim());

                        messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                        messageBody[6].eName = C_Global.CEnum.TagName.OnlineActive;
                        messageBody[6].oContent = int.Parse(mResult[i, 10].oContent.ToString().Trim());

                        messageBody[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                        messageBody[7].eName = C_Global.CEnum.TagName.SysAdmin;
                        messageBody[7].oContent = int.Parse(mResult[i, 11].oContent.ToString().Trim());


                        ModiUserAttribute modiAttrib = null;
                        modiAttrib = new ModiUserAttribute(userID, messageBody);
                        modiAttrib.CreateModule(null, m_ClientEvent);
                        InitializeListView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ɾ���ʻ�
        /// </summary>
        private void DelUser()
        {
            int selectIndex = 0;

            try
            {
                //Ҫ����������û�������
                selectIndex = this.listViewAcoount.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "AL_Code_ChooseAccount"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                if (MessageBox.Show(config.ReadConfigValue("MGM", "AL_Code_SureToDelUser"), "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }

                //Ҫɾ�����û�id
                int userID = int.Parse(this.listViewAcoount.Items[selectIndex].Tag.ToString());
                //ִ�в����ķ��ؽ��
                C_Global.CEnum.Message_Body[,] resultMsgBody = null;
                //���͵���Ϣ
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.User_ID;
                messageBody[1].oContent = userID;

                this.backgroundWorkerDel.RunWorkerAsync(messageBody);

                //resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_DELETE, C_Global.CEnum.Msg_Category.USER_ADMIN, messageBody);
                //try
                //{
                //    int iSrvCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());
                //    for (int iSrvIndex = 1; iSrvIndex <= iSrvCount; iSrvIndex++)
                //    {
                //        ((CSocketEvent)m_ClientEvent.GetInfo("Server" + iSrvIndex)).RequestResult(C_Global.CEnum.ServiceKey.USER_DELETE, C_Global.CEnum.Msg_Category.USER_ADMIN, messageBody);
                //    }
                //}
                //catch { }
                
                ////���״̬
                //if (resultMsgBody[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(resultMsgBody[0, 0].oContent.ToString());
                //    //Application.Exit();
                //    return;
                //}
                //if (resultMsgBody[0, 0].oContent.ToString().Trim().ToUpper().Equals("SUCESS"))
                //{
                //    //this.listViewAcoount.Items[selectIndex].Remove();
                //    MessageBox.Show(config.ReadConfigValue("MGM", "AL_Code_Succeed"));
                //}
                //InitializeListView();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region ���Կ�
        /// <summary>
        ///�����ֿ�
        /// </summary>
        ConfigValue config = null;

        /// <summary>
        /// ��ʼ�����������Կ�
        /// </summary>
        private void IntiFontLib()
        {
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            IntiUI();
        }

        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MGM", "AL_UI_Caption");
            this.ITCNewUser.ITXT_TEXT = config.ReadConfigValue("MGM", "AL_UI_ITCNewUser");
            this.ITCEditUser.ITXT_TEXT = config.ReadConfigValue("MGM", "AL_UI_ITCEditUser");
            this.ITCDelUser.ITXT_TEXT = config.ReadConfigValue("MGM", "AL_UI_ITCDelUser");
            this.ITC_Prev.ITXT_TEXT = config.ReadConfigValue("MGM", "AL_UI_ITCPrevPage");
            this.ITC_Next.ITXT_TEXT = config.ReadConfigValue("MGM", "AL_UI_ITCNextPage");
            this.id.Text = config.ReadConfigValue("MGM", "AL_UI_DG_ID");
            this.realName.Text = config.ReadConfigValue("MGM", "AL_UI_DG_RealName");
            this.department.Text = config.ReadConfigValue("MGM", "AL_UI_DG_Department");
            this.userName.Text = config.ReadConfigValue("MGM", "AL_UI_DG_Account");
            this.userToDate.Text = config.ReadConfigValue("MGM", "AL_UI_DG_TimeLimit");
            this.flag.Text = config.ReadConfigValue("MGM", "AL_UI_DG_IsEnabled");
            this.onlineStatus.Text = config.ReadConfigValue("MGM", "AL_UI_DG_Online");
            this.adminLevel.Text = config.ReadConfigValue("MGM", "AL_UI_DG_Level");

            this.menuItem1.Text = config.ReadConfigValue("MGM", "AL_UI_ITCNewUser");
            this.menuItem2.Text = config.ReadConfigValue("MGM", "AL_UI_ITCDelUser");
            this.menuItem5.Text = config.ReadConfigValue("MGM", "AL_UI_Menu_ChangePwd");
            this.menuItem3.Text = config.ReadConfigValue("MGM", "AL_UI_Menu_Power");
            this.menuItem8.Text = config.ReadConfigValue("MGM", "AL_UI_ITCEditUser");

        }


        #endregion

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_QUERY, C_Global.CEnum.Msg_Category.USER_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //���״̬
            if (mResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            //��ҳ��
            pageCount = int.Parse(mResult[0, 9].oContent.ToString());
            int j=0;
            int z=0;
            //��ʾ���ݵ��б�
            string[] rowInfo = new string[8];
            try
            {
                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                   
                    if (int.Parse(mResult[i, 8].oContent.ToString()) == 1)
                    {
                        
                        //�б��
                        rowInfo[0] = Convert.ToString(i + 1);
                        //����	
                        rowInfo[1] = mResult[i, 5].oContent.ToString();
                        //���ڲ���
                        rowInfo[2] = mResult[i, 7].oContent.ToString();
                        //�û���
                        rowInfo[3] = mResult[i, 1].oContent.ToString();
                        //MAC
                        //rowInfo[4] = mResult[i,3].oContent.ToString();
                        //ʹ��ʱЧ
                        rowInfo[4] = mResult[i, 4].oContent.ToString();
                        //�Ƿ����
                        rowInfo[5] = int.Parse(mResult[i, 8].oContent.ToString()) == 1 ? config.ReadConfigValue("MGM", "AL_Code_Yes") : config.ReadConfigValue("MGM", "AL_Code_No");
                        //����״̬
                        rowInfo[6] = int.Parse(mResult[i, 10].oContent.ToString()) == 1 ? config.ReadConfigValue("MGM", "AL_Code_Online") : config.ReadConfigValue("MGM", "AL_Code_Offline");
                        //��Ա����
                        rowInfo[7] = int.Parse(mResult[i, 11].oContent.ToString()) == 1 ? config.ReadConfigValue("MGM", "AL_Code_SysAdmin") : (int.Parse(mResult[i, 11].oContent.ToString()) == 2 ? config.ReadConfigValue("MGM", "AL_Code_DepartAdmin") : "");
                        ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
                        listViewAcoount.Items.Add(mlistViewItem);
                        listViewAcoount.Items[j].Tag =mResult[i,0].oContent.ToString();
                        j++;
                    }
                    else
                    {
                        
                        //�б��
                        rowInfo[0] = Convert.ToString(i + 1);
                        //����	
                        rowInfo[1] = mResult[i, 5].oContent.ToString();
                        //���ڲ���
                        rowInfo[2] = mResult[i, 7].oContent.ToString();
                        //�û���
                        rowInfo[3] = mResult[i, 1].oContent.ToString();
                        //MAC
                        //rowInfo[4] = mResult[i,3].oContent.ToString();
                        //ʹ��ʱЧ
                        rowInfo[4] = mResult[i, 4].oContent.ToString();
                        //�Ƿ����
                        rowInfo[5] = int.Parse(mResult[i, 8].oContent.ToString()) == 1 ? config.ReadConfigValue("MGM", "AL_Code_Yes") : config.ReadConfigValue("MGM", "AL_Code_No");
                        //����״̬
                        rowInfo[6] = int.Parse(mResult[i, 10].oContent.ToString()) == 1 ? config.ReadConfigValue("MGM", "AL_Code_Online") : config.ReadConfigValue("MGM", "AL_Code_Offline");
                        //��Ա����
                        rowInfo[7] = int.Parse(mResult[i, 11].oContent.ToString()) == 1 ? config.ReadConfigValue("MGM", "AL_Code_SysAdmin") : (int.Parse(mResult[i, 11].oContent.ToString()) == 2 ? config.ReadConfigValue("MGM", "AL_Code_DepartAdmin") : "");
                        ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
                        listViewAcoount2.Items.Add(mlistViewItem);
                        listViewAcoount2.Items[z].Tag = mResult[i, 0].oContent.ToString();
                        z++;

                    }



                    Status.WriteStatusText(this._parent, config.ReadConfigValue("MGM", "AL_Code_Finish"));
                }
            }
            catch (Exception ex)
            { }
        }

        private void backgroundWorkerDel_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_DELETE, C_Global.CEnum.Msg_Category.USER_ADMIN, (CEnum.Message_Body[])e.Argument);
                try
                {
                    int iSrvCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());
                    for (int iSrvIndex = 1; iSrvIndex <= iSrvCount; iSrvIndex++)
                    {
                        ((CSocketEvent)m_ClientEvent.GetInfo("Server" + iSrvIndex)).RequestResult(C_Global.CEnum.ServiceKey.USER_DELETE, C_Global.CEnum.Msg_Category.USER_ADMIN, (CEnum.Message_Body[])e.Argument);
                    }
                }
                catch { }
            }
        }

        private void backgroundWorkerDel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] resultMsgBody = (CEnum.Message_Body[,])e.Result;
            //���״̬
            if (resultMsgBody[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(resultMsgBody[0, 0].oContent.ToString());
                //Application.Exit();
                return;
            }
            if (resultMsgBody[0, 0].oContent.ToString().Trim().ToUpper().Equals("SUCESS"))
            {
                //this.listViewAcoount.Items[selectIndex].Remove();
                MessageBox.Show(config.ReadConfigValue("MGM", "AL_Code_Succeed"));
            }
            InitializeListView();
        }

        







    }
}
