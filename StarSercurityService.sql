IF NOT EXISTS (SELECT 1 FROM Branches)
BEGIN
SET IDENTITY_INSERT [dbo].[Branches] ON;

INSERT [dbo].[Branches] ([Id], [Region], [Address], [ContactPerson], [Email], [Phone], [Description], [GoogleMap]) VALUES (1, N'khu bắc', N'hn', N'0983285972', N'dang123@gmail.com', N'0998736722', N'<p>abc</p>;
', NULL);
INSERT [dbo].[Branches] ([Id], [Region], [Address], [ContactPerson], [Email], [Phone], [Description], [GoogleMap]) VALUES (2, N'North', N'123 Hanoi St.', N'Nguyen Van A', N'northbranch@example.com', N'0912345678', N'Main branch in Hanoi', N'https://maps.example.com/north');
INSERT [dbo].[Branches] ([Id], [Region], [Address], [ContactPerson], [Email], [Phone], [Description], [GoogleMap]) VALUES (3, N'South', N'456 HCM St.', N'Tran Van B', N'southbranch@example.com', N'0987654321', N'Main branch in HCM', N'https://maps.example.com/south');
INSERT [dbo].[Branches] ([Id], [Region], [Address], [ContactPerson], [Email], [Phone], [Description], [GoogleMap]) VALUES (4, N'West', N'456 Can Tho St.', N'Pham Van D', N'westbranch@example.com', N'0933221100', N'Branch in Can Tho', N'https://maps.example.com/west');
INSERT [dbo].[Branches] ([Id], [Region], [Address], [ContactPerson], [Email], [Phone], [Description], [GoogleMap]) VALUES (5, N'East', N'987 Vung Tau St.', N'Tran Thi E', N'eastbranch@example.com', N'0945566778', N'Branch in Vung Tau', N'https://maps.example.com/east');
SET IDENTITY_INSERT [dbo].[Branches] OFF;
END
SET IDENTITY_INSERT [dbo].[Roles] ON;

INSERT [dbo].[Roles] ([Id], [Name], [Description]) VALUES (1, N'Admin', NULL);
INSERT [dbo].[Roles] ([Id], [Name], [Description]) VALUES (2, N'Manager', NULL);
INSERT [dbo].[Roles] ([Id], [Name], [Description]) VALUES (3, N'Staff', NULL);
SET IDENTITY_INSERT [dbo].[Roles] OFF;


SET IDENTITY_INSERT [dbo].[Services] ON;

INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (1, N'sercurity', N'<p>Security services are a type of service that provides human resources and security solutions to ensure the safety of assets, people and activities within a specific scope or organization. This service is provided by professional security companies or internal security units within the organization.</p>;

<p>Main tasks of security services<br />;
<strong>1. Protect people:</strong></p>;

<p>Ensure the safety of employees, customers, and individuals in the protected area.<br />;
Control and guide internal traffic in crowded areas.<br />;
Handle emergency situations such as fires, riots, or natural disasters.</p>;

<p><strong>2. Protect assets:</strong></p>;

<p>Prevent unauthorized intrusion, theft, or destruction of property.<br />;
Monitor fixed and mobile assets, such as buildings, vehicles, machinery and equipment.</p>;

<p><strong>3. Security monitoring:</strong></p>;

<p>Use camera systems and security equipment to monitor key areas.<br />;
Carry out regular or on-demand patrols to detect and handle unusual signs.</p>;

<p><strong>4. Access management:</strong></p>;

<p>Control the entry and exit of employees, customers, and vehicles in areas that need protection.<br />;
Check documents, verify identities, and register entry and exit information.</p>;

<p><strong>5. Risk Prevention and Management:</strong></p>;

<p>Predict and plan for potentially dangerous situations.<br />;
Support authorities in handling serious incidents.</p>;
');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (7, N'CCTV Surveillance', N'24/7 monitoring through high-quality cameras.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (8, N'Access Control Systems', N'Secure access to premises with advanced control systems.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (9, N'Cybersecurity Protection', N'Comprehensive protection for digital assets and networks.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (10, N'Mobile Patrol', N'Routine patrols to ensure property safety.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (11, N'Risk Assessment', N'Identify and mitigate potential security risks.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (12, N'Emergency Response', N'Immediate response to security incidents or emergencies.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (13, N'Event Security', N'Specialized security services for events and gatherings.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (14, N'VIP Protection', N'Professional bodyguard and escort services for VIPs.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (15, N'Alarm Monitoring', N'Real-time monitoring and response to alarm systems.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (16, N'Physical Security', N'On-site security for premises and physical assets.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (17, N'Security Consulting', N'Expert advice on improving security measures.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (18, N'Technical Security Solutions', N'Installation and maintenance of advanced security systems.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (19, N'Incident Management', N'Handling and resolving security incidents effectively.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (20, N'Security Audits', N'Comprehensive evaluation of existing security systems.');
INSERT [dbo].[Services] ([Id], [ServiceName], [Description]) VALUES (21, N'Training and Development', N'Training programs for security personnel.');
SET IDENTITY_INSERT [dbo].[Services] OFF;


SET IDENTITY_INSERT [dbo].[Departments] ON;

INSERT [dbo].[Departments] ([Id], [Name]) VALUES (1, N'Admin');
INSERT [dbo].[Departments] ([Id], [Name]) VALUES (4, N'Surveillance Operations');
INSERT [dbo].[Departments] ([Id], [Name]) VALUES (5, N'Access Control');
INSERT [dbo].[Departments] ([Id], [Name]) VALUES (6, N'Cybersecurity');
INSERT [dbo].[Departments] ([Id], [Name]) VALUES (7, N'Physical Security');
INSERT [dbo].[Departments] ([Id], [Name]) VALUES (8, N'Risk Assessment');
INSERT [dbo].[Departments] ([Id], [Name]) VALUES (9, N'Emergency Response');
INSERT [dbo].[Departments] ([Id], [Name]) VALUES (10, N'Technical Support');
INSERT [dbo].[Departments] ([Id], [Name]) VALUES (11, N'Training and Development');
INSERT [dbo].[Departments] ([Id], [Name]) VALUES (12, N'Incident Management');
INSERT [dbo].[Departments] ([Id], [Name]) VALUES (13, N'Security Consulting');
INSERT [dbo].[Departments] ([Id], [Name]) VALUES (17, N'adminm');
SET IDENTITY_INSERT [dbo].[Departments] OFF;

SET IDENTITY_INSERT [dbo].[Employees] ON;

INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (26, N'Nguyen Van A', N'/images/e1.jpg', N'123 Main St, Hanoi', N'0912345678', N'a.nguyen@example.com', N'Bachelor', N'A', N'Top Performer 2023', N'nguyenvana', N'57368351372010837489518916815920355114', 8, 2);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (27, N'Tran Thi B', N'/images/e10.jpg', N'456 Center St, HCM City', N'0923456789', N'b.tran@example.com', N'Master', N'A', N'Employee of the Month', N'tranthib', N'1779222216410446216751356471107134212128', 6, 3);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (28, N'Pham Van C', N'/images/e5.jpg', N'789 West St, Da Nang', N'0934567890', N'c.pham@example.com', N'Bachelor', N'B', N'Best Team Leader', N'phamvanc', N'5310614719128204481571591124214518211324880', 4, 3);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (29, N'Le Thi D', N'/images/e9.jpg', N'321 East St, Hai Phong', N'0945678901', N'd.le@example.com', N'Diploma', N'C', N'Excellence in Service', N'lethid', N'57368351372010837489518916815920355114', 4, 3);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (30, N'Hoang Van E', N'/images/e7.jpg', N'654 North St, Can Tho', N'0956789012', N'e.hoang@example.com', N'Master', N'B', N'Top Sales Achiever', N'hoangvane', N'57368351372010837489518916815920355114', 5, 3);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (31, N'Vo Thi F', N'/images/e8.jpg', N'987 South St, Vung Tau', N'0967890123', N'f.vo@example.com', N'Bachelor', N'C', N'Outstanding Contribution', N'vothif', N'57368351372010837489518916815920355114', 6, 3);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (32, N'Ngo Van G', N'/images/e6.jpg', N'147 Central St, Thanh Hoa', N'0978901234', N'g.ngo@example.com', N'Doctorate', N'A', N'Research Excellence', N'ngovang', N'13012420314234138112108765216110414524878123', 13, 3);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (33, N'Do Thi H', N'/images/e12.jpg', N'258 Coastal St, Khanh Hoa', N'0989012345', N'h.do@example.com', N'Diploma', N'B', N'Team Player Award', N'dothih', N'5310614719128204481571591124214518211324880', 7, 3);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (34, N'Vu Van I', N'/images/e3.jpg', N'369 Highland St, Dak Lak', N'0990123456', N'i.vu@example.com', N'Bachelor', N'C', N'Employee of the Year', N'vuvani', N'13012420314234138112108765216110414524878123', 8, 3);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (35, N'Pham Thi J', N'/images/e8.jpg', N'123 Central Blvd, Binh Dinh', N'0901234567', N'j.pham@example.com', N'Master', N'A', N'Best Innovator', N'phamthij', N'13012420314234138112108765216110414524878123', 9, 3);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (36, N'Nguyen Van K', N'/images/e11.jpg', N'456 Mekong Rd, Vinh Long', N'0912345670', N'k.nguyen@example.com', N'Bachelor', N'B', N'Customer Service Star', N'nguyenvank', N'13012420314234138112108765216110414524878123', 10, 3);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (37, N'Tran Thi L', N'/images/e12.jpg', N'789 Island St, Phu Quoc', N'0923456781', N'l.tran@example.com', N'Diploma', N'A', N'Leadership Award', N'tranthil', N'57368351372010837489518916815920355114', 11, 3);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (38, N'Hoang Van M1', N'/images/e1.jpg', N'321 Northern Blvd, Lao Cai', N'0934567892', N'm.hoang@example.com', N'Master', N'C', N'Best Mentor', N'hoangvanm', N'13012420314234138112108765216110414524878123', 5, 3);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (39, N'Vo Thi N', N'/images/e2.jpg', N'654 Southern Blvd, Soc Trang', N'0945678903', N'n.vo@example.com', N'Doctorate', N'B', N'Excellence in Execution', N'vothin', N'13012420314234138112108765216110414524878123', 7, 3);
INSERT [dbo].[Employees] ([Code], [Name], [Avata], [Address], [Phone], [Email], [Education], [Grade], [Achievements], [Username], [Password], [DepartmentId], [RoleId]) VALUES (40, N'Ngo Van O', N'/images/e5.jpg', N'987 Coastal Rd, Nghe An', N'0956789014', N'o.ngo@example.com', N'Bachelor', N'A', N'Top Innovator', N'ngovano', N'13012420314234138112108765216110414524878123', 10, 2);

SET IDENTITY_INSERT [dbo].[Employees] OFF;

SET IDENTITY_INSERT [dbo].[Clients] ON;

INSERT [dbo].[Clients] ([Id], [Name], [Email], [Phone], [Address], [ServiceId]) VALUES (18, N'Galaxy Mall1111', N'info@galaxymall.com', N'0901123456', N'123 Main St, Hanoi', 1);
INSERT [dbo].[Clients] ([Id], [Name], [Email], [Phone], [Address], [ServiceId]) VALUES (20, N'Elite Bank', N'contact@elitebank.com', N'0902234567', N'456 Finance Rd, HCM City', 10);
INSERT [dbo].[Clients] ([Id], [Name], [Email], [Phone], [Address], [ServiceId]) VALUES (21, N'Tech Innovators', N'security@techinnovators.com', N'0903345678', N'789 Silicon St, Da Nang', 19);
INSERT [dbo].[Clients] ([Id], [Name], [Email], [Phone], [Address], [ServiceId]) VALUES (22, N'Royal Hotel', N'support@royalhotel.com', N'0904456789', N'321 Luxury Ave, HCM City', 1);
INSERT [dbo].[Clients] ([Id], [Name], [Email], [Phone], [Address], [ServiceId]) VALUES (23, N'City Tower Office', N'office@citytower.com', N'0901123456', N'0905567890', 9);
INSERT [dbo].[Clients] ([Id], [Name], [Email], [Phone], [Address], [ServiceId]) VALUES (24, N'Global Shipping', N'support@globalshipping.com', N'0907789012', N'147 Ocean Rd, Hai Phong', 21);
INSERT [dbo].[Clients] ([Id], [Name], [Email], [Phone], [Address], [ServiceId]) VALUES (25, N'Luxury Residences', N'contact@luxuryresidences.com', N'0911012345', N'123 Green Blvd, HCM City', 17);
INSERT [dbo].[Clients] ([Id], [Name], [Email], [Phone], [Address], [ServiceId]) VALUES (26, N'Star Sports Complex', N'sports@starcomplex.com', N'0916567890', N'987 Fitness Blvd, Can Tho', 19);
INSERT [dbo].[Clients] ([Id], [Name], [Email], [Phone], [Address], [ServiceId]) VALUES (27, N'Skyline Apartments', N'admin@skyline.com', N'0913234567', N'789 Skyline Rd, Da Nang', 16);
INSERT [dbo].[Clients] ([Id], [Name], [Email], [Phone], [Address], [ServiceId]) VALUES (28, N'Grand Plaza', N'security@grandplaza.com', N'0912123456', N'456 Grand St, Hanoi', 20);
SET IDENTITY_INSERT [dbo].[Clients] OFF;


SET IDENTITY_INSERT [dbo].[Vacancies] ON;

INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (11, N'Security Guard', N'Responsible for monitoring premises and ensuring safety.', 1, CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-06-30T00:00:00.0000000' AS DateTime2), 10);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (12, N'CCTV Operator', N'Monitor and analyze surveillance footage.', 1, CAST(N'2024-02-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-31T00:00:00.0000000' AS DateTime2), 5);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (13, N'Access Control Specialist', N'Manage and enforce entry/exit procedures.', 0, CAST(N'2023-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-11-30T00:00:00.0000000' AS DateTime2), 3);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (14, N'Cybersecurity Analyst', N'Protect the company’s digital assets.', 1, CAST(N'2024-03-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), 4);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (15, N'Risk Assessment Officer', N'Identify and evaluate security risks.', 1, CAST(N'2024-04-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-09-30T00:00:00.0000000' AS DateTime2), 2);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (16, N'Emergency Response Officer', N'Handle emergencies and coordinate responses.', 0, CAST(N'2023-02-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-10-31T00:00:00.0000000' AS DateTime2), 3);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (17, N'Technical Security Specialist', N'Install and maintain security systems.', 0, CAST(N'2024-01-15T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-15T00:00:00.0000000' AS DateTime2), 5);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (18, N'Physical Security Specialist', N'Implement measures to protect physical assets.', 0, CAST(N'2024-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-31T00:00:00.0000000' AS DateTime2), 6);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (19, N'Incident Manager', N'Oversee and resolve security incidents.', 1, CAST(N'2023-08-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-12-31T00:00:00.0000000' AS DateTime2), 2);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (20, N'Surveillance Supervisor', N'Supervise surveillance teams.', 1, CAST(N'2024-02-15T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-15T00:00:00.0000000' AS DateTime2), 2);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (21, N'Security Trainer', N'Train new hires on security protocols.', 1, CAST(N'2024-03-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-06-30T00:00:00.0000000' AS DateTime2), 1);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (22, N'Security Consultant', N'Advise clients on improving security.', 0, CAST(N'2024-04-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-31T00:00:00.0000000' AS DateTime2), 3);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (23, N'Patrol Officer', N'Conduct routine patrols to ensure safety.', 0, CAST(N'2023-06-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-11-30T00:00:00.0000000' AS DateTime2), 4);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (24, N'Control Room Operator', N'Manage security control room operations.', 1, CAST(N'2024-03-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-01T00:00:00.0000000' AS DateTime2), 3);
INSERT [dbo].[Vacancies] ([Id], [Title], [Description], [Status], [StartDate], [EndDate], [Quantity]) VALUES (25, N'Security Systems Engineer', N'<p>Design and implement advanced security systems.</p>;
', 1, CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-31T00:00:00.0000000' AS DateTime2), 2);



SET IDENTITY_INSERT [dbo].[ClientEmployees] ON;

INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (28, 20, 31);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (29, 20, 35);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (30, 21, 36);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (31, 22, 32);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (32, 22, 34);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (33, 22, 37);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (34, 22, 38);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (35, 22, 39);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (36, 22, 40);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (37, 18, 37);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (38, 18, 38);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (39, 18, 39);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (42, 24, 32);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (43, 25, 39);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (44, 25, 40);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (45, 26, 40);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (46, 27, 37);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (47, 27, 38);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (48, 27, 39);
INSERT [dbo].[ClientEmployees] ([Id], [ClientId], [EmployeeId]) VALUES (49, 28, 38);
SET IDENTITY_INSERT [dbo].[ClientEmployees] OFF;