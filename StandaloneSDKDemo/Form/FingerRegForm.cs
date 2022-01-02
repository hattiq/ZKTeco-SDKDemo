﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace StandaloneSDKDemo
{
    public partial class FingerRegForm : Form
    {
        public FingerRegForm(Main Parent)
        {
            InitializeComponent();
            UserMng = Parent;
        }
        private Main UserMng;

        #region UserInfo

        private void btnDeleteEnrollData_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_DeleteEnrollData(UserMng.lbSysOutputInfo, cbUserID2, cbBackupDE);

            Cursor = Cursors.Default;
        }

        private void btnDelUserTmp_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_DelUserTmp(UserMng.lbSysOutputInfo, cbUserID3, cbFingerIndex1);

            Cursor = Cursors.Default;
        }

        private void btnSetUserInfo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_SetUserInfo(UserMng.lbSysOutputInfo, txtUserID, txtName, cbPrivilege, txtCardnumber, txtPassword);

            Cursor = Cursors.Default;
        }

        private void btnStartEnroll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_OnlineEnroll(UserMng.lbSysOutputInfo, txtUserID1, cbFingerIndex, cbFlag);

            Cursor = Cursors.Default;
        }

        private void btnGetHIDEventCardNumAsStr_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_GetHIDEventCardNum(UserMng.lbSysOutputInfo);

            Cursor = Cursors.Default;
        }

        private void btnSetVD_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_SetUserValidDate(UserMng.lbSysOutputInfo, cbExpires, cbUserID6, dtStartDate, dtEndDate, txtCount);

            Cursor = Cursors.Default;
        }

        private void btnGetVD_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_GetUserValidDate(UserMng.lbSysOutputInfo, cbExpires, cbUserID6, dtStartDate, dtEndDate, txtCount);

            Cursor = Cursors.Default;
        }

        private void btGetUserVerifyStyle_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_GetUserVerifyStyle(UserMng.lbSysOutputInfo, cbUserID7, cbVerifyStyle);

            Cursor = Cursors.Default;
        }

        private void btSetUserVerifyStyl_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_SetUserVerifyStyle(UserMng.lbSysOutputInfo, cbUserID7, cbVerifyStyle);

            Cursor = Cursors.Default;
        }

        private void tmUserID_Tick(object sender, EventArgs e)
        {
            UserMng.SDK.sta_GetAllUserID(false, cbUserID, cbUserID1, cbUserID2, cbUserID3, cbUserID4, cbUserID6, cbUserID7);
        }

        private void RefreshUserIDMenuItem_Click(object sender, EventArgs e)
        {
            UserMng.SDK.sta_GetAllUserID(true, cbUserID, cbUserID1, cbUserID2, cbUserID3, cbUserID4, cbUserID6, cbUserID7);

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCardnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            //int index = 0;
            //foreach (char ch in ((TextBox)sender).Text)
            //{
            //    if (char.IsDigit(ch) || char.IsLetter(ch))
            //    {
            //        index++;
            //    }
            //    else
            //    {
            //        txtUserID.Text = ((TextBox)sender).Text.Remove(index);
            //        break;
            //    }
            //}
            //txtUserID.SelectionStart = txtUserID.TextLength; 
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
            //if (Char.IsDigit(e.KeyChar) || e.KeyChar == ' ' || char.IsLetter(e.KeyChar) || e.KeyChar == '\b')
            //{
            //    e.Handled = false;
            //}
        }

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUserID1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }


        private void txtUserID1_TextChanged(object sender, EventArgs e)
        {
            //int index = 0;
            //foreach (char ch in ((TextBox)sender).Text)
            //{
            //    if (char.IsDigit(ch) || char.IsLetter(ch))
            //    {
            //        index++;
            //    }
            //    else
            //    {
            //        txtUserID1.Text = ((TextBox)sender).Text.Remove(index);
            //        break;
            //    }
            //}
            //txtUserID1.SelectionStart = txtUserID1.TextLength; 
        }

        #endregion

        #region UserFP
        private void btnGetAllUserFPInfo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            int ret = UserMng.SDK.sta_GetAllUserFPInfo(UserMng.lbSysOutputInfo, UserMng.PrgSTA, lvUserInfo);

            Cursor = Cursors.Default;
        }

        private void btnSetAllUserFPInfo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (cbBatchUpload.Checked)
            {
                UserMng.SDK.sta_batch_SetAllUserFPInfo(UserMng.lbSysOutputInfo, UserMng.PrgSTA, lvUserInfo);
            }
            else
            {
                UserMng.SDK.sta_SetAllUserFPInfo(UserMng.lbSysOutputInfo, UserMng.PrgSTA, lvUserInfo);
            }

            Cursor = Cursors.Default;
        }
        #endregion

        #region UserFace
        private void btnGetAllUserFaceInfo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            int ret = UserMng.SDK.sta_GetAllUserFaceInfo(UserMng.lbSysOutputInfo, UserMng.PrgSTA, listUserInfo);

            Cursor = Cursors.Default;
        }

        private void btnSetAllUserFaceInfo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            int ret = UserMng.SDK.sta_SetAllUserFaceInfo(UserMng.lbSysOutputInfo, UserMng.PrgSTA, listUserInfo);

            Cursor = Cursors.Default;
        }
        #endregion

        #region UserPhoto
        private void btnGetAllUserPhoto_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_DownloadAllUserPhoto(UserMng.lbSysOutputInfo, txtAllPhotoPath);

            Cursor = Cursors.Default;
        }


        private void btnUploadAllUserPhoto_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_UploadAllUserPhoto(UserMng.lbSysOutputInfo, txtAllPhotoPath);

            Cursor = Cursors.Default;
        }

        private void btnUploadOneUserPhoto_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (tbGetPhotoPath.Text.Trim() == "")
            {
                UserMng.lbSysOutputInfo.Items.Add("*Select photo first");
                Cursor = Cursors.Default;
                return;
            }

            if (cbUserID4.Text.Trim() == "")
            {
                UserMng.lbSysOutputInfo.Items.Add("*Select User ID first");
                Cursor = Cursors.Default;
                return;
            }

            string fullName = this.tbGetPhotoPath.Text.Trim() + this.cbUserID4.Text.Trim() + ".jpg";
            if (getUserPhotoByID(fullName))
            {
                this.pictureBox2.Image = GetImageFile(fullName);
            }
            else
            {
                UserMng.lbSysOutputInfo.Items.Add("*User ID " + this.cbUserID4.Text.Trim() + " has no photo in this folder.");
                Cursor = Cursors.Default;
                return;
            }

            UserMng.SDK.sta_uploadOneUserPhoto(UserMng.lbSysOutputInfo, fullName);

            Cursor = Cursors.Default;
        }

        private void btnDownloadOneUserPhoto_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_downloadOneUserPhoto(UserMng.lbSysOutputInfo, this.cbUserID4.Text.Trim(), this.tbGetPhotoPath.Text.Trim());

            Cursor = Cursors.Default;
        }

        private void btnDeleteOneUserPhoto_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_DeleteOneUserPhoto(UserMng.lbSysOutputInfo, this.cbUserID4.Text.Trim());

            Cursor = Cursors.Default;
        }

        private void btnPhotopath1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (DialogResult.OK == fbd.ShowDialog())
            {
                txtAllPhotoPath.Text = fbd.SelectedPath;

                if (!fbd.SelectedPath.EndsWith("\\"))
                {
                    txtAllPhotoPath.Text += "\\";
                }

            }
        }

        private void btnPhotopath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (DialogResult.OK == fbd.ShowDialog())
            {
                tbGetPhotoPath.Text = fbd.SelectedPath;

                if (!fbd.SelectedPath.EndsWith("\\"))
                {
                    tbGetPhotoPath.Text += "\\";
                }
            }
        }

        private MemoryStream ReadFile(string path)
        {
            if (!File.Exists(path))
                return null;

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                byte[] b = new byte[file.Length];
                file.Read(b, 0, b.Length);

                MemoryStream stream = new MemoryStream(b);
                return stream;
            }
        }

        private Image GetImageFile(string path)
        {
            MemoryStream stream = ReadFile(path);
            return stream == null ? null : Image.FromStream(stream);
        }

        private bool getUserPhotoByID(string photoName)
        {
            DirectoryInfo directory = new DirectoryInfo(this.tbGetPhotoPath.Text.Trim());

            if (directory.Exists)
            {
                foreach (FileInfo info in directory.GetFiles())
                {
                    if (info.FullName.ToString() == photoName)
                        return true;
                }
            }

            return false;
        }

        private void cbUserID4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tbGetPhotoPath.Text.Trim() == "" || this.cbUserID4.Text.Trim() == "")
            {
                return;
            }

            string fullName = this.tbGetPhotoPath.Text.Trim() + this.cbUserID4.Text.Trim() + ".jpg";
            if (getUserPhotoByID(fullName))
            {
                this.pictureBox2.Image = GetImageFile(fullName);
            }
            else
            {
                this.pictureBox2.Image = null;
            }
        }
        #endregion

        #region SMS
        private void btnSetSMS_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_SetSMS(UserMng.lbSysOutputInfo, txtSMSID, cbTag, txtValidMins, dtStartTime, txtContent);

            Cursor = Cursors.Default;
        }

        private void btnGetSMS_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_GetSMS(UserMng.lbSysOutputInfo, txtSMSID, cbTag, txtValidMins, dtStartTime, txtContent);

            Cursor = Cursors.Default;
        }

        private void btnSetUserSMS_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_SetUserSMS(UserMng.lbSysOutputInfo, txtSMSID1, cbUserID);

            Cursor = Cursors.Default;
        }

        private void btnDeleteSMS_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_DelSMS(UserMng.lbSysOutputInfo, txtSMSID2);

            Cursor = Cursors.Default;
        }

        private void btnDeleteUserSMS_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_DelUserSMS(UserMng.lbSysOutputInfo, txtSMSID2, cbUserID1);

            Cursor = Cursors.Default;
        }

        private void btnClearSMS_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_ClearSMS(UserMng.lbSysOutputInfo);

            Cursor = Cursors.Default;
        }

        private void btnClearUserSMS_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_ClearUserSMS(UserMng.lbSysOutputInfo);

            Cursor = Cursors.Default;
        }

        private void txtSMSID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtValidMins_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSMSID1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSMSID2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Workcode
        private void btnSetWorkCode_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_SetWorkCode(UserMng.lbSysOutputInfo, txtWorkcodeID, txtWorkcodeName);

            Cursor = Cursors.Default;
        }

        private void btnGetWorkCode_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_GetWorkCode(UserMng.lbSysOutputInfo, txtWorkcodeID, txtWorkcodeName);

            Cursor = Cursors.Default;
        }

        private void btnDeleteWorkCode_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_DelWorkCode(UserMng.lbSysOutputInfo, txtWorkcodeID);

            Cursor = Cursors.Default;
        }

        private void btnClearWorkCode_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_ClearWorkCode(UserMng.lbSysOutputInfo);

            Cursor = Cursors.Default;
        }

        private void txtWorkcodeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtWorkcodeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == ' ' || char.IsLetter(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
        }

        #endregion

        #region userrole

        private void clbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "";

            str = clbMenu.SelectedItem.ToString();

            if (string.Compare(str, "User Mgt") == 0)
            {
                clbUserMgt.Visible = true;
                clbAccessControl.Visible = false;
                clbICCard.Visible = false;
                clbComm.Visible = false;
                clbSystem.Visible = false;
                clbPersonalize.Visible = false;
                clbDataMgt.Visible = false;
                clbUSBManager.Visible = false;
                clbAttendanceSearch.Visible = false;
                clbPrint.Visible = false;
                clbSMS.Visible = false;
                clbWorkCode.Visible = false;
                clbAutotest.Visible = false;
                clbSysInfo.Visible = false;
            }
            else if (string.Compare(str, "Access Control") == 0)
            {
                clbUserMgt.Visible = false ;
                clbAccessControl.Visible = true ;
                clbICCard.Visible = false;
                clbComm.Visible = false;
                clbSystem.Visible = false;
                clbPersonalize.Visible = false;
                clbDataMgt.Visible = false;
                clbUSBManager.Visible = false;
                clbAttendanceSearch.Visible = false;
                clbPrint.Visible = false;
                clbSMS.Visible = false;
                clbWorkCode.Visible = false;
                clbAutotest.Visible = false;
                clbSysInfo.Visible = false;
            }
            else if (string.Compare(str, "IC Card") == 0)
            {
                clbUserMgt.Visible = false;
                clbAccessControl.Visible = false ;
                clbICCard.Visible = true;
                clbComm.Visible = false;
                clbSystem.Visible = false;
                clbPersonalize.Visible = false;
                clbDataMgt.Visible = false;
                clbUSBManager.Visible = false;
                clbAttendanceSearch.Visible = false;
                clbPrint.Visible = false;
                clbSMS.Visible = false;
                clbWorkCode.Visible = false;
                clbAutotest.Visible = false;
                clbSysInfo.Visible = false;
            }
            else if (string.Compare(str, "Comm") == 0)
            {
                clbUserMgt.Visible = false;
                clbAccessControl.Visible = false;
                clbICCard.Visible = false;
                clbComm.Visible = true ;
                clbSystem.Visible = false;
                clbPersonalize.Visible = false;
                clbDataMgt.Visible = false;
                clbUSBManager.Visible = false;
                clbAttendanceSearch.Visible = false;
                clbPrint.Visible = false;
                clbSMS.Visible = false;
                clbWorkCode.Visible = false;
                clbAutotest.Visible = false;
                clbSysInfo.Visible = false;
            }
            else if (string.Compare(str, "System") == 0)
            {
                clbUserMgt.Visible = false;
                clbAccessControl.Visible = false;
                clbICCard.Visible = false;
                clbComm.Visible = false ;
                clbSystem.Visible = true ;
                clbPersonalize.Visible = false;
                clbDataMgt.Visible = false;
                clbUSBManager.Visible = false;
                clbAttendanceSearch.Visible = false;
                clbPrint.Visible = false;
                clbSMS.Visible = false;
                clbWorkCode.Visible = false;
                clbAutotest.Visible = false;
                clbSysInfo.Visible = false;
            }
            else if (string.Compare(str, "Personalize") == 0)
            {
                clbUserMgt.Visible = false;
                clbAccessControl.Visible = false;
                clbICCard.Visible = false;
                clbComm.Visible = false;
                clbSystem.Visible = false ;
                clbPersonalize.Visible = true ;
                clbDataMgt.Visible = false;
                clbUSBManager.Visible = false;
                clbAttendanceSearch.Visible = false;
                clbPrint.Visible = false;
                clbSMS.Visible = false;
                clbWorkCode.Visible = false;
                clbAutotest.Visible = false;
                clbSysInfo.Visible = false;
            }
            else if (string.Compare(str, "Data Mgt") == 0)
            {
                clbUserMgt.Visible = false;
                clbAccessControl.Visible = false;
                clbICCard.Visible = false;
                clbComm.Visible = false;
                clbSystem.Visible = false;
                clbPersonalize.Visible = false ;
                clbDataMgt.Visible = true ;
                clbUSBManager.Visible = false;
                clbAttendanceSearch.Visible = false;
                clbPrint.Visible = false;
                clbSMS.Visible = false;
                clbWorkCode.Visible = false;
                clbAutotest.Visible = false;
                clbSysInfo.Visible = false;
            }
            else if (string.Compare(str, "USB Manager") == 0)
            {
                clbUserMgt.Visible = false;
                clbAccessControl.Visible = false;
                clbICCard.Visible = false;
                clbComm.Visible = false;
                clbSystem.Visible = false;
                clbPersonalize.Visible = false ;
                clbDataMgt.Visible = false;
                clbUSBManager.Visible = true;
                clbAttendanceSearch.Visible = false;
                clbPrint.Visible = false;
                clbSMS.Visible = false;
                clbWorkCode.Visible = false;
                clbAutotest.Visible = false;
                clbSysInfo.Visible = false;
            }
            else if (string.Compare(str, "Attendance Search") == 0)
            {
                clbUserMgt.Visible = false;
                clbAccessControl.Visible = false;
                clbICCard.Visible = false;
                clbComm.Visible = false;
                clbSystem.Visible = false;
                clbPersonalize.Visible = false ;
                clbDataMgt.Visible = false  ;
                clbUSBManager.Visible = false;
                clbAttendanceSearch.Visible = true ;
                clbPrint.Visible = false;
                clbSMS.Visible = false;
                clbWorkCode.Visible = false;
                clbAutotest.Visible = false;
                clbSysInfo.Visible = false;
            }
            else if (string.Compare(str, "Print") == 0)
            {
                clbUserMgt.Visible = false;
                clbAccessControl.Visible = false;
                clbICCard.Visible = false;
                clbComm.Visible = false;
                clbSystem.Visible = false;
                clbPersonalize.Visible = false ;
                clbDataMgt.Visible = false;
                clbUSBManager.Visible = false;
                clbAttendanceSearch.Visible = false;
                clbPrint.Visible = true ;
                clbSMS.Visible = false;
                clbWorkCode.Visible = false;
                clbAutotest.Visible = false;
                clbSysInfo.Visible = false;
            }
            else if (string.Compare(str, "Short Message") == 0)
            {
                clbUserMgt.Visible = false;
                clbAccessControl.Visible = false;
                clbICCard.Visible = false;
                clbComm.Visible = false;
                clbSystem.Visible = false;
                clbPersonalize.Visible = false ;
                clbDataMgt.Visible = false;
                clbUSBManager.Visible = false;
                clbAttendanceSearch.Visible = false;
                clbPrint.Visible = false;
                clbSMS.Visible = true ;
                clbWorkCode.Visible = false;
                clbAutotest.Visible = false;
                clbSysInfo.Visible = false;
            }
            else if (string.Compare(str, "Work Code") == 0)
            {
                clbUserMgt.Visible = false;
                clbAccessControl.Visible = false;
                clbICCard.Visible = false;
                clbComm.Visible = false;
                clbSystem.Visible = false;
                clbPersonalize.Visible = false ;
                clbDataMgt.Visible = false;
                clbUSBManager.Visible = false;
                clbAttendanceSearch.Visible = false;
                clbPrint.Visible = false;
                clbSMS.Visible = false;
                clbWorkCode.Visible = true ;
                clbAutotest.Visible = false;
                clbSysInfo.Visible = false;
            }
            else if (string.Compare(str, "Auto Test") == 0)
            {
                clbUserMgt.Visible = false;
                clbAccessControl.Visible = false;
                clbICCard.Visible = false;
                clbComm.Visible = false;
                clbSystem.Visible = false;
                clbPersonalize.Visible = false ;
                clbDataMgt.Visible = false;
                clbUSBManager.Visible = false;
                clbAttendanceSearch.Visible = false;
                clbPrint.Visible = false;
                clbSMS.Visible = false;
                clbWorkCode.Visible = false;
                clbAutotest.Visible = true ;
                clbSysInfo.Visible = false;
            }
            else if (string.Compare(str, "System Info") == 0)
            {
                clbUserMgt.Visible = false;
                clbAccessControl.Visible = false;
                clbICCard.Visible = false;
                clbComm.Visible = false;
                clbSystem.Visible = false;
                clbPersonalize.Visible = false ;
                clbDataMgt.Visible = false;
                clbUSBManager.Visible = false;
                clbAttendanceSearch.Visible = false;
                clbPrint.Visible = false;
                clbSMS.Visible = false;
                clbWorkCode.Visible = false;
                clbAutotest.Visible = false;
                clbSysInfo.Visible = true ;
            }
        }

        private void clbMenu_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            //UserMng.lbSysOutputInfo.Items.Add(idx.ToString());
            switch (idx)
            {
                case 0:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbUserMgt.Items.Count; i++)
                            {

                                clbUserMgt.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbUserMgt.Items.Count; i++)
                            {

                                clbUserMgt.SetItemChecked(i, true);

                            }
                        }
                    }
                    break;
                case 1:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbAccessControl.Items.Count; i++)
                            {
                                clbAccessControl.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbAccessControl.Items.Count; i++)
                            {
                                clbAccessControl.SetItemChecked(i, true);
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbICCard.Items.Count; i++)
                            {
                                clbICCard.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbICCard.Items.Count; i++)
                            {
                                clbICCard.SetItemChecked(i, true);
                            }
                        }
                    }
                    break;
                case 3:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbComm.Items.Count; i++)
                            {
                                clbComm.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbComm.Items.Count; i++)
                            {
                                clbComm.SetItemChecked(i, true);
                            }
                        }
                    }
                    break;
                case 4:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbSystem.Items.Count; i++)
                            {
                                clbSystem.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbSystem.Items.Count; i++)
                            {
                                clbSystem.SetItemChecked(i, true);
                            }
                        }
                    }
                    break;
                case 5:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbPersonalize.Items.Count; i++)
                            {
                                clbPersonalize.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbPersonalize.Items.Count; i++)
                            {
                                clbPersonalize.SetItemChecked(i, true);
                            }
                        }
                    }
                    break;
                case 6:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbDataMgt.Items.Count; i++)
                            {
                                clbDataMgt.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbDataMgt.Items.Count; i++)
                            {
                                clbDataMgt.SetItemChecked(i, true);
                            }
                        }
                    }
                    break;
                case 7:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbUSBManager.Items.Count; i++)
                            {
                                clbUSBManager.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbUSBManager.Items.Count; i++)
                            {
                                clbUSBManager.SetItemChecked(i, true);
                            }
                        }
                    }
                    break;
                case 8:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbAttendanceSearch.Items.Count; i++)
                            {
                                clbAttendanceSearch.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbAttendanceSearch.Items.Count; i++)
                            {
                                clbAttendanceSearch.SetItemChecked(i, true);
                            }
                        }
                    }
                    break;
                case 9:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbPrint.Items.Count; i++)
                            {
                                clbPrint.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbPrint.Items.Count; i++)
                            {
                                clbPrint.SetItemChecked(i, true);
                            }
                        }
                    }
                    break;
                case 10:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbSMS.Items.Count; i++)
                            {
                                clbSMS.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbSMS.Items.Count; i++)
                            {
                                clbSMS.SetItemChecked(i, true);
                            }
                        }
                    }
                    break;
                case 11:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbWorkCode.Items.Count; i++)
                            {
                                clbWorkCode.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbWorkCode.Items.Count; i++)
                            {
                                clbWorkCode.SetItemChecked(i, true);
                            }
                        }
                    }
                    break;
                case 12:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbAutotest.Items.Count; i++)
                            {
                                clbAutotest.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbAutotest.Items.Count; i++)
                            {
                                clbAutotest.SetItemChecked(i, true);
                            }
                        }
                    }
                    break;
                case 13:
                    {
                        if (clbMenu.GetItemChecked(idx))
                        {
                            for (int i = 0; i < clbSysInfo.Items.Count; i++)
                            {
                                clbSysInfo.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < clbSysInfo.Items.Count; i++)
                            {
                                clbSysInfo.SetItemChecked(i, true);
                            }
                        }
                    }
                    break;
            }
        }

        private void btnGetUserRole_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            int[] iAppState = new int[14];
            int[] iFunUserMng = new int[3];
            int[] iFunAccess = new int[7];
            int[] iFunICCard = new int[5];
            int[] iFunComm = new int[7];
            int[] iFunSystem = new int[5];
            int[] iFunPersonalize = new int[6];
            int[] iFunDataMng = new int[3];
            int[] iFunUSBMng = new int[3];
            int[] iFunAttSearch = new int[3];
            int[] iFunPrint = new int[2];
            int[] iFunSMS = new int[2];
            int[] iFunWorkCode = new int[3];
            int[] iFunAutoTest = new int[7];
            int[] iFunSysInfo = new int[3];
            int i = 0;


            int ret = UserMng.SDK.sta_GetUserRole(UserMng.lbSysOutputInfo, cbUserRole, iAppState, iFunUserMng, iFunAccess, iFunICCard, iFunComm, iFunSystem, iFunPersonalize, iFunDataMng, iFunUSBMng, iFunAttSearch, iFunPrint, iFunSMS, iFunWorkCode, iFunAutoTest, iFunSysInfo);

            if (ret < 0)
            {
                Cursor = Cursors.Default;
                return;
            }

            for (i = 0; i < iAppState.Length; i++)
            {
                if (iAppState[i] == 1)
                {
                    clbMenu.SetItemCheckState(i,CheckState.Checked);
                }
                else
                {
                    clbMenu.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunUserMng.Length; i++)
            {
                if (iFunUserMng[i] == 1)
                {
                    clbUserMgt.SetItemCheckState(i, CheckState.Checked);     
                }
                else
                {
                    clbUserMgt.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunAccess.Length; i++)
            {
                if (iFunAccess[i] == 1)
                {
                    clbAccessControl.SetItemCheckState(i, CheckState.Checked); 
                }
                else
                {
                    clbAccessControl.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunICCard.Length; i++)
            {
                if (iFunICCard[i] == 1)
                {
                    clbICCard.SetItemCheckState(i, CheckState.Checked); 
                }
                else
                {
                    clbICCard.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunComm.Length; i++)
            {
                if (iFunComm[i] == 1)
                {
                    clbComm.SetItemCheckState(i, CheckState.Checked); 
                }
                else
                {
                    clbComm.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunSystem.Length; i++)
            {
                if (iFunSystem[i] == 1)
                {
                    clbSystem.SetItemCheckState(i, CheckState.Checked); 
                }
                else
                {
                    clbSystem.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunPersonalize.Length; i++)
            {
                if (iFunPersonalize[i] == 1)
                {
                    clbPersonalize.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    clbPersonalize.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunDataMng.Length; i++)
            {
                if (iFunDataMng[i] == 1)
                {
                    clbDataMgt.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    clbDataMgt.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunUSBMng.Length; i++)
            {
                if (iFunUSBMng[i] == 1)
                {
                    clbUSBManager.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    clbUSBManager.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunAttSearch.Length; i++)
            {
                if (iFunAttSearch[i] == 1)
                {
                    clbAttendanceSearch.SetItemCheckState(i, CheckState.Checked); 
                }
                else
                {
                    clbAttendanceSearch.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunPrint.Length; i++)
            {
                if (iFunPrint[i] == 1)
                {
                    clbPrint.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    clbPrint.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunSMS.Length; i++)
            {
                if (iFunSMS[i] == 1)
                {
                    clbSMS.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    clbSMS.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunWorkCode.Length; i++)
            {
                if (iFunWorkCode[i] == 1)
                {
                    clbWorkCode.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    clbWorkCode.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunAutoTest.Length; i++)
            {
                if (iFunAutoTest[i] == 1)
                {
                    clbAutotest.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    clbAutotest.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            for (i = 0; i < iFunSysInfo.Length; i++)
            {
                if (iFunSysInfo[i] == 1)
                {
                    clbSysInfo.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    clbSysInfo.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

            Cursor = Cursors.Default;
        }

        private void btnSetUserRole_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            int[] iAppState = new int[14];
            int[] iFunUserMng = new int[3];
            int[] iFunAccess = new int[7];
            int[] iFunICCard = new int[5];
            int[] iFunComm = new int[7];
            int[] iFunSystem = new int[5];
            int[] iFunPersonalize = new int[6];
            int[] iFunDataMng = new int[3];
            int[] iFunUSBMng = new int[3];
            int[] iFunAttSearch = new int[3];
            int[] iFunPrint = new int[2];
            int[] iFunSMS = new int[2];
            int[] iFunWorkCode = new int[3];
            int[] iFunAutoTest = new int[7];
            int[] iFunSysInfo = new int[3];

            for (int i = 0; i < clbMenu.Items.Count; i++)
            {
                if (clbMenu.GetItemChecked(i))
                {
                    iAppState[i] = 1;
                }
                else
                {
                    iAppState[i] = 0;
                }
            }

            for (int i = 0; i < clbUserMgt.Items.Count; i++)
            {
                if (clbUserMgt.GetItemChecked(i))
                {
                    iFunUserMng[i] = 1;
                }
                else
                {
                    iFunUserMng[i] = 0;
                }
            }

            for (int i = 0; i < clbAccessControl.Items.Count; i++)
            {
                if (clbAccessControl.GetItemChecked(i))
                {
                    iFunAccess[i] = 1;
                }
                else
                {
                    iFunAccess[i] = 0;
                }
            }

            for (int i = 0; i < clbICCard.Items.Count; i++)
            {
                if (clbICCard.GetItemChecked(i))
                {
                    iFunICCard[i] = 1;
                }
                else
                {
                    iFunICCard[i] = 0;
                }
            }

            for (int i = 0; i < clbComm.Items.Count; i++)
            {
                if (clbComm.GetItemChecked(i))
                {
                    iFunComm[i] = 1;
                }
                else
                {
                    iFunComm[i] = 0;
                }
            }

            for (int i = 0; i < clbSystem.Items.Count; i++)
            {
                if (clbSystem.GetItemChecked(i))
                {
                    iFunSystem[i] = 1;
                }
                else
                {
                    iFunSystem[i] = 0;
                }
            }

            for (int i = 0; i < clbPersonalize.Items.Count; i++)
            {
                if (clbPersonalize.GetItemChecked(i))
                {
                    iFunPersonalize[i] = 1;
                }
                else
                {
                    iFunPersonalize[i] = 0;
                }
            }

            for (int i = 0; i < clbDataMgt.Items.Count; i++)
            {
                if (clbDataMgt.GetItemChecked(i))
                {
                    iFunDataMng[i] = 1;
                }
                else
                {
                    iFunDataMng[i] = 0;
                }
            }

            for (int i = 0; i < clbUSBManager.Items.Count; i++)
            {
                if (clbUSBManager.GetItemChecked(i))
                {
                    iFunUSBMng[i] = 1;
                }
                else
                {
                    iFunUSBMng[i] = 0;
                }
            }

            for (int i = 0; i < clbAttendanceSearch.Items.Count; i++)
            {
                if (clbAttendanceSearch.GetItemChecked(i))
                {
                    iFunAttSearch[i] = 1;
                }
                else
                {
                    iFunAttSearch[i] = 0;
                }
            }

            for (int i = 0; i < clbPrint.Items.Count; i++)
            {
                if (clbPrint.GetItemChecked(i))
                {
                    iFunPrint[i] = 1;
                }
                else
                {
                    iFunPrint[i] = 0;
                }
            }

            for (int i = 0; i < clbSMS.Items.Count; i++)
            {
                if (clbSMS.GetItemChecked(i))
                {
                    iFunSMS[i] = 1;
                }
                else
                {
                    iFunSMS[i] = 0;
                }
            }

            for (int i = 0; i < clbWorkCode.Items.Count; i++)
            {
                if (clbWorkCode.GetItemChecked(i))
                {
                    iFunWorkCode[i] = 1;
                }
                else
                {
                    iFunWorkCode[i] = 0;
                }
            }

            for (int i = 0; i < clbAutotest.Items.Count; i++)
            {
                if (clbAutotest.GetItemChecked(i))
                {
                    iFunAutoTest[i] = 1;
                }
                else
                {
                    iFunAutoTest[i] = 0;
                }
            }

            for (int i = 0; i < clbSysInfo.Items.Count; i++)
            {
                if (clbSysInfo.GetItemChecked(i))
                {
                    iFunSysInfo[i] = 1;
                }
                else
                {
                    iFunSysInfo[i] = 0;
                }
            }

            int ret = UserMng.SDK.sta_SetUserRole(UserMng.lbSysOutputInfo, cbUserRole, iAppState, iFunUserMng, iFunAccess, iFunICCard, iFunComm, iFunSystem, iFunPersonalize, iFunDataMng, iFunUSBMng, iFunAttSearch, iFunPrint, iFunSMS, iFunWorkCode, iFunAutoTest, iFunSysInfo);


            Cursor = Cursors.Default;
        }
        #endregion

        private void GetUserInfo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            UserMng.SDK.sta_GetUserInfo(UserMng.lbSysOutputInfo, txtUserID, txtName, cbPrivilege, txtCardnumber, txtPassword);

            Cursor = Cursors.Default;
        }

    }
}
