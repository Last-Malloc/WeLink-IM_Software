[csdn文章地址](https://blog.csdn.net/qq_42283621/article/details/119305659)

[github仓库地址](https://github.com/Last-Malloc/WeLink-IM_Software)

# 1. 前言

本项目是作者大学三时所做项目，小型即时通讯软件《WeLinked》，使用C#语言并结合网络编程、多线程、BaiduAl、MySql、Sqlite、
Cskin等相关技术，实现多登录方式、多消息类型、多人聊天的网络即时聊天和文件传输功能。水平一般，希望和大家一起交流和学习。

首先，关于软件名称《WeLinked》，和华为的通讯软件WeLink没有任何关系，当时作者为了剽窃某xun的名称创意起名welink，后来同学告知重名后又稍作修改。

其次项目的目录结构

| 目录          | 介绍                                                         |
| ------------- | ------------------------------------------------------------ |
| WeLink        | 客户端项目                                                   |
| WeLink_Server | 服务器项目                                                   |
| 发布          | 发布相关，包括客户端安装包(Windows点击安装)、服务器压缩包(解压运行)、介绍PPT、客户端附属帮助文档、演示录屏 |
| 设计          | 设计相关，包括需求分析、数据库设计、sql建表命令、测试数据和测试头像 |



本文将对项目框架做一个简要的介绍，具体的设计、实现等均放在了github中。

测试功能的话，在项目的 发布文件夹下，有

	WeLink1.1.0Setup.exe 客户端安装包，点击安装即可。
	
	WeLinkServer.zip 服务器压缩包，解压点击exe运行即可。

可以将客户端登录也的服务器地址改为127.0.0.1(本地)在本地测试，或者也可以随便整个低配的window server云服务器，把服务器软件放在上面开起来。但无论服务器在哪开启，都需要在服务器端安装mysql，并且建立数据库welink_server，将sql建表命令在其中执行(sql建表命令放在了 设计 文件夹下)，root密码改为648371，或者更改ConnectionPool.cs中相关代码。

# 2. 项目简介

## 1） 主要配置

| 项        | 内容                              |
| --------- | --------------------------------- |
| IDE       | VS 2017 Professional              |
| 框架      | C# .Net FrameWord 4.6.1           |
| 界面美化  | LayeredSkin界面库、CSkin界面库    |
| 数据存储  | Mysql（服务器）、SQLite（客户端） |
| 配置存储  | XML（客户端）                     |
| 第三方DLL | AForge.Video、Baidu.AI            |

## 2） 主要结构

采用.Net框架
服务器端使用MySql数据库存储数据；
客户端使用SQLite数据库存储数据，XML文件存储配置；



使用Socket通信，TCP协议传输，客户端与服务器之间维持2组Socket：
	socketMain：负责传送即时消息，控制命令等轻量紧急数据；
	socketAssist：负责传送文件上传、下载等大量数据；



采用三层设计结构：
	显示层UI——前端交互界面
	业务逻辑层BLL——业务处理
	数据访问层——数据存储于获取
	

**数据传输**

![image-20210801234429738](https://img-blog.csdnimg.cn/img_convert/7ae412cd2492afd5e6385906106016c4.png)

## 3） 数据库设计

![image-20210801234109358](https://img-blog.csdnimg.cn/img_convert/50791bf0e493ab5d26c9a8b7dd685039.png)

**服务器**：
用户信息表：存储用户基本信息
群组信息表：存储群组基本信息
好友/群列表：存储好友关系，群成员关系等信息
聊天记录表：存储聊天记录
好友/群申请表：存储申请添加好友/申请入群信息
登录日志表：存储用户登录信息
登录数据统计表：存储登录数据统计信息  
//实现使用mysql数据库

**客户端**：
最近登录表：存货最近登录成功账户的登录信息
聊天记录表：存储该用户聊天记录
聊天栏状态表：存储客户端退出时聊天列表状态
//实现使用sqlite数据库

## 4） 文件目录结构

**客户端**：
cookie//缓存文件夹，客户端首次运行时建立
    general//通用文件夹(客户端所有账号共享)
        login.db3//存放recent最近登录表
        clientConfig.xml//客户端配置信息文件(服务器IP地址+端口、关闭按钮功能、当前缓存文件默认保存路径)
    userheadpic//用户头像图片缓存文件夹
    userdata//用户缓存信息文件夹
        [n*cardID]//用户cardID缓存信息文件夹，该用户登录首次登录成功时建立
            file//该用户默认文件保存路径
            info.db3//存放ChatInfo聊天记录表、ChatStatus聊天栏状态表
    system//系统文件夹，预置
        帮助文档.pdf//帮助文档
        moren.jpg//用户的默认头像图片

**服务器**：
userheadpic//用户头像图片缓存文件夹
fileStore//用户传输文件缓存文件夹
logs//服务器操作日志缓存文件夹
     xxx.txt//操作日志文件

# 3. 软件界面图

![image-20210801234644674](https://img-blog.csdnimg.cn/img_convert/113cc05d79905f136f8f3e7a0ede9eff.png)

![image-20210801234651529](https://img-blog.csdnimg.cn/img_convert/045849cbdb0614342ef5e126828f352d.png)

![image-20210801235803186](https://img-blog.csdnimg.cn/img_convert/6b128fcc824ca83351334dc3d32e4730.png)

![image-20210801234716512](https://img-blog.csdnimg.cn/img_convert/afe76f3aa6b812886bd45adcb112d593.png)

![image-20210801234726687](https://img-blog.csdnimg.cn/img_convert/bf6e0ca3b1d184b9e9f34b9e57a20194.png)

![image-20210801235842399](https://img-blog.csdnimg.cn/img_convert/ea6f7e6871cd40d4cc38be5dbd838600.png)

![image-20210801234800591](https://img-blog.csdnimg.cn/img_convert/420aeedb203e300d70edd74f8d848768.png)

![image-20210801234808110](https://img-blog.csdnimg.cn/img_convert/4b2b870a012ef4e5dd2709173e10c929.png)

![image-20210801235910589](https://img-blog.csdnimg.cn/img_convert/ea9980c4e4832825f36fe493508905c1.png)

![image-20210801235933186](https://img-blog.csdnimg.cn/img_convert/51b722cba023882fe9baab428939e181.png)

![image-20210801235953024](https://img-blog.csdnimg.cn/img_convert/67f3573d1501196809caba1cdc695864.png)

![image-20210801234839925](https://img-blog.csdnimg.cn/img_convert/72d8f7c89c9a20f8d364a518ac1b8222.png)

![image-20210802000017397](https://img-blog.csdnimg.cn/img_convert/fe569a09611d115b54c2e2497389bbe1.png)

![image-20210802000040041](https://img-blog.csdnimg.cn/img_convert/9a65499c9a9e781d7212c999b9ac3959.png)

![image-20210801234909780](https://img-blog.csdnimg.cn/img_convert/8e0f3986cbb376a3b3043ce58d38c279.png)