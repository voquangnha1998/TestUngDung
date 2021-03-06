USE [VoQuangNhaDB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/20/2021 9:15:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK__Category__3214EC2777E0C955] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/20/2021 9:15:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[UnitCost] [decimal](18, 0) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Image] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[Status] [bit] NOT NULL CONSTRAINT [DF__Product__Status__15502E78]  DEFAULT ((1)),
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK__Product__3214EC279854C843] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 6/20/2021 9:15:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[Status] [bit] NOT NULL CONSTRAINT [DF__UserAccou__Statu__108B795B]  DEFAULT ((1)),
 CONSTRAINT [PK__UserAcco__3214EC27DB2945F2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (1, N'Iphone', N'Điện thoại Iphone thuộc hãng ')
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (2, N'Samsung', N'Điện thoại SS Galaxy thuộc hãng Samsung')
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (3, N'Nokia', N'Điện thoại Nokia thuộc hãng Nokia ')
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (4, N'Vivo', N'Điện thoại Vivo thuộc hãng Vivo')
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (5, N'Oppo', N'Điện thoại Oppo thuộc hãng Oppo')
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (6, N'Xiaomi', N'Điện thoại Xiaomithuộc hãng Xiaomi')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (1, N'iPhone 12 Pro Max I Chính hãng VN/A', CAST(12332432 AS Decimal(18, 0)), 2, N'~/Content/upload/565139596iphone-12-pro-max_1__7.jpg', N'cdfdsfds', 1, 1)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (4, N'Điện thoại Iphone 11 Red', CAST(4563400 AS Decimal(18, 0)), 13, N'~/Content/upload/1940954477iphone11do.jpg', N'Điện thoại Nokia thuộc hãng Nokia ', 1, 1)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (5, N'Điện thoại Iphone 11 plus VA', CAST(6433234 AS Decimal(18, 0)), 5, N'~/Content/upload/1576916560iphone-12-pro-max_1__7.jpg', N'iPhone 11 có kiểu dáng đẹp mắt khi được hoàn thiện từ nhôm và vỏ kính bền nhất trong ', 1, 1)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (6, N'Oppo Reno5', CAST(8690000 AS Decimal(18, 0)), 32, N'~/Content/upload/421702139oppo-reno-5_3_.jpg', N'Sản phẩm mới nhất trong series OPPO Reno của hãng điện thoại OPPO chính là OPPO Reno 5. Chiếc điện thoại với nhiều kế thừa từ người tiền nhiệm Reno với thiết kế hiện đại, cấu hình cao hứa hẹn mang đến những trải nghiệm dùng ấn tượng.', 1, 5)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (7, N'Oppo A93', CAST(5650000 AS Decimal(18, 0)), 63, N'~/Content/upload/2108027266combo_a93-black_2.jpg', N'Oppo A93 được ra mắt năm 2020 với thiết kế mỏng nhẹ và tinh tế, hệ thống camera ấn tượng cùng với cấu hình mạnh mẽ để mang đến sức mạnh vượt trội cho smartphone trong mức giá vô cùng hợp lý và dễ tiếp cận đến nhiều đối tượng người dùng.', 1, 5)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (8, N'Oppo A12', CAST(2146777 AS Decimal(18, 0)), 34, N'~/Content/upload/157233508oppo-a12_1_.jpg', N'Điện thoại Oppo thuộc hãng Oppo', 1, 5)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (9, N'Vivo Y51 2020', CAST(3456200 AS Decimal(18, 0)), 33, N'~/Content/upload/1014361842vivo-y51-cty_1_.jpg', N'Điện thoại Vivo thuộc hãng Vivo', 1, 4)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (10, N'Vivo V21 5G', CAST(3635600 AS Decimal(18, 0)), 23, N'~/Content/upload/217506926vivo-v21-5g-2.jpg', N'Điện thoại vivo thuộc hãng vivo ', 1, 4)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (11, N'Vivo X60 Pro 5G', CAST(6744000 AS Decimal(18, 0)), 22, N'~/Content/upload/1853790333vivo-x60-pro-8.jpg', N'Điện thoại Vivo thuộc hãng Vivo', 1, 4)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (12, N'Vivo Y20', CAST(3190000 AS Decimal(18, 0)), 23, N'~/Content/upload/984463495vivo-y20.png', N'Vivo Y20 thuộc phân khúc smartphone giá rẻ của điện thoại Vivo nhưng vẫn có thiết kế cuốn hút cùng với cấu hình khỏe và pin siêu trâu.', 1, 4)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (13, N'Samsung Galaxy Note 20 Ultra 5G', CAST(19300000 AS Decimal(18, 0)), 23, N'~/Content/upload/790139584yellow_final_2.jpg', N'Bên cạnh biên bản Galaxy Note 20 thường, Samsung còn cho ra mắt Note 20 Ultra 5G cho khả năng kết nối dữ liệu cao cùng thiết kế nguyên khối sang trọng, bắt mắt.', 1, 2)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (14, N'Samsung Galaxy A52', CAST(7900000 AS Decimal(18, 0)), 53, N'~/Content/upload/1845906200samsung-galaxy-a52-26.jpg', N'Điện thoại Samsung Galaxy A52 – Camera sau nâng cấp, cấu hình mạnh mẽ Sau thành công của Samsung Galaxy A51 với mức doanh số khá tốt thì trong năm 2020, Samsung lại tiếp tục cho ra mắt mẫu smartphone Galaxy A52 với những cải tiến', 1, 2)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (15, N'Samsung Galaxy A11', CAST(2650000 AS Decimal(18, 0)), 34, N'~/Content/upload/1585123659ss_a11.jpg', N'Samsung A11 là mẫu smartphone giá rẻ thuộc dòng Galaxy A được Samsung ra mắt trong năm 2020. Đây được xem là phiên bản kế nhiệm của Galaxy A10 - chiếc điện thoại Android bán chạy nhất trong năm 2019.', 1, 2)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (16, N'Samsung Galaxy A71', CAST(7700000 AS Decimal(18, 0)), 34, N'~/Content/upload/666209865samsung-galaxy-a71.jpg', N'Samsung Galaxy A71 sẽ là điện thoại giá cả phải chăng của Samsung với mục đích tiếp cận đối tượng rộng hơn. Samsung A71 là sản phẩm thuộc series Samsung Galaxy A', 1, 2)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (17, N'Nokia 5.4', CAST(2890000 AS Decimal(18, 0)), 34, N'~/Content/upload/1768537403nokia-5-4-xanh_1.jpg', N'Nokia chắc chắn là một trong những thương hiệu không còn xa lạ với người dùng Việt Nam nữa phải không nào. Nokia gần đây hãng vừa tiếp tục viết tiếp câu chuyện về một huyền thoại khi cho ra mắt thị trường chiếc Nokia 5.4', 1, 3)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (18, N'Nokia C20', CAST(2090000 AS Decimal(18, 0)), 45, N'~/Content/upload/467821055nokia-c20-2.jpg', N'Bên cạnh những chiếc smartphone X10, X20, G10 và G20 thì Nokia lại chuẩn bị đóng góp vào bộ sưu tập điện thoại thông minh giá rẻ của mình bằng sản phẩm mang tên Nokia C20. ', 1, 3)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (19, N'Xiaomi Mi 11 Lite 5G', CAST(8990000 AS Decimal(18, 0)), 32, N'~/Content/upload/681526936xiaomi-mi-11-lite-5g-2_10.jpg', N'Mi 11 Lite 5G và 4G là bộ đôi vừa được Xiaomi trình làng. So sánh nhanh thì cả hai máy sở hữu cùng kích thước màn hình, thông số cụm camera sau và dung lượng pin. Nhưng bên cạnh đó thì phiên bản 5G vẫn còn một số điểm khác biệt so với bản 4G.', 0, 6)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (20, N'Xiaomi Redmi 9A', CAST(1900000 AS Decimal(18, 0)), 45, N'~/Content/upload/1736254687redmi_9a.jpg', N'Mới đây, hãng smartphone Xiaomi vừa cho ra mắt Xiaomi Redmi 9A cùng với Redmi 9. Trang bị màn hình lớn, pin "khủng" cùng camera kép, Xiaomi Redmi 9A sẽ là chiếc smartphone thuộc phân khúc phổ thông mà bạn không nên bỏ qua.', 1, 6)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (21, N'Xiaomi Redmi Note 9s 4G 64GB', CAST(4450000 AS Decimal(18, 0)), 34, N'~/Content/upload/150961304redmi_note_9s.jpg', N'Redmi Note 9S là chiếc smartphone tầm trung mới nhất của Xiaomi được nâng cấp của điện thoại Redmi Note 9 hiện nay. Chiếc điện thoại này gây ấn tượng với cấu hình phần cứng mạnh mẽ 4GB RAM', 1, 6)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (22, N'iPhone SE 2020 256GB I Chính hãng VN/A ', CAST(13010000 AS Decimal(18, 0)), 20, N'~/Content/upload/1932076757iphone-se.jpg', N'Nếu nhu cầu lưu trữ không quá nhiều, tham khảo thêm iPhone SE 2020 64GB, đây sẽ là sự lựa chọn phù hợp hơn dành cho bạn.', 0, 1)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (23, N'iPhone 12 Pro Max 512GB I Chính hãng VN/A ', CAST(38530000 AS Decimal(18, 0)), 34, N'~/Content/upload/1604494346iphone-12-pro-max.jpg', N'Không làm cộng đồng những người yêu công nghệ thất vọng, chiếc iPhone 12 Pro Max chính hãng VN/A đã được trình làng và với phiên bản bộ nhớ trong 512GB chắc chắn sẽ mang đến cho bạn không gian lưu trữ cực khủng.', 1, 1)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (24, N'Samsung Galaxy S20 Ultra', CAST(2650000 AS Decimal(18, 0)), 23, N'~/Content/upload/430332247ss-s20-ultra-den-1.png', N'Điện thoại Samsung S20 Ultra – Flagship thiết kế độc đáo, cấu hình cao Samsung Galaxy S20 Ultra là flagship mới của dòng Galaxy S sẽ được Samsung giới thiệu vào đầu năm 2020. Đây là phiên bản cao cấp nhất bên cạnh phiên bản thường và bản Plus.', 1, 2)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (25, N'Nokia 6.1 Plus', CAST(3290000 AS Decimal(18, 0)), 52, N'~/Content/upload/858783137nokia6plus.jpg', N'Điện thoại Nokia 6.1 Plus là smartphone tầm trung của Nokia sản xuất. Sản phẩm mang thiết kế phong cách tai thỏ với màn hình tràn viền cũng như hiệu năng được cải tiến vượt bậc', 1, 3)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[UserAccount] ON 

INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (1, N'admin', N'202cb962ac59075b964b07152d234b70', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (5, N'ngochuy', N'202cb962ac59075b964b07152d234b70', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (9, N'vothang', N'd9b1d7db4cd6e70935368a1efb10e377', 0)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (10, N'quangnha', N'202cb962ac59075b964b07152d234b70', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (11, N'nhavo', N'202cb962ac59075b964b07152d234b70', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (14, N'volap', N'd9b1d7db4cd6e70935368a1efb10e377', 0)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (15, N'trongnhan', N'202cb962ac59075b964b07152d234b70', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (16, N'minhhieu', N'202cb962ac59075b964b07152d234b70', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (17, N'hoangha', N'202cb962ac59075b964b07152d234b70', 0)
SET IDENTITY_INSERT [dbo].[UserAccount] OFF
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Categor__164452B1] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Categor__164452B1]
GO
