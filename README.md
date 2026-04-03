# ExportTool

一个轻量级的数据库查询和导出工具，支持SQL Server和MySQL数据库。

## 功能特性

- 🗄️ **多数据库支持** - 同时支持 SQL Server 和 MySQL
- 📝 **脚本管理** - 管理多个SQL脚本，支持变量替换
- 📥 **Excel导出** - 一键导出到标准Excel格式（.xlsx）
- 🔒 **数据加密** - 数据库连接信息AES加密保存
- 🚀 **极致轻量** - 单文件发布，体积小巧

## 快速开始
<img width="1222" height="640" alt="image" src="https://github.com/user-attachments/assets/d50aacc5-0c87-49b9-a1c8-cdf2a40f5626" />

<img width="1212" height="634" alt="image" src="https://github.com/user-attachments/assets/56ce602c-70f1-4ee6-8385-e2844540a2b1" />


### 下载

从 [Releases](../../releases) 页面下载最新版本。

### 使用

1. 运行 `ExportTool.exe`
2. 添加数据库连接（支持 SQL Server 和 MySQL，可配置端口号）
3. 添加SQL脚本（支持自定义变量）
4. 选择连接和脚本，填写变量值
5. 点击查询，预览查询结果
6. 点击导出，将结果集导出到Excel文件

## 脚本变量

在SQL脚本中使用变量：

```sql
SELECT * FROM users WHERE create_time >= '${startDate=2024-01-01}' AND status = ${status=1}
```

选择脚本后，程序会自动解析出变量并显示输入框。点击右侧变量列表可以快速定位到脚本中的对应位置。

## 数据库连接配置

### 字段顺序
1. 连接名称
2. 数据库类型
3. 服务器
4. 端口（可选，留空使用默认端口）
5. 数据库名
6. 用户名
7. 密码

### 端口说明
- **SQL Server**: 默认端口 1433
- **MySQL**: 默认端口 3306

## 构建

### 环境要求

- Visual Studio 2019 或更高版本
- .NET Framework 4.8

### 构建步骤

1. 克隆仓库
   ```bash
   git clone https://github.com/yourusername/ExportTool.git
   cd ExportTool
   ```

2. 还原 NuGet 包
   ```bash
   # 在 Visual Studio 中打开项目会自动还原
   # 或使用 Package Manager Console
   ```

3. 编译
   ```bash
   # 使用 Visual Studio
   # 或使用 MSBuild
   msbuild ExportTool.csproj /p:Configuration=Release
   ```

4. 输出文件位于 `bin\Release\` 目录

## 技术栈

- **框架**: .NET Framework 4.8
- **UI**: WinForms
- **数据库**:
  - SQL Server (System.Data.SqlClient)
  - MySQL (MySqlConnector)
- **Excel导出**: OpenXML SDK
- **单文件发布**: Costura.Fody
- **JSON序列化**: JavaScriptSerializer (内置)
- **加密**: AES

## 项目结构

```
ExportTool/
├── Form1.cs              # 主窗体
├── Form1.Designer.cs     # 主窗体设计
├── DatabaseConnection.cs # 数据库连接管理（含加密解密）
├── SqlScript.cs          # SQL脚本管理
├── ExcelExporter.cs      # Excel导出（OpenXML）
├── ConnectionForm.cs     # 连接配置窗体
├── ConnectionForm.Designer.cs # 连接配置窗体设计
├── ScriptForm.cs         # 脚本编辑窗体
├── ScriptForm.Designer.cs # 脚本编辑窗体设计
└── JsonHelper.cs         # JSON工具类
```

## 许可证

[MIT License](LICENSE)

## 贡献

欢迎提交 Issue 和 Pull Request！

## 致谢

- [MySqlConnector](https://mysqlconnector.net/) - MySQL 驱动
- [Costura.Fody](https://github.com/Fody/Costura) - 单文件打包工具
- [OpenXML SDK](https://github.com/OfficeDev/Open-XML-SDK) - Excel 生成

---

**Enjoy!** 🎉
