using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;

namespace WeLink.BLL
{
    /// <summary>
    /// 用于本地和云端进行同步的类：从本地或请求云端返回正确的用户头像图片（头像等待机制）
    /// </summary>
    public class GetRecSyncInfo
    {
        #region 构造函数
        ServerMain serverMain = null;
        public GetRecSyncInfo(ServerMain serverMain)
        {
            this.serverMain = serverMain;
        }
        #endregion

        /// <summary>
        /// 通过账号向头像框设置头像（0彩色1黑白）
        /// 头像等待机制的实施措施：在本地缓存中查找用户的png或jpg图片，有则返回，无则返回默认头像，
        /// 同时向云端请求数据，进入等待阶段，用后台线程每2秒执行一次刷新最多10次，直至失败或返回正确的头像
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public void setHeadPicForBaseControl(DuiBaseControl headImg, string cardID, int color = 0)
        {
            try
            {
                string pathPng = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + cardID + ".png";
                string pathJpg = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + cardID + ".jpg";
                if (File.Exists(pathPng))
                {
                    if (color == 0)
                    {
                        headImg.BackgroundImage = ToolUnion.Image_FromStream(pathPng);
                        return;
                    }
                    else
                    {
                        headImg.BackgroundImage = ToolUnion.Image_ToBlackWhite(new Bitmap(
                            ToolUnion.Image_FromStream(pathPng)));
                        return;
                    }
                }
                else if (File.Exists(pathJpg))
                {
                    if (color == 0)
                    {
                        headImg.BackgroundImage = ToolUnion.Image_FromStream(pathJpg);
                        return;
                    }
                    else
                    {
                        headImg.BackgroundImage = ToolUnion.Image_ToBlackWhite(new Bitmap(
                            ToolUnion.Image_FromStream(pathJpg)));
                        return;
                    }
                }
                else
                {
                    //发送头像申请
                    serverMain.SendData(new StructGetInfo(TransType.HeadPicGetRequest, new HeadPicGetRequest(cardID)));
                    //临时返回默认头像，并开启线程每2s执行一次重新设置头像，最多执行5次共10s
                    if (color == 0)
                    {
                        headImg.BackgroundImage = ToolUnion.Image_FromStream(System.Environment.CurrentDirectory + @"\system\moren.png");
                    }
                    else
                    {
                        headImg.BackgroundImage = ToolUnion.Image_ToBlackWhite(
                            new Bitmap(ToolUnion.Image_FromStream(System.Environment.CurrentDirectory + @"\system\moren.png")));
                    }
                    //开启新线程等待刷新
                    Thread thread = new Thread(waitHeadImgRefreshDui);
                    thread.IsBackground = true;
                    thread.Start(new object[] { headImg, cardID, color, 10 });
                }
            }
            catch (Exception)
            {
            }
        }
        public void setHeadPicForBaseControl(LayeredBaseControl headImg, string cardID, int color = 0)
        {
            try
            {
                string pathPng = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + cardID + ".png";
                string pathJpg = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + cardID + ".jpg";
                if (File.Exists(pathPng))
                {
                    if (color == 0)
                    {
                        headImg.BackgroundImage = ToolUnion.Image_FromStream(pathPng);
                        return;
                    }
                    else
                    {
                        headImg.BackgroundImage = ToolUnion.Image_ToBlackWhite(new Bitmap(
                            ToolUnion.Image_FromStream(pathPng)));
                        return;
                    }
                }
                else if (File.Exists(pathJpg))
                {
                    if (color == 0)
                    {
                        headImg.BackgroundImage = ToolUnion.Image_FromStream(pathJpg);
                        return;
                    }
                    else
                    {
                        headImg.BackgroundImage = ToolUnion.Image_ToBlackWhite(new Bitmap(
                            ToolUnion.Image_FromStream(pathJpg)));
                        return;
                    }
                }
                else
                {
                    //发送头像申请
                    serverMain.SendData(new StructGetInfo(TransType.HeadPicGetRequest, new HeadPicGetRequest(cardID)));
                    //临时返回默认头像，并开启线程每2s执行一次重新设置头像，最多执行5次共10s
                    if (color == 0)
                    {
                        headImg.BackgroundImage = ToolUnion.Image_FromStream(System.Environment.CurrentDirectory + @"\system\moren.png");
                    }
                    else
                    {
                        headImg.BackgroundImage = ToolUnion.Image_ToBlackWhite(
                            new Bitmap(ToolUnion.Image_FromStream(System.Environment.CurrentDirectory + @"\system\moren.png")));
                    }
                    //开启新线程等待刷新
                    Thread thread = new Thread(waitHeadImgRefreshLay);
                    thread.IsBackground = true;
                    thread.Start(new object[] { headImg, cardID, color, 10 });
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 刷新头像框显示直至尝试次数10或得到正确的头像
        /// </summary>
        private void waitHeadImgRefreshDui(object o)
        {
            try
            {
                object[] to = (object[])o;
                DuiBaseControl headImg = (DuiBaseControl)to[0];
                string cardID = (string)to[1];
                int color = (int)to[2];
                int tryCnt = (int)to[3];

                if (tryCnt > 0)
                {
                    --tryCnt;
                    Thread.Sleep(2000);
                    string pathPng = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + cardID + ".png";
                    string pathJpg = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + cardID + ".jpg";
                    if (File.Exists(pathPng))
                    {
                        if (color == 0)
                        {
                            headImg.BackgroundImage = ToolUnion.Image_FromStream(pathPng);
                            return;
                        }
                        else
                        {
                            headImg.BackgroundImage = ToolUnion.Image_ToBlackWhite(new Bitmap(
                                ToolUnion.Image_FromStream(pathPng)));
                            return;
                        }
                    }
                    else if (File.Exists(pathJpg))
                    {
                        if (color == 0)
                        {
                            headImg.BackgroundImage = ToolUnion.Image_FromStream(pathJpg);
                            return;
                        }
                        else
                        {
                            headImg.BackgroundImage = ToolUnion.Image_ToBlackWhite(new Bitmap(
                                ToolUnion.Image_FromStream(pathJpg)));
                            return;
                        }
                    }
                    else
                    {
                        //开启新线程等待刷新
                        Thread thread = new Thread(waitHeadImgRefreshDui);
                        thread.IsBackground = true;
                        thread.Start(new object[] { headImg, cardID, color, tryCnt });
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void waitHeadImgRefreshLay(object o)
        {
            try
            {
                object[] to = (object[])o;
                LayeredBaseControl headImg = (LayeredBaseControl)to[0];
                string cardID = (string)to[1];
                int color = (int)to[2];
                int tryCnt = (int)to[3];

                if (tryCnt > 0)
                {
                    --tryCnt;
                    Thread.Sleep(2000);
                    string pathPng = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + cardID + ".png";
                    string pathJpg = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + cardID + ".jpg";
                    if (File.Exists(pathPng))
                    {
                        if (color == 0)
                        {
                            headImg.BackgroundImage = ToolUnion.Image_FromStream(pathPng);
                            return;
                        }
                        else
                        {
                            headImg.BackgroundImage = ToolUnion.Image_ToBlackWhite(new Bitmap(
                                ToolUnion.Image_FromStream(pathPng)));
                            return;
                        }
                    }
                    else if (File.Exists(pathJpg))
                    {
                        if (color == 0)
                        {
                            headImg.BackgroundImage = ToolUnion.Image_FromStream(pathJpg);
                            return;
                        }
                        else
                        {
                            headImg.BackgroundImage = ToolUnion.Image_ToBlackWhite(new Bitmap(
                                ToolUnion.Image_FromStream(pathJpg)));
                            return;
                        }
                    }
                    else
                    {
                        //开启新线程等待刷新
                        Thread thread = new Thread(waitHeadImgRefreshLay);
                        thread.IsBackground = true;
                        thread.Start(new object[] { headImg, cardID, color, tryCnt });
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
