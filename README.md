# VirusSignalR

> 极简的反向命令行木马


## ⚠️ 免责声明：本程序仅用于学习交流，请勿用于非法用途，如使用请自行承担法律风险。

---

## 📦 项目介绍

简要介绍项目背景、目标和核心功能。

- 使用ASP.NET作为后台，使用SignalR进行通信
- 分为靶机（Client）和攻击机（Master）
- 使用System.Management.Automation库进行命令执行，传回命令执行结果

---

## 🛠 技术栈

- 前端：.NET10，ASP.NET core，System.Management.Automation

---

## 📁 项目结构

```text
project-root/
├─ Properties/
├─ VirusSignalR.Client/                
│  └─ Program.cs          # 入口文件
├─ VirusSignalR.Server/                
│  ├─ Hubs/             # 定义SignalR的Hub
│  └─ Program.ts          # 入口文件
├─ VirusSignalR.Master/      
│  └─ Program.ts          # 入口文件                 
├─ .gitignore
├─ README.md
└─ appsettings.json
