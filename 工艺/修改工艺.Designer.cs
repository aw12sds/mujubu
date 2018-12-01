﻿namespace mujubu.工艺
{
    partial class 修改工艺
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.零件id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.工序名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.工序内容 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.操作人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.工序开始时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.实际完成时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.实际操作人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.加工数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.顺序 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "工具";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4)});
            this.bar1.Text = "工具";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "新增";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "删除";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "修改工序内容和数量";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "生成一本通";
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "主菜单";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "主菜单";
            // 
            // bar3
            // 
            this.bar3.BarName = "状态栏";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "状态栏";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(618, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 462);
            this.barDockControlBottom.Size = new System.Drawing.Size(618, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 411);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(618, 51);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 411);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "提交金额";
            this.barButtonItem5.Id = 4;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 51);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(618, 411);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id1,
            this.零件id,
            this.工序名称,
            this.工序内容,
            this.操作人,
            this.工序开始时间,
            this.实际完成时间,
            this.实际操作人,
            this.加工数量,
            this.金额,
            this.顺序});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // id1
            // 
            this.id1.Caption = "id";
            this.id1.FieldName = "id";
            this.id1.Name = "id1";
            // 
            // 零件id
            // 
            this.零件id.Caption = "零件id";
            this.零件id.FieldName = "零件id";
            this.零件id.Name = "零件id";
            // 
            // 工序名称
            // 
            this.工序名称.Caption = "工序名称";
            this.工序名称.FieldName = "工序名称";
            this.工序名称.Name = "工序名称";
            this.工序名称.Visible = true;
            this.工序名称.VisibleIndex = 0;
            this.工序名称.Width = 106;
            // 
            // 工序内容
            // 
            this.工序内容.Caption = "工序内容";
            this.工序内容.FieldName = "工序内容";
            this.工序内容.Name = "工序内容";
            this.工序内容.Visible = true;
            this.工序内容.VisibleIndex = 1;
            this.工序内容.Width = 146;
            // 
            // 操作人
            // 
            this.操作人.Caption = "操作人";
            this.操作人.FieldName = "操作人";
            this.操作人.Name = "操作人";
            // 
            // 工序开始时间
            // 
            this.工序开始时间.Caption = "工序开始时间";
            this.工序开始时间.FieldName = "工序开始时间";
            this.工序开始时间.Name = "工序开始时间";
            // 
            // 实际完成时间
            // 
            this.实际完成时间.Caption = "实际完成时间";
            this.实际完成时间.FieldName = "实际完成时间";
            this.实际完成时间.Name = "实际完成时间";
            // 
            // 实际操作人
            // 
            this.实际操作人.Caption = "实际操作人";
            this.实际操作人.FieldName = "实际操作人";
            this.实际操作人.Name = "实际操作人";
            // 
            // 加工数量
            // 
            this.加工数量.Caption = "加工数量";
            this.加工数量.FieldName = "加工数量";
            this.加工数量.Name = "加工数量";
            this.加工数量.Visible = true;
            this.加工数量.VisibleIndex = 2;
            this.加工数量.Width = 60;
            // 
            // 金额
            // 
            this.金额.Caption = "金额";
            this.金额.FieldName = "金额单价";
            this.金额.Name = "金额";
            this.金额.Visible = true;
            this.金额.VisibleIndex = 3;
            this.金额.Width = 51;
            // 
            // 顺序
            // 
            this.顺序.Caption = "顺序";
            this.顺序.FieldName = "顺序";
            this.顺序.Name = "顺序";
            this.顺序.Visible = true;
            this.顺序.VisibleIndex = 4;
            this.顺序.Width = 237;
            // 
            // 修改工艺
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 485);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "修改工艺";
            this.Text = "修改工艺";
            this.Load += new System.EventHandler(this.修改工艺_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn id1;
        private DevExpress.XtraGrid.Columns.GridColumn 零件id;
        private DevExpress.XtraGrid.Columns.GridColumn 工序名称;
        private DevExpress.XtraGrid.Columns.GridColumn 工序内容;
        private DevExpress.XtraGrid.Columns.GridColumn 操作人;
        private DevExpress.XtraGrid.Columns.GridColumn 工序开始时间;
        private DevExpress.XtraGrid.Columns.GridColumn 实际完成时间;
        private DevExpress.XtraGrid.Columns.GridColumn 实际操作人;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraGrid.Columns.GridColumn 加工数量;
        private DevExpress.XtraGrid.Columns.GridColumn 金额;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraGrid.Columns.GridColumn 顺序;
    }
}